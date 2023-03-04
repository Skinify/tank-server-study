using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Server
{
    [Table("Servers", Schema = "Server")]
    public class Servers
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Ip { get; set; } = null!;
        public int Port { get; set; }

        [ForeignKey(nameof(ServerStates))]
        public int ServerStateId { get; set; }
        public virtual ServerStates ServerState { get; set; } = null!;

        public int TotalCharacters { get; set; }
        public int TotalRooms { get; set; }
        public string? Remark { get; set; }
        public int? AllowedLevel { get; set; }
    }
}
