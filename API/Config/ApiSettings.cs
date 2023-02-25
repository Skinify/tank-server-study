namespace API.Config
{
    public class RSA
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
    }

    public class ApiSettings
    {
        public RSA RSA { get; set; }
        public string CenterWebServerUrl { get; set; }
    }
}
