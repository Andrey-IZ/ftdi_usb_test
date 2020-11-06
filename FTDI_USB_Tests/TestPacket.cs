using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FTDI_USB.Workers.PacketWorkers;
using System.Diagnostics;

namespace FTDI_USB_Tests
{
    [TestClass]
    public class TestPacket
    {
        [TestMethod]
        public void TestParse()
        {
            // Test for sending messages, so Aleksahin is sloppy worker (lazy)
            Packet expected = new Packet(5, new List<ushort>() { 0x1234 });
            //Debug.WriteLine("packet = ", expected.ToBytes());
            Packet actual = Packet.Parse(new byte[] { 0xA5, 0x00, 0x05, 0x00, 0x02, 0x00, 0x09, 0x00, 0x34, 0x12, 0x4F, 0x00 });
            Assert.AreEqual(expected.Code, actual.Code);
            CollectionAssert.AreEqual(expected.Data, actual.Data);

            // Test for received messages,  so Aleksahin is sloppy worker (lazy)
            Packet actual2 = Packet.Parse(new byte[] { 0xA5, 0x00, 0x0D, 0x00, 0x02, 0x00, 0x09, 0x00, 0xFF, 0x00, 0x4F, 0x00 });
            Assert.AreEqual(actual2.Code, (ushort)0xD);
            CollectionAssert.AreEqual(actual2.Data, new ushort[] { 0xFF });
        }
        /// <summary>
        /// So Aleksahin is sloppy worker (lazy)!
        /// </summary>
        [TestMethod]
        public void TestCommon()
        {
            Packet expected = new Packet(0xC, new List<ushort>() { 0x1234 });
            Packet actual = Packet.Parse(expected.ToBytes());

            Assert.AreEqual(actual.Code, (ushort)0xC);
            CollectionAssert.AreEqual(actual.Data, new ushort[] { 0x1234 });
        }

        [TestMethod]
        public void TestBuildPacketBytes()
        {
            Packet packet = new Packet(0xB, new List<ushort>() { 0x80 });
            var actual = packet.ToBytes();
            var expected = new byte[] { 0xA5, 0x00, 0x0B, 0x00, 0x02, 0x00, 0x13, 0x00, 0x80, 0x00, 0x80, 0x00 };
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
