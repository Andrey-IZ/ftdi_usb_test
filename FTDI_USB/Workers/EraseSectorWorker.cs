using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using FTDI_USB.ManagePLIS;
using System.Threading;
using DebugToolsLib.MicroLibrary;
using FTDI_USB.Workers.PacketWorkers;
using System.Diagnostics;
using DebugToolsLib;

namespace FTDI_USB.Workers
{
    class EraseSectorWorker: BackgroundWorker
    {
        [Serializable]
        public class CancelEraseException : Exception
        {
            public CancelEraseException() { }
            public CancelEraseException(string message) : base(message) { }
            public CancelEraseException(string message, Exception inner) : base(message, inner) { }
            protected CancelEraseException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context)
            { }
        }


        [Serializable]
        public class EraseSectorException : Exception
        {
            public EraseSectorException() { }
            public EraseSectorException(string message) : base(message) { }
            public EraseSectorException(string message, Exception inner) : base(message, inner) { }
            protected EraseSectorException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context)
            { }
        }

        private bool isD12 = true;
        private FTDI_Manager ftdi_device;

        public EraseSectorWorker()
        {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        public bool RunWorkerAsync(FTDI_Manager ftdi_device, bool isD12 = true)
        {
            if (IsBusy != true)
            {
                this.isD12 = isD12;
                this.ftdi_device = ftdi_device;
                base.RunWorkerAsync();
                return true;
            }
            return false;
        }

        private uint SendData(uint code, uint dataWord)
        {
            Packet packet = new Packet(code, dataWord);
            var numBytesWritten = ftdi_device.Write(packet.ToBytes());
            return numBytesWritten;
        }
        private uint ReadCode()
        {
            SendData(0, 0x0);       // чтение регистра

            var code = Packet.Parse(ftdi_device.Read(12)).Data;
            return code[0];
        }

        private bool loopMainWorkEraseSector()
        {
            try
            {
                if (isD12)
                    return loopSubWorkEraseSector(0, 191);
                return loopSubWorkEraseSector(192, 383);
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

        private bool testValidErase(uint code, uint valueSector)
        {
            if ((code >> 4) == 0)
            {
                ReportProgress(0, string.Format("Ошибка стирания сектора \"{0}\"", valueSector));
                throw new EraseSectorException("Считан код 0x0!");
            }
            return true;
        }

        private bool loopSubWorkEraseSector(uint from, uint to)
        {
            for (uint valueSector = from; valueSector <= to; valueSector++)
            {
                if (CancellationPending)
                    throw new CancelEraseException();
                
                SendData(0, valueSector);
                MicroStopwatch.Sleep(1);    // Задержка 1 мс

                var code = ReadCode();
                testValidErase(code, valueSector);

                var percent = (int)(((double)(valueSector - from) / (to - from)) * 100);
                if (code == 0x0)
                {
                    ReportProgress(percent, string.Format("Стирание сектора \"{0}\" начато ({1}%)", valueSector, percent));
                    ReportProgress(percent, string.Format("Cектор \"{0}\" стерт ({1}%)", valueSector, percent));
                }
                else if((code >> 1) == 0)
                {
                    ReportProgress(percent,
                        string.Format("Стирание сектора \"{0}\" начато ({1}%)", valueSector, percent));
                    if (!loopErase10000(valueSector, percent))
                        throw new EraseSectorException("Цикл 10000 опроса завершен!");
                    stopwatchOverall.Stop();
                    stopwatchLoop10thousand.Stop();
                }
                else
                    throw new EraseSectorException($"Получен неопознанный код: 0x{code:X}!");
            }
            
            return true;
        }
        /// <summary>
        /// Frequency per seconds for show message users
        /// </summary>
        private int freqShowLoop10thousandMs = 300;
        Stopwatch stopwatchLoop10thousand = new Stopwatch();
        Stopwatch stopwatchOverall = new Stopwatch();

        private bool loopErase10000(uint valueSector, int percent)
        {
            stopwatchOverall.Restart();
            stopwatchLoop10thousand.Restart();
            uint prevIndex = 0;
            var sizeLoop = 10000;
            for (uint i = 0; i < sizeLoop; i++)
            {
                if (CancellationPending)
                    throw new CancelEraseException();

                var code = ReadCode();

                testValidErase(code, valueSector);
                if (code == 0x0)
                {
                    ReportProgress(percent, string.Format("Cектор \"{0}\" стерт ({1}%)", valueSector, percent));
                    return true;
                }
                if (stopwatchLoop10thousand.ElapsedMilliseconds > freqShowLoop10thousandMs)
                    ShowProgress10000(code, sizeLoop, i, valueSector, percent, ref prevIndex);
            }
            ReportProgress(0, string.Format("Стереть сектор \"{0}\" не удалось", valueSector));
            return false;
        }

        private void ShowProgress10000(uint code, int sizeLoop, uint indexOffset, uint valueSector, int percentSector,
           ref uint indexOffsetPrev)
        {
            var percent = (int)((double)(indexOffset + 1) / sizeLoop * 100);
            var timeSec = stopwatchLoop10thousand.Elapsed.TotalSeconds;
            var speed = (indexOffset - indexOffsetPrev) / timeSec;
            var etaSecs = speed > 0 ? (sizeLoop - indexOffset) / speed : 0;
            var etaStr = ConvertUnit.TimeSpanToString(TimeSpan.FromSeconds(etaSecs));
            var timeOverall = ConvertUnit.TimeSpanToString(TimeSpan.FromSeconds(stopwatchOverall.Elapsed.TotalSeconds));
            indexOffsetPrev = indexOffset;
            //-------------------------------------------------
            var strMsg = string.Format("Стирание сектора \"{0}\" начато ({1}%)", valueSector, percentSector);
            ReportProgress(percentSector,
                string.Format(
                    "{7}: цикл: {0} из {1}, код=0x{5:X} ({2}%, V={3:F1} ц/с ETA={4}) (t={6})",
                    indexOffset, sizeLoop, percent, speed, etaStr, code, timeOverall, strMsg));
            stopwatchLoop10thousand.Restart();
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            ReportProgress(0, "");
            try
            {
                e.Result = loopMainWorkEraseSector();
            }
            catch (CancelEraseException)
            {
                e.Cancel = true;
            }
            finally
            {
                SendData(0, 0x0);   // Контрольный посыл
            }
        }
    }
}
