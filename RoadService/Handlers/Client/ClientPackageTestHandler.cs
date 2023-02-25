using Base;
using Base.Interfaces;
using Base.Packets.Base;
using Base.Packets.Client;

namespace RoadService.Handlers.Client
{
    public class ClientPackageTestHandler : BaseHandler, IHandler<ClientPacketOut>
    {
        public ClientPackageTestHandler(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public async Task<ClientPacketOut?> Handle(BasePacketIn packetIn)
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
