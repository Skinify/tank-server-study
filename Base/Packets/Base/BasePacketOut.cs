using System.Text;

namespace Base.Packets.Base
{
    public abstract class BasePacketOut : BasePacket
    {
        public BasePacketOut() { }
        public virtual void WriteBoolean(bool val)
        {
            Buffer[CurrentOffset++] = val ? (byte)1 : (byte)0;
        }

        public virtual void WriteByte(byte val)
        {
            Buffer[CurrentOffset++] = val;
        }

        public virtual void Write(byte[] src)
        {
            Write(src, 0, src.Length);
        }

        public virtual void Write(byte[] src, int offset, int len)
        {
            Array.Copy(src, offset, Buffer, CurrentOffset, len);
            CurrentOffset += len;
        }

        public virtual void WriteShort(short val)
        {
            WriteByte((byte)(val >> 8));
            WriteByte((byte)(val & 0xff));
        }

        public virtual void WriteShortLowEndian(short val)
        {
            WriteByte((byte)(val & 0xff));
            WriteByte((byte)(val >> 8));
        }

        public virtual void WriteInt(int val)
        {
            WriteByte((byte)(val >> 24));
            WriteByte((byte)(val >> 16 & 0xff));
            WriteByte((byte)((val & 0xffff) >> 8));
            WriteByte((byte)(val & 0xffff & 0xff));
        }

        public virtual void WriteFloat(float val)
        {
            byte[] src = BitConverter.GetBytes(val);
            Write(src);
        }

        public virtual void WriteDouble(double val)
        {
            byte[] src = BitConverter.GetBytes(val);
            Write(src);
        }

        public virtual void WriteString(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            WriteInt(str.Length);
            Write(bytes);
        }

        public void WriteDateTime(DateTime date)
        {
            WriteShort((short)date.Year);
            WriteByte((byte)date.Month);
            WriteByte((byte)date.Day);
            WriteByte((byte)date.Hour);
            WriteByte((byte)date.Minute);
            WriteByte((byte)date.Second);
        }

    }
}
