using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using FTDI_USB.ManagePLIS;
using System.Threading;
using FTDI_USB.Workers.PacketWorkers;
using DebugToolsLib;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;
using DebugToolsLib.MicroLibrary;

namespace FTDI_USB.Workers
{
    class SendFileWorker : BackgroundWorker
    {
        [Serializable]
        public class CancelSendFileException : Exception
        {
            public CancelSendFileException() { }
            public CancelSendFileException(string message) : base(message) { }
            public CancelSendFileException(string message, Exception inner) : base(message, inner) { }
            protected CancelSendFileException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context)
            { }
        }

        [Serializable]
        public class SendFileException : Exception
        {
            public SendFileException() { }

            public SendFileException(string message) : base(message) { }

            public SendFileException(string message, Exception inner) : base(message, inner) { }

            protected SendFileException(SerializationInfo info, StreamingContext context) : base(info, context)
            { }
        }

        private bool isD12 = true;
        private byte[] fileToSend;
        private FTDI_Manager ftdi_device;

        public SendFileWorker()
        {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        private long _baudRate;

        public long BaudRate
        {
            get { return Interlocked.Read(ref _baudRate); }
            set { Interlocked.Exchange(ref _baudRate, value); }
        }

        private long _lenBuffer = 1;
        private byte[] bytesArray = new byte[1];

        public long LenBuffer
        {
            get { return Interlocked.Read(ref _lenBuffer); }
            set { Interlocked.Exchange(ref _lenBuffer, value); }
        }

        public bool RunWorkerAsync(FTDI_Manager ftdi_device, byte[] fileToSend, bool isD12 = true)
        {
            if (IsBusy != true)
            {
                this.isD12 = isD12;
                this.ftdi_device = ftdi_device;
                this.fileToSend = fileToSend;
                base.RunWorkerAsync();
                return true;
            }
            return false;
        }

        private Thread workerThread;

        public bool SetPriority(ThreadPriority priority = ThreadPriority.Highest)
        {
            if (workerThread != null)
            {
                workerThread.Priority = priority;
                if (workerThread.Priority == priority)
                    return true;
            }
            return false;
        }

        public void Abort()
        {
            if (workerThread != null)
            {
                workerThread.Abort();
                workerThread = null;
            }
        }

        private uint SendData(byte[] dataBytes, uint startIndex, uint lenBuf, Packet.BytesOrders bytesOrder = Packet.BytesOrders.LowerByteFirst)
        {
            if (lenBuf != bytesArray.Length)
                Array.Resize(ref bytesArray, (int)lenBuf);
            Array.Copy(dataBytes, startIndex, bytesArray, 0, lenBuf);

            return ftdi_device.Write(bytesArray);
        }

        private uint SendData(uint code, uint dataWord)
        {
            Packet packet = new Packet(code, dataWord);
            var numBytesWritten = ftdi_device.Write(packet.ToBytes());
            return numBytesWritten;
        }
       
        private bool loopMainWorkSendFile()
        {
            try
            {
                if (isD12)
                    return LoopSubWorkSendFile(0, 0);
                return LoopSubWorkSendFile(0x0, 0);
            }
            catch (FtdiException ex)
            {
                ReportProgress(0, string.Format("Ошибка в работе с устройством FTDI: {0}", ex.Message));
            }
            catch (PacketException ex)
            {
                ReportProgress(0, string.Format("Ошибка c пакетом: {0}", ex.Message));
            }
            return false;
        }

        private void ShowProgress(uint fileLength, uint indexOffset, long freqShowMs, uint lenFilePart,
            uint baudRate, ref uint indexOffsetPrev)
        {
            var percent = (int)((double)(indexOffset + lenFilePart) / fileLength * 100);
            var timeSec = stopwatch.Elapsed.TotalSeconds;
            var speed = (indexOffset - indexOffsetPrev) / timeSec;
            var etaSecs = speed > 0 ? (fileLength - indexOffset - 1) / speed : 0;
            var etaStr = ConvertUnit.TimeSpanToString(TimeSpan.FromSeconds(etaSecs));
            var timeOverall = ConvertUnit.TimeSpanToString(TimeSpan.FromSeconds(stopwatchOverall.Elapsed.TotalSeconds));
            var speedStr = ConvertUnit.InfoSpeedSuffixToString(speed, freqShowMs,
                ConvertUnit.InfoSizeSuffixes.bytes, ConvertUnit.InfoTimeSuffixes.ms);
            var uploadPart = ConvertUnit.InfoSizeSuffixToString(indexOffset + lenFilePart,
                ConvertUnit.InfoSizeSuffixes.bytes);
            var fullSize = ConvertUnit.InfoSizeSuffixToString(fileLength, ConvertUnit.InfoSizeSuffixes.bytes);
            var lenFilePartStr = ConvertUnit.InfoSizeSuffixToString(lenFilePart, ConvertUnit.InfoSizeSuffixes.bytes);
            indexOffsetPrev = indexOffset;
            //-------------------------------------------------
            ReportProgress(percent,
                string.Format(
                    "Отправлено: {0} из {1} (br={6}, part={7}) ({2}%, V={3}, ETA={4}) (t={5})",
                    uploadPart, fullSize, percent, speedStr, etaStr, timeOverall, 
                    baudRate, lenFilePartStr));
            stopwatch.Restart();
        }


        private Stopwatch stopwatch = new Stopwatch();
        private Stopwatch stopwatchOverall = new Stopwatch();

        private bool LoopSubWorkSendFile(uint setHighAddr, uint modePLIS)
        {
            ReportProgress(0, "Устанавливаем режим программирования");
            stopwatch.Restart();

            SendData(4, 0);             // Установить младшую часть адреса
            SendData(3, setHighAddr);   // Установить старшую часть адреса
            SendData(8, modePLIS);      // Установить режим программирования ПЛИС
            MicroStopwatch.Sleep(1);    // Задержка 1 мс

            ReportProgress(0, "Передаем файл: " + ConvertUnit.InfoSizeSuffixToString(fileToSend.Length, ConvertUnit.InfoSizeSuffixes.bytes));

            long freqShowMs = 1000;
            uint indexOffsetPrev = 0;
            uint fileLength = (uint)fileToSend.Length;
            uint lenFilePart;
            uint baudRate = 0;
            uint lenBuffer;
            uint countSendData = 0;
            stopwatchOverall.Restart();
            stopwatch.Restart();

            try
            {
                for (uint indexOffset = 0; indexOffset < fileLength; indexOffset += lenBuffer)
                {
                    if (CancellationPending)
                        throw new CancelSendFileException();

                    baudRate = ChangeBaudRate(baudRate);

                    lenBuffer = (uint)LenBuffer;

                    if (fileLength < indexOffset + lenBuffer) lenFilePart = fileLength - indexOffset;
                    else lenFilePart = lenBuffer;

                    countSendData += SendData(fileToSend, indexOffset, lenFilePart); // Посылаем по lenFilePart байт файла

                    if (stopwatch.ElapsedMilliseconds > freqShowMs || indexOffset == 0 || countSendData == fileLength)
                        ShowProgress(fileLength, indexOffset, freqShowMs, lenFilePart,
                            baudRate, ref indexOffsetPrev);
                }

                if (countSendData != fileLength)
                    throw new SendFileException($"Передан не весь файл ! Байты: {countSendData} != {fileLength}");
            }
            catch (FtdiException ex)
            {
                throw new FtdiException(ex.Message);
            }
            catch (PacketException ex)
            {
                throw new PacketException(ex.Message);
            }

            return true;
        }

        private uint ChangeBaudRate(uint prevBaudrate)
        {
            var baudrate = BaudRate;
            if (baudrate != prevBaudrate)
            {
                try
                {
                    ftdi_device.SetBaudRate((uint)baudrate);
                }
                catch (Exception)
                {
                    ReportProgress(0, "Ошибка изменения скорости: " + prevBaudrate);
                    return prevBaudrate;
                }
                return (uint)baudrate;
            }

            return prevBaudrate;
        }
        
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            bool result = false;
            workerThread = Thread.CurrentThread;

            ReportProgress(0, "");
            try
            {
                result = loopMainWorkSendFile();
            }
            catch (CancelSendFileException)
            {
                e.Cancel = true;
            }
            catch (ThreadAbortException)
            {
                e.Cancel = true;
                WasAbort = true;
                Thread.ResetAbort();    // Предотвратить ThreadAbortException "безчинство"
            }
            finally
            {
                stopwatchOverall.Stop();
                if (!WasAbort)
                {
                    SendData(0, 0A);   // Контрольный посыл
                    SendData(0, 0x0);
                    e.Result = new KeyValuePair<bool, string>(result, 
                        ConvertUnit.TimeSpanToString(stopwatchOverall.Elapsed));
                }
            }
        }

        public bool WasAbort { get; set; }
    }
}
