using Base.Config;

namespace CenterService.Config
{
    public class CenterSettings : DefaultSettings
    {

        public string[]? ListeningUrls { get; set; }

        public override void ValidateSettings()
        {
            if (ListeningUrls == null)
                throw new Exception("Listening urls cannot be null");

            base.ValidateSettings();
        }
    }
}
