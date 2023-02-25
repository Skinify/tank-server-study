using Base.Interfaces;

namespace Base.Packets.Base
{
    public class BasePacket : IPacket
    {
        protected BasePacket()
        {
            Buffer = new byte[1024];
            CurrentOffset = 0;
        }

        public void Fill(byte[] buffer, int lenght)
        {
            if (lenght > Length)
                throw new Exception("Valor do buffer maior que o esperado");

            Array.Copy(buffer, Buffer, lenght);
        }

        public byte[] Buffer { get; set; }
        public int Length { get => Buffer.Length; }
        public int CurrentOffset { get; set; }
        public int DataLeft
        {
            get { return Length - CurrentOffset; }
        }
    }
}
