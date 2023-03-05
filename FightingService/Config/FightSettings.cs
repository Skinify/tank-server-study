using Shared.Config;
using System.Net;

namespace FightingService.Config
{
    public class FightSettings : DefaultSettings
    {
        public string ServerIp { get; set; } = "127.0.0.1";
        public int ServerPort { get; set; } = 9207;
        public IPAddress ServerIpAddress
        {
            get
            {
                if (ServerIp is null)
                    throw new Exception("Fight server IP cannot be null");

                return IPAddress.Parse(ServerIp);
            }
        }

        public string CenterWebServerUrl { get; set; } = "http://127.0.0.1:2008/";
    }
}
