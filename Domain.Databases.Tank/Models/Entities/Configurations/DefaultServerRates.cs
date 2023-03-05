using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Configurations
{
    [Table(nameof(DefaultServerRates), Schema = "Configurations")]
    public class DefaultServerRates
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public double Rate { get; set; }

        public DateTime AddDate { get; set; }

        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }


        [ForeignKey(nameof(RateTypes))]
        public int RateTypeId { get; set; }
        public RateTypes RateType { get; set; } = null!;
    }
}
