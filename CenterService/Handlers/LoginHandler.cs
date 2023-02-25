using Base;
using Base.Interfaces;
using Base.Packets.Base;
using Base.Packets.Client;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;

namespace CenterService.Handlers
{
    [Description("Handle JWT token")]
    public class LoginHandler : BaseHandler, IHandler<ClientPacketOut>
    {
        public LoginHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<ClientPacketOut?> Handle(BasePacketIn packetIn)
        {
            var tokenSize = packetIn.ReadInt();
            var token = packetIn.ReadString(tokenSize);
            var tokenHandler = new JwtSecurityTokenHandler();
            var jsonToken = tokenHandler.ReadJwtToken(token);

            var claims = jsonToken.Claims.FirstOrDefault(r => r.Type == "UserId");
            if (claims is null)
                return null;

            var userId = claims.Value;

            var outPacket = new ClientPacketOut();
            outPacket.WriteInt(2512);
            outPacket.WriteString("dfsdfsdfsdfsdf sd fsd fsdf234 234 3asd3 a3 é ");

            return outPacket;
        }
    }
}
