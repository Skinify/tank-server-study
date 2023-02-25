namespace Base.Config
{
    public class DefaultSettings
    {
        public string LanguagePath { get; set; } = string.Empty;
        public string BombsPath { get; set; } = string.Empty;
        public string MapsPath { get; set; } = string.Empty;
        public string RootDirectory { get; set; } = Directory.GetCurrentDirectory();

        public virtual void ValidateSettings()
        {

        }
    }
}
