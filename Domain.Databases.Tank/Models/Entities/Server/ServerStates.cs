using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Server
{
    [Table(nameof(ServerStates), Schema = "Server")]
    public class ServerStates
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string? Description { get; set; }
    }
}
