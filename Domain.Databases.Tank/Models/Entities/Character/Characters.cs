using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Character
{
    [Table(nameof(Characters), Schema = "Character")]
    public class Characters
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Sex { get; set; }

        public int Xp { get; set; }
        public int Honor { get; set; }

        [ForeignKey(nameof(Ranks))]
        public int? RankId { get; set; }
        public virtual Ranks Rank { get; set; } = null!;

        public int Coins { get; set; }
        public int Gold { get; set; }
        public int Medals { get; set;}
        public int Coupons { get; set; }

        public ICollection<Marriages> Marriages { get; set; } = null!;
        public ICollection<Friends> Friends { get; set; } = null!;
        public ICollection<Disciples> Disciples { get; set; } = null!;
        public ICollection<CharacterItems> Items { get; set; } = null!;

        public DateTime CreationDate { get; set; }

        public int WinnedFights { get; set; }
        public int TotalFights { get; set; }
    }
}
