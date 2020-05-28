using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CareerStatsWR
{
    public class CareerStatsWRCreate
    {
        public int PlayerId { get; set; }

        [Required]
        public int Receptions { get; set; }
        [Required]
        public int Targets { get; set; }
        [Required]
        public int Drops { get; set; }
        [Required]
        public int ReceivingYards { get; set; }
        [Required]
        public int YardsAfterCatch { get; set; }
        [Required]
        public int Touchdowns { get; set; }
    }
}
