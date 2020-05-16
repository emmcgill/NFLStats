using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SeasonStatsRB
{
    public class RbSeasonStatDetail
    {
        public int RbSeasonId { get; set; }

        public int PlayerId { get; set; }

        public int Year { get; set; }

        [Display(Name = "Rushing Yards")]
        public int RushingYards { get; set; }

        [Display(Name = "Rushing Attempts")]
        public int RushingAttempts { get; set; }

        [Display(Name = "Receiving Yards")]
        public int ReceivingYards { get; set; }

        public int Receptions { get; set; }

        [Display(Name = "Rushing Touchdowns")]
        public int RushingTouchdowns { get; set; }

        [Display(Name = "Receiving Touchdowns")]
        public int ReceivingTouchdowns { get; set; }

        public int Fumbles { get; set; }
    }
}
