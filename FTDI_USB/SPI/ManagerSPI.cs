using System;
using System.Drawing;
using System.Windows.Forms;
using DebugToolsLib;
using DebugToolsLib.MicroLibrary;
using DebugToolsLib.WinFormControl;
using FTDI_USB.ManagePLIS;
using FTDI_USB.Workers.PacketWorkers;

namespace FTDI_USB.SPI
{
    public class ManagerSPI
    {
        private FTDI_Manager _ftdiManager;

        public ManagerSPI(FTDI_Manager ftdiManager)
        {
            _ftdiManager = ftdiManager;
        }

        public uint SendData(uint code, uint dataWord)
        {
            return SendData(new Packet(code, dataWord));
        }

        public uint SendData(Packet packet)
        {
            return SendData(packet.ToBytes());
        }

        public uint SendData(byte[] data)
        {
            var numBytes =_ftdiManager.Write(data);
            OutputMsgSent?.Invoke(this, new OutputSentMessageArgs(data));
            return numBytes;
        }

        public void SendToSPI_D12(uint address, uint data, long delay_mcs = 50)
        {
            SendData(0x0, address);
            MicroStopwatch.Sleep(delay_mcs);
            SendData(0x0, data);
        }
        public void SendToSPI_D21(uint address, uint data, long delay_mcs = 50)
        {
            SendData(0x0, address);
            MicroStopwatch.Sleep(delay_mcs);
            SendData(0x0, data);
        }
        public void SendToSPI_EndAddress(uint valueEndAddress, bool isD12)
        {
            if (isD12)
                SendToSPI_D12(0x0, valueEndAddress);
            else
                SendToSPI_D21(0x0, valueEndAddress);
        }



        #region Events
        public event OutputMsgSentEventHandler OutputMsgSent;
        public delegate void OutputMsgSentEventHandler(object sender, OutputSentMessageArgs args);

        public class OutputSentMessageArgs
        {
            public byte[] _data;
            public OutputSentMessageArgs(byte[] data)
            {
                this._data = data;
            }

            public byte[] Data
            {
                get { return _data; }
            }
        }
        #endregion
    }
    
}