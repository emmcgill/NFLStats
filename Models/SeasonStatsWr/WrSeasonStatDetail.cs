using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SeasonStatsWr
{
    public class WrSeasonStatDetail
    {
        public int WrSeasonId { get; set; }

        public int PlayerId { get; set; }

        public int Year { get; set; }

        public int Receptions { get; set; }

        public int Targets { get; set; }

        public int Drops { get; set; }

        [Display(Name = "Receiving Yards")]
        public int ReceivingYards { get; set; }

        [Display(Name = "Yards After Catch")]
        public int YardsAfterCatch { get; set; }

        public int Touchdowns { get; set; }

        public int PlayerNumber { get; set; }

        public string Team { get; set; }
    }
}
