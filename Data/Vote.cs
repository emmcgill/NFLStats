using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Vote
    {
        [Key]
        public int VoteId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("Player")]
        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public bool IsDeleted { get; set; }

        public int TotalVotes { get; set; }

        public string Name { get; set; }
    }
}
