using Base.Packets.Base;

namespace Base.Interfaces
{
    public interface IHandler<T>
    {
        Task<T?> Handle(BasePacketIn packetIn);
    }
}
