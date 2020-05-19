﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CareerStatsQBModels
{
    public class CareerStatsQBEdit
    {
        public int CareerQBId { get; set; }
        public int PlayerId { get; set; }
        public int PassingYards { get; set; }
        public int RushingYards { get; set; }
        public int Completions { get; set; }
        public int Attempts { get; set; }
        public int PassingTouchdowns { get; set; }
        public int RushingTouchdowns { get; set; }
        public int Interceptions { get; set; }
    }
}
