namespace Shared.Config
{
    public class DefaultSettings
    {
        /*public string LanguagePath { get; set; } = string.Empty;
        public string BombsPath { get; set; } = string.Empty;
        public string MapsPath { get; set; } = string.Empty;
        public string RootDirectory { get; set; } = Directory.GetCurrentDirectory();*/

        public string? Seq { get; set; }

        public virtual void ValidateSettings()
        {

        }
    }
}
