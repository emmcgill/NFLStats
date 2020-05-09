using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CareerStatsQBModels
{
    public class CareerStatsQBDetail
    {
        public int PlayerId { get; set; }
        
        [Display(Name="Passing Yards")]
        public int PassingYards { get; set; }

        [Display(Name="Rushing Yards")]
        public int RushingYards { get; set; }
        
        public int Completions { get; set; }
        
        public int Attempts { get; set; }

        [Display(Name="Passing Touchdowns")]
        public int PassingTouchdowns { get; set; }

        [Display(Name="Rushing Touchdowns")]
        public int RushingTouchdowns { get; set; }
        
        public int Interceptions { get; set; }

    }
}
