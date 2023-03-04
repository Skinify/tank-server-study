using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank.Models.Entities.Character
{
    [Table(nameof(MarriageProposals), Schema = "Character")]
    public class MarriageProposals
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Characters))]
        public int FromCharacterId { get; set; }
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Characters FromCharacter { get; set; } = null!;
        
        [ForeignKey(nameof(Characters))]
        public int ToCharacterId { get; set; }
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Characters ToCharacter { get; set; } = null!;

        public string? ProposalSpeech { get; set; }

        public bool? AcceptedProposal { get; set; }

        public DateTime ProposalDate { get; set; }
    }
}
