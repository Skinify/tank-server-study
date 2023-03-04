namespace Shared.DTOs.Internal
{
    public class ServerDTO
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Ip { get; set; } = null!;
        public int MaxPlayers { get; set; }
        public int Port { get; set; }
        public int State { get; set; }
        public int? AllowedLevel { get; set; }
        public int Online { get; set; }
    }
}
