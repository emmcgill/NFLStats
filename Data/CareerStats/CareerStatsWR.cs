﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CareerStats
{
    public class CareerStatsWR
    {
        [Key]
        public int CareerWRId { get; set; }

        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }

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
