using Base;
using Base.Interfaces;
using Base.Notations;
using Base.Packets.Base;
using Base.Packets.Client;
using RoadService.Handlers.Enums;

namespace RoadService.Handlers.Client
{
    [PacketHandler((int)EClientHandlers.LOGIN)]
    public class LoginHandler : BaseHandler, IHandler<ClientPacketOut>
    {
        public LoginHandler(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public async Task<ClientPacketOut?> Handle(BasePacketIn packetIn)
        {
            var bearerTokenLenght = packetIn.ReadInt(true);
            var berer = packetIn.ReadString(bearerTokenLenght);

            return null;
        }
    }
}
