using Shared.Config;

namespace API.Config
{
    public class RSA
    {
        public string PublicKey { get; set; } = null!;
        public string PrivateKey { get; set; } = null!;
    }

    public class ApiSettings : DefaultSettings
    {
        public RSA RSA { get; set; } = null!;
       public string CenterWebServerUrl { get; set; } = null!;


        public override void ValidateSettings()
        {
            if(RSA == null)
                throw new InvalidOperationException();

            base.ValidateSettings();
        }
    }
}
