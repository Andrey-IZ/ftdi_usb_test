using System;
using System.Collections.Generic;
using FTD2XX_NET;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;
using DebugToolsLib;
using FTDI_USB.Workers.PacketWorkers;

namespace FTDI_USB.ManagePLIS
{
    [Serializable]
    public class FtdiException : Exception
    {
        public FtdiException() { }
        public FtdiException(string message) : base(message) { }
        public FtdiException(string message, Exception inner) : base(message, inner) { }
        protected FtdiException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }


    public class FTDI_Manager: IDisposable
    {
        private FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;

        public FTDI.FT_STATUS Status { get { return ftStatus; } }

        public FTDI FT2Device { get; }

        public FTDI_Manager()
        {
            int errorCode;
            if (!LoadLibs.IsDriverInstalled("FTD2XX.DLL", out errorCode))
                throw new FtdiException("Driver \"FTD2XX.DLL\" is not found in\n" +
                    Path.GetDirectoryName(GetType().Assembly.Location) + "\n Error code = " + errorCode);  // Driver is not installed

            FT2Device = new FTDI();
            ReadDataHandler.DoWork += ReadDataHandler_DoWork;
            ReadDataHandler.RunWorkerCompleted += ReadDataHandler_RunWorkerCompleted;
        }

        public FTDI.FT_DEVICE_INFO_NODE[] DeviceList
        {
            get
            {
                uint ftdiDeviceCount = NumberOfDevices;
                FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];
                ftStatus = FT2Device.GetDeviceList(ftdiDeviceList);

                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                    throw new FtdiException("Failed to get list of devices ( error " + ftStatus.ToString() + ")");
                if (ftdiDeviceList.Length == 0)
                    throw new FtdiException("Failed to get list of devices ( list devices is empty)");

                return ftdiDeviceList;
            }
        }

        public uint NumberOfDevices
        {
            get
            {
                uint ftdiDeviceCount = 0;
                // Determine the number of FTDI devices connected to the machine
                ftStatus = FT2Device.GetNumberOfDevices(ref ftdiDeviceCount);

                // Check status
                if (ftStatus != FTDI.FT_STATUS.FT_OK || ftdiDeviceCount == 0)
                    throw new FtdiException("Failed to get number of devices ( error " + ftStatus.ToString() + ")");
                if (ftdiDeviceCount == 0)
                    throw new FtdiException("Failed to get number of devices ( devices not found )");

                return ftdiDeviceCount;
            }
        }


        public bool OpenBySerialNumber(string serialNumber, uint baudRate = 9600, uint timeoutRead = 2000, uint timeOutWrite = 2000)
        {
            ftStatus = FT2Device.OpenBySerialNumber(serialNumber);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
                throw new FtdiException("Failed to open device (error " + ftStatus.ToString() + ")");

            // Set up device data parameters
            SetBaudRate(baudRate);

            // Set data characteristics - Data bits, Stop bits, Parity
            ftStatus = FT2Device.SetDataCharacteristics(FTDI.FT_DATA_BITS.FT_BITS_8, FTDI.FT_STOP_BITS.FT_STOP_BITS_1, FTDI.FT_PARITY.FT_PARITY_NONE);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
                throw new FtdiException("Failed to set data characteristics (error " + ftStatus.ToString() + ")");

            //// Set flow control - set RTS/CTS flow control
            //ftStatus = _FT2Device.SetFlowControl(FTDI.FT_FLOW_CONTROL.FT_FLOW_RTS_CTS, 0x11, 0x13);
            //if (ftStatus != FTDI.FT_STATUS.FT_OK)
            //    throw new FtdiException("Failed to set flow control (error " + ftStatus.ToString() + ")");

            // Set read timeout to 5 seconds, write timeout to infinite
            ftStatus = FT2Device.SetTimeouts(timeoutRead, timeOutWrite);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
                throw new FtdiException("Failed to set timeouts (error " + ftStatus + ")");

            return true;
        }

        public bool SetBaudRate(uint baudRate)
        {
            ftStatus = FT2Device.SetBaudRate(baudRate);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
                throw new FtdiException("Failed to set Baud rate (error " + ftStatus + ")");
            return true;
        }

        /// <summary>
        /// Writes bytes array to FTDI device
        /// </summary>
        /// <param name="bytesForWriting"></param>
        /// <returns>Number written bytes</returns>
        public uint Write(byte[] bytesForWriting)
        {
            uint numBytesWritten = 0;
            // Note that the Write method is overloaded, so can write string or byte array data
            ftStatus = FT2Device.Write(bytesForWriting, bytesForWriting.Length, ref numBytesWritten);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
                throw new FtdiException("Failed write to device (error " + ftStatus + ")");

            return numBytesWritten;
        }

        public byte[] Read(uint expectedNumberOfBytes = 1, uint timeoutMs = 2000, bool isDoEvents = true)
        {
            // Check the amount of data available to read
            // In this case we know how much data we are expecting, 
            // so wait until we have all of the bytes we have sent.
            uint numBytesAvailable = 0;
            var timeout = Stopwatch.StartNew();
            do
            {
                ftStatus = FT2Device.GetRxBytesAvailable(ref numBytesAvailable);
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                    throw new FtdiException("Failed to get number of bytes available to read (error " + ftStatus.ToString() + ")");
                if (numBytesAvailable >= expectedNumberOfBytes || expectedNumberOfBytes == 0)
                    break;
                //Thread.Sleep(1);
                if (timeout.ElapsedMilliseconds > timeoutMs && timeoutMs > 0)
                    throw new FtdiException($"Failed read data (read timeout expired: {timeout.ElapsedMilliseconds} ms)");
                if (isDoEvents)
                    System.Windows.Forms.Application.DoEvents();
            } while (true);


            // Now that we have the amount of data we want available, read it
            byte[] readData = new byte[numBytesAvailable];
            uint numBytesRead = 0;

            ftStatus = FT2Device.Read(readData, numBytesAvailable, ref numBytesRead);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
                throw new FtdiException("Failed read data (error " + ftStatus.ToString() + ")");

            return readData;
        }

        /// <summary>
        /// Closes FTDI device
        /// </summary>
        /// <returns>true, if it closed success, otherwise false</returns>
        public bool Close()
        {
            ftStatus = FT2Device.Close();
            if (ftStatus == FTDI.FT_STATUS.FT_OK)
                return true;
            return false;
        }

        #region Read Async
        public class ReadRecvBytesEventArgs : EventArgs
        {
            public byte[] RecvBytes { get; }

            public ReadRecvBytesEventArgs(byte[] recvbytes)
            {
                RecvBytes = recvbytes;
            }
        }

        public bool IsReadServerRunning => ReadDataHandler.IsBusy;

        // Delegate that defines the signature for the callback method.
        //
        public delegate void ReadRecvBytesEventHandler(object sender, ReadRecvBytesEventArgs e);

        private EventWaitHandle DataReceived = new EventWaitHandle(false, EventResetMode.AutoReset);    // Handle for data received events
        private BackgroundWorker ReadDataHandler = new BackgroundWorker();  // Second thread for processing data received

        public bool StartReadAsync(uint expectedNumberOfBytes = 0, uint timeoutRead = 0)
        {
            if (IsReadServerRunning)
                return false;

            // Set the RX/TX timeouts
            if ((ftStatus = FT2Device.SetTimeouts(timeoutRead, 0)) != FTDI.FT_STATUS.FT_OK)
                throw new FtdiException("Failed to set timeouts (" + ftStatus.ToString() + ")\n");

            DataReceived.Reset();
            // Subscribe to FT_EVENT_RXCHAR events
            FT2Device.SetEventNotification(FTDI.FT_EVENTS.FT_EVENT_RXCHAR, DataReceived);

            ReadDataHandler.WorkerSupportsCancellation = true;
            // Start the received data thread
            ReadDataHandler.RunWorkerAsync();

            return true;
        }

        private void ReadDataHandler_DoWork(object sender, DoWorkEventArgs e)
        {
            UInt32 nrOfBytesAvailable = 0;
            try
            {
                // Loop forever
                while (!ReadDataHandler.CancellationPending)
                {
                    // Wait for a FT_EVENT_RXCHAR event
                    if (DataReceived.WaitOne(1))
                    {
                        // Find out how many bytes have been received
                        if ((FT2Device.GetRxBytesAvailable(ref nrOfBytesAvailable)) != FTDI.FT_STATUS.FT_OK)
                            continue;

                        if (nrOfBytesAvailable > 0)
                        {
                            byte[] readData = new byte[nrOfBytesAvailable];
                            // Read the bytes out
                            if ((FT2Device.Read(readData, nrOfBytesAvailable, ref nrOfBytesAvailable)) !=
                                FTDI.FT_STATUS.FT_OK)
                                continue;

                            OnRecvBytes(readData);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                // ignored
            }
        }
        private void ReadDataHandler_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ListenRecvStopped(sender, EventArgs.Empty);
        }

        public event EventHandler ListenRecvStopped;
        // Delegate used to execute the callback method when the
        // task is complete.
        public event ReadRecvBytesEventHandler RecvBytes;
        protected virtual void OnRecvBytes(byte[] recvBytes)
        {
            RecvBytes?.Invoke(this, new ReadRecvBytesEventArgs(recvBytes));
        }

        public bool StopReadAsync()
        {
            if (ReadDataHandler.WorkerSupportsCancellation)
            {
                if (IsReadServerRunning)
                    ReadDataHandler.CancelAsync();
                return true;
            }
            return false;
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    ((IDisposable) ReadDataHandler).Dispose();
                    ((IDisposable) DataReceived).Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~FTDI_Manager() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}