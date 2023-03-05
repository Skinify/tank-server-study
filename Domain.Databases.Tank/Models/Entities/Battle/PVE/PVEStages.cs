using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Battle.PVE
{
    [Table(nameof(PVEStages), Schema = "Battle.PVE")]
    public class PVEStages
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey(nameof(PVEGames))]
        public int? PVEId { get; set; }
        public virtual PVEGames? PVE { get; set; }


        [ForeignKey(nameof(StageTypes))]
        public int RoomTypesId { get; set; }
        public StageTypes RoomType { get; set; } = null!;


        [ForeignKey(nameof(RoomDifficultyTypes))]
        public int RoomDifficultyTypesId { get; set; }
        public PVEDifficultyTypes RoomDifficultyTypes { get; set; } = null!;


        [ForeignKey(nameof(Maps))]
        public int MapId { get; set; }
        public Maps Maps { get; set; } = null!;

        public string Picture { get; set; } = null!;

        public int RecommendedStartLevel { get; set; }
        public int RecommendedEndLevel { get; set; }
    }
}
