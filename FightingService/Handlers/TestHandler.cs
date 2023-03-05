using Base;
using Base.Interfaces;
using Base.Packets.Base;
using Base.Packets.Server;
using Microsoft.Extensions.DependencyInjection;
using Tank.Unity;

namespace FightingService.Handlers
{
    public class TestHandler : BaseHandler, IHandler<ServerPacketOut>
    {
        public TestHandler(IServiceProvider serviceProvider) : base(serviceProvider) {  }

        public async Task<ServerPacketOut?> Handle(BasePacketIn packetIn)
        {
            var tank = _serviceProvider.GetRequiredService<TankUnityOfWork>();
            var @int1 = packetIn.ReadInt();
            var @int2 = packetIn.ReadInt();
            var @int3StringlENGHT = packetIn.ReadInt();
            var @string = packetIn.ReadString(@int3StringlENGHT);

            return null;
        }
    }
}
