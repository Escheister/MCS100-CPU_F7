using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System;

using StaticSettings;
using ProtocolEnums;
using Modbus.Crc;

namespace Modbus.Protocol
{
    public class ModbusProtocol : IDisposable
    {
        public delegate void GetReplyEvent(string msg);
        public event GetReplyEvent ToReply;

        protected delegate void SendDataDelegate(byte[] cmdOut);
        protected delegate Task<byte[]> ReceiveDataDelegate(int length, int ms = 250);

        public ModbusProtocol(object sender) { GetTypeDevice(sender); }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
        }

        protected ReceiveDataDelegate receiveData;
        protected SendDataDelegate sendData;
        private Socket Sock;
        private SerialPort Port;

        private void GetTypeDevice(object dev)
        {
            if (dev is SerialPort ser)
            {
                Port = ser;
                sendData += (byte[] data) => Port.Write(data, 0, data.Length);
                receiveData = SerialReceiveData;
            }
            else if (dev is Socket sock)
            {
                Sock = sock;
                sendData += (byte[] data) => Sock.Send(data);
                receiveData = SocketReceiveData;
            }
        }

        async private Task<byte[]> SerialReceiveData(int length, int ms)
        {
            Stopwatch sw = Stopwatch.StartNew();
            IEnumerable<byte> buffer = new List<byte>();
            byte[] tBuffer;
            ushort crc = 0xffff;
            do
            {
                if (Port.BytesToRead > 0)
                {
                    tBuffer = new byte[Port.BytesToRead];
                    await Port.BaseStream.ReadAsync(tBuffer, 0, tBuffer.Length);
                    buffer = buffer.Concat(tBuffer);
                    crc = ModbusCrc.GetCrc(tBuffer, crc);
                }
            }
            while (sw.ElapsedMilliseconds < ms && crc != 0 && buffer.Count() < length);
            sw.Stop();
            return buffer.ToArray();
        }
        async private Task<byte[]> SocketReceiveData(int length, int ms)
        {
            Stopwatch sw = Stopwatch.StartNew();
            IEnumerable<byte> buffer = new List<byte>();
            ArraySegment<Byte> tBuffer;
            ushort crc = 0xffff;
            do
            {
                if (Sock.Available > 0)
                {
                    tBuffer = new ArraySegment<byte>(new byte[Sock.Available]);
                    await Sock.ReceiveAsync(tBuffer, SocketFlags.None);
                    buffer = buffer.Concat(tBuffer);
                    crc = ModbusCrc.GetCrc(tBuffer.Array, crc);
                }
            }
            while (sw.ElapsedMilliseconds < ms && crc != 0 && buffer.Count() < length);
            sw.Stop();
            return buffer.ToArray();
        }

        async public Task<Tuple<byte[], Reply>> GetData(byte[] cmdOut)
        {
            Options.Token.Token.ThrowIfCancellationRequested();
            sendData(cmdOut);
            Task<byte[]> receiveTask = receiveData(GetLength(cmdOut), 250);
            await Task.WhenAll(receiveTask);
            byte[] cmdIn = receiveTask.Result;
            Reply reply = GetReply(cmdOut, cmdIn);
            ToReply?.Invoke(reply.ToString());
            return new Tuple<byte[], Reply>(cmdIn, reply);
        }


        private IEnumerable<byte> UShortToByteArray(ushort value) => BitConverter.GetBytes(value).Reverse();
        private Reply GetReply(byte[] cmdOut, byte[] cmdIn)
        {
            if (cmdIn.Length == 0) return Reply.Null;
            if (!ModbusCrc.CheckCrc(cmdIn)) return Reply.WCrc;
            if (cmdIn[0] != cmdOut[0]) return Reply.WSign;
            if (cmdIn[1] != cmdOut[1]) return Reply.WCmd;
            return Reply.Ok;
        }
        public byte[] FormatModBusCMD(byte signature, ReadMB cmdMB, ushort startReg, ushort countReg)
        {
            List<byte> bytes = new List<byte>() { signature, (byte)cmdMB };
            bytes.AddRange(UShortToByteArray(startReg));
            bytes.AddRange(UShortToByteArray(countReg));
            bytes.AddRange(ModbusCrc.GetCrcBytes(bytes.ToArray()));
            return bytes.ToArray();
        }
        public byte[] FormatModBusCMD(byte signature, WriteMB cmdMB, ushort startReg, ushort countReg)
        {
            List<byte> bytes = new List<byte>() { signature, (byte)cmdMB };
            bytes.AddRange(UShortToByteArray(startReg));
            bytes.AddRange(UShortToByteArray(countReg));
            bytes.AddRange(ModbusCrc.GetCrcBytes(bytes.ToArray()));
            return bytes.ToArray();
        }
        /*public byte[] FormatMultiplyDO(byte signature, ushort startReg, ushort countReg, byte byteCount, byte[] valueDO)
        {
            List<byte> bytes = new List<byte>() { signature, (byte)MultiWriteMB.MWriteDO };
            bytes.AddRange(UShortToByteArray(startReg));
            bytes.AddRange(UShortToByteArray(countReg));
            bytes.Add(byteCount);
            bytes.AddRange(valueDO);
            bytes.AddRange(ModbusCrc.GetCrcBytes(bytes.ToArray()));
            return bytes.ToArray();
        }*/
        public byte[] FormatMultiplyAO(byte signature, ushort startReg, ushort countReg, ushort[] valuesAO)
        {
            List<byte> bytes = new List<byte>() { signature, (byte)MultiWriteMB.MWriteAO };
            bytes.AddRange(UShortToByteArray(startReg));
            bytes.AddRange(UShortToByteArray(countReg));
            bytes.Add((byte)(valuesAO.Length*2));
            foreach (ushort u in valuesAO) bytes.AddRange(UShortToByteArray(u));
            bytes.AddRange(ModbusCrc.GetCrcBytes(bytes.ToArray()));
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
