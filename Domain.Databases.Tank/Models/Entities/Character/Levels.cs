using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Character
{
    [Table(nameof(Levels), Schema = "Character")]
    public class Levels
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Level { get; set; }

        [Description("Xp to reach level")]
        public long Xp { get; set; }

        [Description("Blood base on that level")]
        public int Blood { get; set; }
    }
}
