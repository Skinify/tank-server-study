namespace Shared.DTOs
{
    public class ServerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public int State { get; set; }
        public int? AllowedLevel { get; set; }
        public int Online { get; set; }
    }
}
