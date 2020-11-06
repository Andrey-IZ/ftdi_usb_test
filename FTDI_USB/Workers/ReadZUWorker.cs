using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using DebugToolsLib.MicroLibrary;
using FTDI_USB.ManagePLIS;
using FTDI_USB.Workers.PacketWorkers;

namespace FTDI_USB.Workers
{
    public class ReadZUWorker: BackgroundWorker
    {
        [Serializable]
        public class CancelReadZUException : Exception
        {
            public CancelReadZUException(){}

            public CancelReadZUException(string message) : base(message){}

            public CancelReadZUException(string message, Exception inner) : base(message, inner){}

            protected CancelReadZUException(
                SerializationInfo info,
                StreamingContext context) : base(info, context)
            {}
        }

        public static UInt32 CastUnt16To32(ushort dataLow, ushort dataHigh)
        {
            return (uint) (((uint)dataHigh << 16) | dataLow);
        }

        public class StateReadingZU
        {
            private const ushort threshold = 0x0;
            public string message;
            public List<ushort> data;
            public bool isDataExist;

            public StateReadingZU(string message)
            {
                this.data = new List<ushort>();
                isDataExist = false;
                this.message = message;
            }
            public StateReadingZU(string message, List<ushort> data)
            {
                this.data = data;
                isDataExist = true;
                this.message = message;
            }

            public string DataToHexStr()
            {
                return ToHex(data);
            }

            public string TranslateData()
            {
                return (data[0] > threshold ? data[0] - threshold : -1 * (threshold - data[0])).ToString();
            }

            public static string ToHex(List<ushort> listValues)
            {
                string result = "";
                for (int i = 0; i < listValues.Count; i++)
                {
                    var bytes = Packet.GetBytes(listValues[i], Packet.BytesOrders.UpperByteFirst);
                    result = $"{bytes[0]:X2} {bytes[1]:X2} ";
                }
                result = result.Remove(result.Length - 1, 1);
                return result;
            }
        }

        private bool isD12 = true;
        private FTDI_Manager ftdi_device;
        private uint deepReading = 1;

        public ReadZUWorker()
        {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        public bool RunWorkerAsync(FTDI_Manager ftdi_device, uint deepReading = 1, bool isD12 = true)
        {
            if (IsBusy != true)
            {
                this.isD12 = isD12;
                this.deepReading = deepReading;
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
        private List<ushort> ReadZU()
        {
            SendData(0, 0x0);       // чтение регистра

            return Packet.Parse(ftdi_device.Read(12)).Data;
        }

        private bool loopMainWorkReadZU()
        {
            try
            {
                if (isD12)
                    return loopSubWorkReadZU(0x0, 0x0);
                return loopSubWorkReadZU(0x0, 0x0);
            }
            catch (FtdiException ex)
            {
                ReportProgress(0, new StateReadingZU(string.Format("Ошибка в работе с устройством FTDI: {0}", ex.Message)));
            }
            catch (PacketException ex)
            {
                ReportProgress(0, new StateReadingZU(string.Format("Ошибка c пакетом: {0}", ex.Message)));
            }
            return false;
        }

        private bool loopSubWorkReadZU(uint dataPreset, uint cmdRead)
        {
            SendData(0, dataPreset);     // подготовка к циклу блока с сектором
            MicroStopwatch.Sleep(50);    // Задержка 50 мс

            for (uint i = 0; i < this.deepReading; i++)
            {
                if (CancellationPending)
                    throw new CancelReadZUException();

                SendData(cmdRead, i);
                MicroStopwatch.Sleep(1);    // Задержка 1 мс

                var data = ReadZU();

                var percent = (uint)((double)i / (this.deepReading - 1) * 100);
                ReportProgress((int)percent, new StateReadingZU(string.Format("{0}% ({1} из {2})", percent, i + 1, deepReading), data));
            }

            return true;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            ReportProgress(0, new StateReadingZU(""));
            try
            {
                e.Result = loopMainWorkReadZU();
            }
            catch (CancelReadZUException)
            {
                e.Cancel = true;
            }
            
        }
    }
}