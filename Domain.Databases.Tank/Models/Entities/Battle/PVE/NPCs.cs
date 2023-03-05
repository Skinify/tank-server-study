using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Battle.PVE
{
    [Table(nameof(NPCs), Schema = "Battle.PVE")]
    public class NPCs
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Blood { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Agility { get; set; }
        public int Luck { get; set; }
        public int Hp { get; set; }
        public int Damage { get; set; }
        public int Guard { get; set; }
        public int Xp { get; set; }

        public int? AttackRange { get; set; }
        public int MoveMax { get; set; }
        public int MoveMin { get; set; }
        public int MoveSpeed { get; set; }

        public ICollection<Spaws> Spaws { get; set; } = null!;
    }
}
