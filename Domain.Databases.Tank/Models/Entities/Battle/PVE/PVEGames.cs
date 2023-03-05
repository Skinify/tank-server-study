using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Battle.PVE
{
    [Table(nameof(PVEGames), Schema = "Battle.PVE")]
    public class PVEGames
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int MinLevel { get; set; }
        public string Picture { get; set; } = null!;

        public ICollection<PVEStages> Stages { get; set; } = null!;
        public ICollection<Spaws> AdventuresSpawns { get; set; } = null!;
    }
}
