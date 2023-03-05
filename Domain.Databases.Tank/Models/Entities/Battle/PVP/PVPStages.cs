using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Battle.PVP
{
    [Table(nameof(PVPStages), Schema = "Battle.PVP")]
    public class PVPStages
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey(nameof(StageTypes))]
        public int RoomTypesId { get; set; }
        public StageTypes RoomType { get; set; } = null!;


        [ForeignKey(nameof(Maps))]
        public int MapId { get; set; }
        public Maps Maps { get; set; } = null!;


        public string Picture { get; set; } = null!;
    }
}
