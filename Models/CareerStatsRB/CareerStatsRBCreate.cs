﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CareerStatsRB
{
    public class CareerStatsRBCreate
    {
        public int PlayerId { get; set; }
                
        [Required]
        public int RushingYards { get; set; }
        [Required]
        public int RushingAttempts { get; set; }
        [Required]
        public int ReceivingYards { get; set; }
        [Required]
        public int Receptions { get; set; }
        [Required]
        public int RushingTouchdowns { get; set; }
        [Required]
        public int ReceivingTouchdowns { get; set; }
        [Required]
        public int Fumbles { get; set; }
    }
}