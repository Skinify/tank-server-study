using Base;
using Base.Interfaces;
using Base.Packets.Base;
using Base.Packets.Server;

namespace RoadService.Handlers.Server
{
    public class ServerPackageTestHandler : BaseHandler, IHandler<ServerPacketOut>
    {
        public ServerPackageTestHandler(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public async Task<ServerPacketOut?> Handle(BasePacketIn packetIn)
        {
            //var tank = _serviceProvider.GetRequiredService<TankUnityOfWork>();
            //var serverList = await tank.ServerRepository.GetServerList();
            var @int1 = packetIn.ReadInt(true);
            var @int2 = packetIn.ReadInt(true);
            var @int3StringlENGHT = packetIn.ReadInt(true);
            var @string = packetIn.ReadString(@int3StringlENGHT);

            return null;
        }
    }
}
