using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Battle.PVP
{
    [Table(nameof(PVPGames), Schema = "Battle.PVP")]
    public class PVPGames
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Picture { get; set; } = null!;


        [ForeignKey(nameof(PVPStages))]
        public PVPStages Stage { get; set; } = null!;


        public ICollection<Spaws> CompetitorSpawns { get; set; } = null!;
    }
}
