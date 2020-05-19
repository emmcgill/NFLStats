using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CareerStatsQB
    {
        [Key]
        public int CareerStatsQbId { get; set; }

        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }

        
        [Required]
        public int PassingYards { get; set; }

        [Required]
        public int RushingYards { get; set; }

        [Required]
        public int Completions { get; set; }

        [Required]
        public int Attempts { get; set; }
        
        [Required]
        public int PassingTouchdowns { get; set; }

        [Required]
        public int RushingTouchdowns { get; set; }

        [Required]
        public int Interceptions { get; set; }

        
    }
}
