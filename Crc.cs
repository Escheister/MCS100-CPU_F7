using System.Collections.Generic;
using System.Linq;
using System;

namespace MBus
{
    public static class ModBusCrc
    {
        private static ushort GetCrc(IEnumerable<byte> buffer, ushort crc)
        {
            for (int pos = 0; pos < buffer.Count(); pos++)
            {
                crc ^= buffer.ElementAt(pos);
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
            return crc;
        }
        public static bool CrcCheck(IEnumerable<byte> buffer, ushort crc = 0xffff)
            => GetCrc(buffer, crc) == 0;
        public static IEnumerable<byte> GetCrcBytes(IEnumerable<byte> buffer, ushort crc = 0xffff)
            => BitConverter.GetBytes(GetCrc(buffer, crc));
    }
}
