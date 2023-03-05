using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tank.Models.Entities.Battle.PVE;
using Tank.Models.Entities.Battle.PVP;

namespace Tank.Models.Entities.Battle
{
    [Table(nameof(Spaws), Schema = "Battle")]
    public class Spaws
    {
        [Key]
        public int Id { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        [ForeignKey(nameof(PVPGames))]
        public int? PVPGameId { get; set; }
        public virtual PVPGames? PVPGame {get;set;}

        [ForeignKey(nameof(PVPGames))]
        public int? PVEGameId { get; set; }
        public virtual PVEGames? PVEGame { get; set; }

        [ForeignKey(nameof(NPCs))]
        public int? NPCId { get; set; }
        public virtual NPCs? NPC { get; set; }
    }
}
