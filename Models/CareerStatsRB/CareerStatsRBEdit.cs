using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CareerStatsRB
{
    public class CareerStatsRBEdit
    {
        public int CareerRBId { get; set; }

        public int PlayerId { get; set; }

        public int RushingYards { get; set; }
        public int RushingAttempts { get; set; }
        public int ReceivingYards { get; set; }
        public int Receptions { get; set; }
        public int RushingTouchdowns { get; set; }
        public int ReceivingTouchdowns { get; set; }
        public int Fumbles { get; set; }
    }
}
