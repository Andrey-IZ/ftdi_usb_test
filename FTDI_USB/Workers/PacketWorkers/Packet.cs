using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTDI_USB.Workers.PacketWorkers
{
    public class Packet
    {
        private static readonly ushort prefix = 0x0;
        private static readonly ushort crcHeader = 0x0;
        //private static readonly ushort crcData = 0x0;
        private ushort code;
        private List<ushort> data;

        public enum BytesOrders { UpperByteFirst, LowerByteFirst };
        public BytesOrders BytesOrder;

        public Packet(uint code, List<ushort> data, BytesOrders bytesOrder = BytesOrders.LowerByteFirst)
        {
            this.code = (ushort)code;
            this.data = new List<ushort>(data);
            BytesOrder = bytesOrder;
        }
        public Packet(uint code, uint dataWord, BytesOrders bytesOrder = BytesOrders.LowerByteFirst)
        {
            this.code = (ushort)code;
            this.data = new List<ushort>();
            this.data.Add((ushort)dataWord);
            BytesOrder = bytesOrder;
        }

        public ushort Code { get { return code; } }
        public List<ushort> Data { get { return data; } }

        public string DataString
        {
            get
            {
                StringBuilder str = new StringBuilder("[");
                foreach (ushort dataUshort in data)
                    str.Append($"0x{dataUshort:X},");
                str.Remove(str.Length-1,1);
                str.Append("]");
                return str.ToString();
            }
        }

        public KeyValuePair<uint, uint> IndexCode => new KeyValuePair<uint, uint>(2, 2);

        public KeyValuePair<uint, uint> IndexData => new KeyValuePair< uint, uint> (8, (uint)Data.Count * 2);

        public override string ToString()
        {
            return string.Format("Код = 0x{0:X}, Данные = {1}, Порядок = {2}",
                Code, DataString, BytesOrder == BytesOrders.UpperByteFirst ? "Big Endian" : "Little Endian");
        }

        public static byte[] GetBytes(ushort dataWord, BytesOrders bytesOrder = BytesOrders.LowerByteFirst)
        {
            byte[] dataBytes = BitConverter.GetBytes(dataWord);
            if (bytesOrder == BytesOrders.UpperByteFirst)
                Array.Reverse(dataBytes);

            return dataBytes;
        }
        private static byte[] bytesArray = new byte[2];
        public static ushort GetUInt16(byte[] dataBytes, int startIndex, BytesOrders bytesOrder = BytesOrders.LowerByteFirst)
        {
            ushort dataWord;
            
            Array.Copy(dataBytes, startIndex, bytesArray, 0, 2);

            if (bytesOrder == BytesOrders.UpperByteFirst)
                Array.Reverse(bytesArray);

            dataWord = BitConverter.ToUInt16(bytesArray, 0);

            return dataWord;
        }
        private List<byte> packet = new List<byte>();
        public byte[] ToBytes()
        {
            if (Data.Count == 0)
                return new byte[0];
                //throw new PacketException("Failed build packet (length data == 0)");

            packet.Clear();

            ushort lenData = (ushort)(Data.Count + 1);

            packet.AddRange(GetBytes(prefix, BytesOrder));
            packet.AddRange(GetBytes(code, BytesOrder));
            packet.AddRange(GetBytes(lenData, BytesOrder));
            packet.AddRange(GetBytes(crcHeader, BytesOrder));
            foreach (var d in data)
            {
                packet.AddRange(GetBytes(d, BytesOrder));
            }
            ushort CrcData = Data[0];
            packet.AddRange(GetBytes(CrcData, BytesOrder));

            return packet.ToArray();
        }
        private static List<ushort> listData = new List<ushort>();
        /// <summary>
        /// extracts code byte from receiving messages
        /// </summary>
        /// <param name="recvByte">Received byte</param>
        /// <returns>code registry state of byte type</returns>
        public static Packet Parse(byte[] recvBytes, BytesOrders byteOrder = BytesOrders.LowerByteFirst)
        {
            if (recvBytes == null)
                throw new PacketException(string.Format("Failed parsing recvBytes is null"));
            if (recvBytes.Length < 12)
                throw new PacketException(string.Format("Failed parsing recvBytes length < 12"));

            ushort commandValue = 0;
            listData.Clear();
            int lenData = 0;
            if (prefix != GetUInt16(recvBytes, 0, byteOrder))
                throw new PacketException(string.Format("Failed parsing packet: prefix != {0:X} (data = {1})", prefix, recvBytes.ToString()));

            commandValue = GetUInt16(recvBytes, 2, byteOrder);
            lenData =  GetUInt16(recvBytes, 4, byteOrder);

            //var CrcHeader = GetUInt16(recvBytes, 6, byteOrder);
            //if (CrcHeader != crcHeader)
            //throw new PacketException(string.Format("Failed parsing packet: crcHeader != {0:X} (error: HeaderCRC)", crcHeader));

            for (int i = 0; i < lenData; i+=2)
                listData.Add(GetUInt16(recvBytes, i + 8, byteOrder));

            //var CrcData = GetUInt16(recvBytes, 8 + listData.Count * 2, byteOrder);
            //if (CrcData != crcData)
            //throw new PacketException(string.Format("Failed parsing packet: CrcData != {0:X} (error: DataCRC)", CrcData));

            Packet packet = new Packet(commandValue, listData, byteOrder);
            return packet;
        }
    }


    [Serializable]
    public class PacketException : Exception
    {
        public PacketException() { }
        public PacketException(string message) : base(message) { }
        public PacketException(string message, Exception inner) : base(message, inner) { }
        protected PacketException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

}
