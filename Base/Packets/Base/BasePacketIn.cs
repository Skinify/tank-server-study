using System.Text;

namespace Base.Packets.Base
{
    public abstract class BasePacketIn : BasePacket
    {
        public BasePacketIn() { }

        private const int DEFAULT_INT_SIZE = 4;
        private const int DEFAULT_SHORT_SIZE = 2;
        private const int DEFAULT_FLOAT_SIZE = 4;
        private const int DEFAULT_DOUBLE_SIZE = 8;

        public bool ReadBoolean()
        {
            return Buffer[CurrentOffset++] != 0;
        }

        public byte ReadByte()
        {
            return Buffer[CurrentOffset++];
        }

        public short ReadShort(bool shift = false)
        {
            return BitConverter.ToInt16(ReadBytes(DEFAULT_SHORT_SIZE));
        }

        public int ReadInt(bool shift = false)
        {
            return BitConverter.ToInt32(ReadBytes(DEFAULT_INT_SIZE, shift), 0);
        }

        public float ReadFloat(bool shift = false)
        {
            return BitConverter.ToSingle(ReadBytes(DEFAULT_FLOAT_SIZE, shift), 0);
        }

        public double ReadDouble(bool shift = false)
        {
            return BitConverter.ToDouble(ReadBytes(DEFAULT_DOUBLE_SIZE, shift), 0);
        }

        public string ReadString(int len, bool shift = false)
        {
            var bytes = ReadBytes(len, shift);
            string temp = Encoding.UTF8.GetString(bytes);
            return temp.Replace("\0", "");
        }

        private byte[] ReadBytes(int maxLen, bool shift = false)
        {
            byte[] data = new byte[maxLen];
            Array.Copy(Buffer, CurrentOffset, data, 0, maxLen);
            CurrentOffset += maxLen;
            if(shift)
                Array.Reverse(data);
            return data;
        }

        public DateTime ReadDateTime(bool shift = false)
        {
            return new DateTime(ReadShort(shift), ReadByte(), ReadByte(), ReadByte(), ReadByte(), ReadByte());
        }
    }
}
