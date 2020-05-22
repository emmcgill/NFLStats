
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CareerStatsTE
{
    public class CareerStatsTEEdit
    {
        public int CareerTEId { get; set; }
        public int PlayerId { get; set; }

        public int Receptions { get; set; }
        public int Targets { get; set; }
        public int Drops { get; set; }
        public int ReceivingYards { get; set; }
        public int YardsAfterCatch { get; set; }
        public int Touchdowns { get; set; }

    }
}
