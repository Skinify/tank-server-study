using Shared.Config;
using System.Net;

namespace RoadService.Config
{
    public class RoadSettings : DefaultSettings
    {
        public string ServerIp { get; set; } = "127.0.0.1";
        public int ServerPort { get; set; } = 9200;
        public IPAddress ServerIpAddress
        {
            get
            {
                if (ServerIp is null)
                    throw new Exception("Fight server IP cannot be null");

                return IPAddress.Parse(ServerIp);
            }
        }

        public string FightServerIp { get; set; } = "127.0.0.1";
        public int FightServerPort { get; set; } = 9207;

        public string CenterWebServerUrl { get; set; } = "http://127.0.0.1:2008/";

        public string ServerName { get; set; } = "Server de teste 1";
        public int? AllowedLevel { get; set; }
        public int MaxPlayers { get; set; }

        public string RSAPublicKey { get; set; } = null!;
        /*
        public string RSAValidIssuer { get; set; } = null!;
        public string RSAValidAudience { get; set; } = null!;
        */

        public override void ValidateSettings()
        {

        }
    }
}
