using Base;
using Base.Interfaces;
using Base.Notations;
using Base.Packets.Base;
using Base.Packets.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using RoadService.Config;
using RoadService.Handlers.Enums;
using RoadService.Managers;
using System.IdentityModel.Tokens.Jwt;

namespace RoadService.Handlers.Client
{
    [PacketHandler((int)EClientHandlers.LOGIN)]
    public class LoginHandler : BaseHandler, IHandler<ClientPacketOut>
    {
        public LoginHandler(IServiceProvider serviceProvider, string socketId, Action<IPacket> sendData) : base(serviceProvider, socketId, sendData) { }

        public async Task<ClientPacketOut?> Handle(BasePacketIn packetIn)
        {
            var bearerTokenLenght = packetIn.ReadInt(false);
            var bearer = packetIn.ReadString(bearerTokenLenght);

            var settings = _serviceProvider.GetRequiredService<RoadSettings>();

            using (var tr = new StringReader(settings.RSAPublicKey))
            {
                var pemReader = new PemReader(tr);
                RsaKeyParameters? publicKeyParams = pemReader.ReadObject() as RsaKeyParameters;
                if (publicKeyParams == null)
                {
                    var @out = new ClientPacketOut();
                    @out.WriteBoolean(false);
                    return @out;
                }

                var rsaParams = DotNetUtilities.ToRSAParameters(publicKeyParams);

                var validationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    RequireSignedTokens = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = false,
                    IssuerSigningKey = new RsaSecurityKey(rsaParams)
                };

                var handler = new JwtSecurityTokenHandler();
                handler.ValidateToken(bearer, validationParameters, out _);
                var jsonToken = handler.ReadToken(bearer) as JwtSecurityToken;
                var userId = jsonToken.Claims.First(claim => claim.Type == "UserId").Value;

                var clientManager = _serviceProvider.GetRequiredService<ConnectedClientsManager>();
                if (clientManager.CheckClientIsConnected(_socketId))
                    return null;

                clientManager.AddClient(new GameClient.Client(_socketId, Convert.ToInt32(userId), _sendData));

                var pkg = new ClientPacketOut();
                pkg.WriteInt(1);
                pkg.WriteString("deu bom");
                return pkg;
            }
        }
    }
}
