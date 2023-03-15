using Base;
using Base.Interfaces;
using Base.Notations;
using Base.Packets.Base;
using Base.Packets.Server;
using RoadService.Handlers.Enums;

namespace RoadService.Handlers.Server
{
    [PacketHandler((int)EServerHandlers.PING)]
    public class ServerPackageTestHandler : BaseHandler, IHandler<ServerPacketOut>
    {
        public ServerPackageTestHandler(IServiceProvider serviceProvider, string clientId, Action<IPacket> sendData) : base(serviceProvider, clientId, sendData) { }

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
