using Base.Config;
using System.Net;

namespace CenterService.Config
{
    public class CenterSettings : DefaultSettings
    {
        public string ServerIp { get; set; } = "127.0.0.1";
        public int ServerPort { get; set; } = 9208;
        public IPAddress ServerIpAddress
        {
            get
            {
                if (ServerIp is null)
                    throw new Exception("Fight server IP cannot be null");

                return IPAddress.Parse(ServerIp);
            }
        }

        public string WebServerIp { get; set; } = "127.0.0.1";
        public int WebServerPort { get; set; } = 9212;
        public IPAddress WebServerIpAddress
        {
            get
            {
                if (WebServerIp is null)
                    throw new Exception("Fight server IP cannot be null");

                return IPAddress.Parse(WebServerIp);
            }
        }


        public override void ValidateSettings()
        {
            base.ValidateSettings();
        }
    }
}
