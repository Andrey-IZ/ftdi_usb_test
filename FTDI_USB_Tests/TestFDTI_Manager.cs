using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;
using FTD2XX_NET;
using FTD2XX_NET.Fakes;
using FTDI_USB.ManagePLIS;
using System.Threading;
using System.Linq;

namespace FTDI_USB_Tests
{
    [TestClass]
    public class TestFDTI_Manager
    {
        [TestInitialize]
        public void InitializeTest()
        {
            //_ftdi = new FTDI();
            //ShimFTDI.Constructor = (x) => { };
        }
        [TestCleanup]
        public void CleanUpTest()
        {
            //_ftdi.Close();
        }

        [TestMethod]
        public void TestRead()
        {
            TestRead_Basic();
            TestRead_WaitExcept();
        }
        private void TestRead_Basic()
        {
            using (ShimsContext.Create())
            {
                byte[] actualData = new byte[] { 0xFF, 0xFF, 0xF2, 0x2, 0x6, 0x5, 0x6, 0x5, 0x9, 0x6, 0x96, 0x43 };
                uint CountBytes = (uint)actualData.Length;

                ShimFTDI.AllInstances.GetRxBytesAvailableUInt32Ref =
                    (FTDI @this, ref uint numBytesAvailable) =>
                    {
                        numBytesAvailable = CountBytes;
                        return FTDI.FT_STATUS.FT_OK;
                    };
                ShimFTDI.AllInstances.ReadByteArrayUInt32UInt32Ref =
                    (FTDI @this, byte[] buffer, uint numBytes, ref uint refNumBytes) =>
                    {
                        refNumBytes = CountBytes;
                        for (int i = 0; i < CountBytes; i++)
                            buffer[i] = actualData[i];

                        return FTDI.FT_STATUS.FT_OK;
                    };

                FTDI_Manager fm = new FTDI_USB.ManagePLIS.FTDI_Manager();
                var expectedData = fm.Read(CountBytes);
                CollectionAssert.AreEqual(expectedData, actualData);
            }
        }

        private void TestRead_WaitExcept()
        {
            using (ShimsContext.Create())
            {
                byte[] actualData = new byte[] { 0xFF, 0xFF, 0xF2, 0x2, 0x6, 0x5, 0x6, 0x5, 0x9, 0x6, 0x96, 0x43 };
                uint countBytes = (uint)actualData.Length;

                ShimFTDI.AllInstances.GetRxBytesAvailableUInt32Ref =
                    (FTDI @this, ref uint numBytesAvailable) =>
                    {
                        numBytesAvailable = countBytes;
                        Thread.Sleep(200);
                        return FTDI.FT_STATUS.FT_OK;
                    };
                ShimFTDI.AllInstances.ReadByteArrayUInt32UInt32Ref =
                    (FTDI @this, byte[] buffer, uint numBytes, ref uint refNumBytes) =>
                    {
                        refNumBytes = countBytes;
                        for (int i = 0; i < countBytes; i++)
                            buffer[i] = actualData[i];
                        
                        return FTDI.FT_STATUS.FT_OK;
                    };

                bool isEmited = false;
                byte[] expectedData = new byte[0];
                FTDI_Manager fm = new FTDI_Manager();

                try { expectedData = fm.Read(countBytes, 100); }
                catch (FtdiException ex)
                {
                    isEmited = true;
                    if (!ex.Message.Contains("read timeout expired: "))
                        throw;
                }
                finally
                {
                    Assert.AreEqual(false, !isEmited, "Не возникло сообщение о превышении таймаута ");
                }
            }
        }

        [TestMethod]
        public void TestWrite()
        {
            TestWriteSimple();
            TestWriteStatusException();
        }

        private static void TestWriteSimple()
        {
            using (ShimsContext.Create())
            {
                byte[] actualBytes = new byte[] {0xFF, 0xFF, 0xF2, 0x2, 0x6, 0x5, 0x6, 0x5, 0x9, 0x6, 0x96, 0x43};
                uint countBytes = (uint) actualBytes.Length;

                ShimFTDI.AllInstances.WriteByteArrayInt32UInt32Ref =
                    (FTDI @this, byte[] bytesForWriting, int numBytes, ref uint refNumBytes) =>
                    {
                        Assert.AreEqual(countBytes, (uint) bytesForWriting.Length);
                        refNumBytes = countBytes;
                        return FTDI.FT_STATUS.FT_OK;
                    };

                FTDI_Manager fm = new FTDI_Manager();

                var expectedData = fm.Write(actualBytes);
                Assert.AreEqual(expectedData, countBytes);
            }
        }
        private static void TestWriteStatusException()
        {
            using (ShimsContext.Create())
            {
                ShimFTDI.AllInstances.WriteByteArrayInt32UInt32Ref =
                    (FTDI @this, byte[] bytesForWriting, int numBytes, ref uint refNumBytes) =>
                    {
                        refNumBytes = 12;
                        return FTDI.FT_STATUS.FT_DEVICE_NOT_FOUND;
                    };

                FTDI_Manager fm = new FTDI_Manager();
                bool isExcept = false;
                try
                {
                    fm.Write(new byte[] { 0xFF, 0xFF, 0xF2, 0x2, 0x6, 0x5, 0x6, 0x5, 0x9, 0x6, 0x96, 0x43 });
                }
                catch (FtdiException ex)
                {
                    isExcept = true;
                    StringAssert.Contains(ex.Message, nameof(FTDI.FT_STATUS.FT_DEVICE_NOT_FOUND));
                }
                Assert.AreEqual(true, isExcept, "Не было запущено исключение");

            }
        }

        [TestMethod]
        public void TestReadAsync()
        {
            TestReadAsyncSimple();
        }

        private void TestReadAsyncSimple()
        {
            using (ShimsContext.Create())
            {
                List<Byte[]> listActualByteses = new List<byte[]>();
                listActualByteses.Add(new byte[] { 0xFF, 0xFF, 0xF2, 0x2, 0x6, 0x5, 0x6, 0x5, 0x9, 0x6, 0x96, 0x43 });
                listActualByteses.Add(new byte[] { 0xFF, 0xFF, 0xF2, 0x2, 0x6, 0x5, 0x6, 0x5, 0x9, 0x6, 0x96, 0x43 });
                listActualByteses.Add(new byte[] { 0xFF, 0xFF, 0xF2, 0x2, 0x6, 0x5, 0x6, 0x5, 0x9, 0x6, 0x96, 0x43 });
                int indexActualList = 0;

                ShimFTDI.AllInstances.SetTimeoutsUInt32UInt32 =
                    (ftdi, readTimeout, writeTimeout) => FTDI.FT_STATUS.FT_OK;
                //ShimFTDI.AllInstances.SetEventNotification =
                //    (FT_EVENT_RXCHAR, DataReceived) => FTDI.FT_STATUS.FT_OK;
                
                ShimFTDI.AllInstances.WriteByteArrayInt32UInt32Ref =
                    (FTDI @this, byte[] bytesForWriting, int numBytes, ref uint refNumBytes) =>
                    {
                        CollectionAssert.AreEqual(listActualByteses[indexActualList], bytesForWriting);
                        refNumBytes = (uint)listActualByteses[indexActualList].Length;
                        return FTDI.FT_STATUS.FT_OK;
                    };
                ShimFTDI.AllInstances.GetRxBytesAvailableUInt32Ref =
                    (FTDI @this, ref uint numBytesAvailable) =>
                    {
                        numBytesAvailable = (uint)listActualByteses[indexActualList].Length;
                        return FTDI.FT_STATUS.FT_OK;
                    };
                ShimFTDI.AllInstances.ReadByteArrayUInt32UInt32Ref =
                    (FTDI @this, byte[] buffer, uint numBytes, ref uint refNumBytes) =>
                    {
                        refNumBytes = (uint)listActualByteses[indexActualList].Length;
                        for (int i = 0; i < refNumBytes; i++)
                            buffer[i] = listActualByteses[indexActualList][i];
                        //Thread.Sleep(200);

                        return FTDI.FT_STATUS.FT_OK;
                    };

                FTDI_Manager fm = new FTDI_Manager();
                StartReadAsync(fm, 12);
                fm.Write(listActualByteses[indexActualList]);
                CheckReadAsync(listActualByteses.Take(indexActualList).SelectMany(i=>i).ToList());
                indexActualList ++;
                fm.Write(listActualByteses[indexActualList]);
                CheckReadAsync(listActualByteses.Take(indexActualList).SelectMany(i => i).ToList());
                indexActualList ++;

                StopReadAsync(fm);
                uint amountWrBytes = 0;
                try
                {
                    amountWrBytes = fm.Write(listActualByteses[indexActualList]);
                }
                finally
                {
                    Assert.AreEqual(0, amountWrBytes);
                }
            }
        }


        private readonly List<byte> _listRecvBytes = new List<byte>();
        private void StartReadAsync(FTDI_Manager ftdiManager, uint expectedNumberRecvBytes)
        {
            if (ftdiManager == null) throw new ArgumentNullException(nameof(ftdiManager));
            _listRecvBytes.Clear();
            ftdiManager.RecvBytes += FtdiManager_RecvBytes;
            ftdiManager.StartReadAsync(expectedNumberRecvBytes);
        }

        private void FtdiManager_RecvBytes(object sender, FTDI_Manager.ReadRecvBytesEventArgs e)
        {
            _listRecvBytes.AddRange(e.RecvBytes);
        }

        private void CheckReadAsync(List<byte> sendBytes)
        {
            CollectionAssert.AreEqual(_listRecvBytes, sendBytes);
        }

        private void WriteToFtdi(FTDI_Manager ftdiManager, byte[] writeBytes)
        {
            
        }

        private void StopReadAsync(FTDI_Manager ftdiManager)
        {
            ftdiManager.StopReadAsync();
        }
    }
}
