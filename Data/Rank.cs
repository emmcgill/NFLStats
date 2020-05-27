using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Rank
    {
        [Key]
        public int RankId { get; set; }

        public string Name { get; set; }
        
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        [ForeignKey("Player")]
        public int PlayerId { get; set; }

        public Player Player { get; set; }

        [ForeignKey("Vote")]
        public int VoteId { get; set; }

        public Vote Vote { get; set; }
    }
}
