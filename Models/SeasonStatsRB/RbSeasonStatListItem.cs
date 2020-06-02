using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SeasonStatsRB
{
    public class RbSeasonStatListItem
    {
        public int Year { get; set; }
        public int RushingYards { get; set; }
        public int RushingAttempts { get; set; }
        public int ReceivingYards { get; set; }
        public int Receptions { get; set; }
        public int RushingTouchdowns { get; set; }
        public int ReceivingTouchdowns { get; set; }
        public int Fumbles { get; set; }
        public int PlayerNumber { get; set; }
        public string Team { get; set; }
    }
}
