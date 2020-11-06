using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading;
using DebugToolsLib.MicroLibrary;
using FTDI_USB.ManagePLIS;
using FTDI_USB.SPI;

namespace FTDI_USB.Workers
{
    

    public class WriteOZUWorker : BackgroundWorker
    {
        public class WriteOzuException : Exception
        {
            public WriteOzuException() { }

            public WriteOzuException(string message) : base(message) { }

            public WriteOzuException(string message, Exception innerException) : base(message, innerException) { }

            protected WriteOzuException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        }

        private const int DelayToShow = 400;
        /// <summary>
        /// Задержка 10 мкс
        /// </summary>
        private const int DelayMcsWriteOZU = 10;
        private bool isD12 = true;
        private readonly uint indexBegin = 0x0;
        private ManagerSPI managerSPI;
        private UInt16[] dataOZU;
        private uint _from;
        private uint until;

        public WriteOZUWorker()
        {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        public bool RunWorkerAsync(FTDI_Manager ftdi_device, ushort[] arrCells, uint from, uint until, bool isD12 = true)
        {
            if (IsBusy != true)
            {
                this.isD12 = isD12;
                managerSPI = new ManagerSPI(ftdi_device);
                dataOZU = arrCells;
                this._from = from;
                this.until = until;
                base.RunWorkerAsync();
                return true;
            }
            return false;
        }
        private Stopwatch stopwatchLoopShowProgress = new Stopwatch();
        private StateWriteOZU loopMainWorkWriteOZU()
        {
            stopwatchLoopShowProgress.Start();
            for (uint i = _from; i <= until; i++)
            {
                var address = indexBegin + i;
                var data = dataOZU[i];

                if (isD12) managerSPI.SendToSPI_D12(address, data);
                else managerSPI.SendToSPI_D21(address, data);
                MicroStopwatch.USleep(DelayMcsWriteOZU);  // Задержка 10 мкс
                if (stopwatchLoopShowProgress.ElapsedMilliseconds > DelayToShow)
                    ShowProgress((int) ((double) (i + 1)/(until + 1)*100), i, i - _from + 1);
            }
            var countData = until - _from + 1;
            var result = new StateWriteOZU(
                string.Format("Записано в ОЗУ ({2}): \"{0}\" данных c индекса \"0x{1:X4}\"", countData, indexBegin,
                    isD12 ? "D12" : "D21"),
                isD12, _from, countData);
            ReportProgress(100, result);
            return result;
        }

        private void ShowProgress(int percent, uint index, uint amountData)
        {
            ReportProgress(percent,
                new StateWriteOZU(string.Format("Записано в ОЗУ ({3}): индекс=\"0x{0:X4}\", кол-во данных \"{1}\" ({2}%)",
                    indexBegin + index, amountData, percent, isD12 ? "D12" : "D21"), isD12, _from, amountData));
            stopwatchLoopShowProgress.Restart();
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            ReportProgress(0, new StateWriteOZU("Старт записи в ОЗУ", isD12));
            try
            {
                e.Result = loopMainWorkWriteOZU();
            }
            catch (WriteOZUWorker.WriteOzuException)
            {
                e.Cancel = true;
            }
        }

        internal class StateWriteOZU
        {
            public bool IsD12;
            public string Message;
            public uint IndexFrom;
            public uint IndexLoad;

            public StateWriteOZU(string message, bool isD12, uint indexFrom, uint indexLoad)
            {
                this.IsD12 = isD12;
                Message = message;
                this.IndexFrom = indexFrom;
                this.IndexLoad = indexLoad;
            }

            public StateWriteOZU(string message, bool isD12)
            {
                this.IsD12 = isD12;
                Message = message;
            }

        }
    }
}