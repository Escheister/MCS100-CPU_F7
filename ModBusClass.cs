using System.Collections.Generic;
using System.Net.Sockets;
using System.IO.Ports;
using System.Linq;
using System;

namespace MBus
{
    public enum ReadMB : byte { ReadDO = 0x01, ReadDI = 0x02, ReadAO = 0x03, ReadAI = 0x04,  }
    public enum WriteMB : byte { WriteDO = 0x05, WriteAO = 0x06, }
    public enum MultiWriteMB : byte { MWriteDO = 0x0f, MWriteAO = 0x10, }
    public enum Reply
    {
        Ok = 0,
        Null = 1,
        WCrc = 2,
        WSign = 3,
        WCommand = 4,
    }
    public class ModBusClass
    {
        public delegate Tuple<byte[], Reply> HandlerDelegate(byte[] cmdOut);
        public ModBusClass(object dev) { GetTypeDevice(dev); }
        private Socket Sock;
        private SerialPort Port;
        public HandlerDelegate Handler;
        private void GetTypeDevice(object dev)
        {
            if (dev is SerialPort ser)
            {
                Port = ser;
                Handler = WriteMbRtu;
            }
            else if (dev is Socket sock)
            {
                Sock = sock;
                Handler = WriteMbTcp;
            }
        }
        private byte[] ReceiveMbRtu(int length, int ms)
        {
            DateTime t0 = DateTime.Now;
            TimeSpan tstop;
            int bytes = 0;
            try {
                do {
                    bytes = Port.BytesToRead;
                    tstop = DateTime.Now - t0;
                } while (bytes < length && tstop.Milliseconds < ms);
            } catch { }
            if (bytes == 0) return null;
            byte[] buffer = new byte[bytes];
            Port.Read(buffer, 0, bytes);
            return buffer;
        }
        private byte[] ReceiveMbTcp(int length, int ms)
        {
            DateTime t0 = DateTime.Now;
            TimeSpan tstop;
            int bytes = 0;
            try {
                do {
                    bytes = Sock.Available;
                    tstop = DateTime.Now - t0;
                } while (bytes < length && tstop.Milliseconds < ms);
            } catch { }
            if (bytes == 0) return null;
            byte[] buffer = new byte[bytes];
            Sock.Receive(buffer);
            return buffer;
        }
        private Tuple<byte[], Reply> WriteMbRtu(byte[] cmdOut)
        {
            Port.Write(cmdOut, 0, cmdOut.Length);
            byte[] cmdIn = ReceiveMbRtu(GetLength(cmdOut), 250);
            Reply reply = GetReply(cmdOut, cmdIn);
            return Tuple.Create(cmdIn, reply);
        }
        private Tuple<byte[], Reply> WriteMbTcp(byte[] cmdOut)
        {
            Sock.Send(cmdOut);
            byte[] cmdIn = ReceiveMbTcp(GetLength(cmdOut), 250);
            Reply reply = GetReply(cmdOut, cmdIn);
            return Tuple.Create(cmdIn, reply);
        }
        private IEnumerable<byte> ModRTU_CRC(byte[] buf, int len)
        {
            ushort crc = 0xFFFF;
            for (int pos = 0; pos < len; pos++)
            {
                crc ^= buf[pos];
                for (int i = 8; i != 0; i--)
                {
                    if ((crc & 0x0001) != 0)
                    {
                        crc >>= 1;
                        crc ^= 0xA001;
                    }
                    else crc >>= 1;
                }
            }
            return BitConverter.GetBytes(crc);
        }
        private bool CheckCRC(byte[] cmdIn)
        {
            byte[] crcIn = ModRTU_CRC(cmdIn, cmdIn.Length).ToArray();
            return ((crcIn[0] << 8) | crcIn[1]) == 0;
        }
        private IEnumerable<byte> UShortToByteArray(ushort value) => BitConverter.GetBytes(value).Reverse();
        private Reply GetReply(byte[] cmdOut, byte[] cmdIn)
        {
            if (cmdIn == null) return Reply.Null;
            if (!CheckCRC(cmdIn)) return Reply.WCrc;
            if (cmdIn[0] != cmdOut[0]) return Reply.WSign;
            if (cmdIn[1] != cmdOut[1]) return Reply.WCommand;
            return Reply.Ok;
        }
        public byte[] FormatModBusCMD(byte signature, ReadMB cmdMB, ushort startReg, ushort countReg)
        {
            List<byte> bytes = new List<byte>() { signature, (byte)cmdMB };
            bytes.AddRange(UShortToByteArray(startReg));
            bytes.AddRange(UShortToByteArray(countReg));
            bytes.AddRange(ModRTU_CRC(bytes.ToArray(), bytes.Count));
            return bytes.ToArray();
        }
        public byte[] FormatModBusCMD(byte signature, WriteMB cmdMB, ushort startReg, ushort countReg)
        {
            List<byte> bytes = new List<byte>() { signature, (byte)cmdMB };
            bytes.AddRange(UShortToByteArray(startReg));
            bytes.AddRange(UShortToByteArray(countReg));
            bytes.AddRange(ModRTU_CRC(bytes.ToArray(), bytes.Count));
            return bytes.ToArray();
        }
        public byte[] FormatMultiplyDO(byte signature, ushort startReg, ushort countReg, byte byteCount, byte[] valueDO)
        {
            List<byte> bytes = new List<byte>() { signature, (byte)MultiWriteMB.MWriteDO };
            bytes.AddRange(UShortToByteArray(startReg));
            bytes.AddRange(UShortToByteArray(countReg));
            bytes.Add(byteCount);
            bytes.AddRange(valueDO);
            bytes.AddRange(ModRTU_CRC(bytes.ToArray(), bytes.Count));
            return bytes.ToArray();
        }
        public byte[] FormatMultiplyAO(byte signature, ushort startReg, ushort countReg, ushort[] valuesAO)
        {
            List<byte> bytes = new List<byte>() { signature, (byte)MultiWriteMB.MWriteAO };
            bytes.AddRange(UShortToByteArray(startReg));
            bytes.AddRange(UShortToByteArray(countReg));
            bytes.Add((byte)(valuesAO.Length*2));
            foreach (ushort u in valuesAO) bytes.AddRange(UShortToByteArray(u));
            bytes.AddRange(ModRTU_CRC(bytes.ToArray(), bytes.Count));
            return bytes.ToArray();
        }
        private int GetLength(byte[] cmdOut)
        {
            float regUShort = (cmdOut[4] << 8) | cmdOut[5];
            switch (cmdOut[1])
            {
                case 1: case 2: return (int)Math.Ceiling(regUShort / 8)+5;
                case 3: case 4: return (int)(regUShort * 2)+5;
                case 5: case 6: return cmdOut.Length;
                case 15: case 16: return 8;
                default: return 0;
            }
        }
    }
}
