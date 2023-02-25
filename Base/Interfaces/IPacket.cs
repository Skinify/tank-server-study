namespace Base.Interfaces
{
    public interface IPacket
    {
        public byte[] Buffer { get; set; }
        public int Length { get; }
        public int CurrentOffset { get; set; }
        public void Fill(byte[] buffer, int lenght);
    }
}
