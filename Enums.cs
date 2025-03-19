namespace ProtocolEnums
{
    enum REnum { Year, Month, Day, Hour, Minute, Second, Set, }
    enum CEnum { register, field, ReadAI, ReadWriteAO, }
    public enum ReadMB : byte { ReadDO = 0x01, ReadDI = 0x02, ReadAO = 0x03, ReadAI = 0x04, }
    public enum WriteMB : byte { WriteDO = 0x05, WriteAO = 0x06, }
    public enum MultiWriteMB : byte { MWriteDO = 0x0f, MWriteAO = 0x10, }
    public enum Reply
    {
        Ok = 0,
        Null = 1,
        WCrc = 2,
        WSign = 3,
        WCmd = 4,
    }
}
