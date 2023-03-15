using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Quest
{
    [Table(nameof(Quests), Schema = "Quest")]
    public class Quests
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int MinLevel { get; set; }
        public int? MaxLevel { get; set; }

        [ForeignKey(nameof(Quests))]
        public int? PreQuestId { get; set; }
        public virtual Quests? PreQuest { get; set; }

        public ICollection<Quests> NextQuests { get; set; } = null!;

        /*
        [ForeignKey(nameof(Quests))]
        public int? NextQuestId { get; set; }
        public virtual Quests? NextQuest { get; set; }*/


        public int CoinsReward { get; set; }
        public int GoldReward { get; set; }
        public int MedalsReward { get; set; }
        public int CouponsReward { get; set; }

        public float Rands { get; set; }
        public float RandDouble { get; set; }

        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime MaxFinishTime { get; set; }
    }
}
