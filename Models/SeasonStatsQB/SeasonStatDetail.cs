using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SeasonStatDetail
    {
        public int SeasonId { get; set; }

        public int PlayerId { get; set; }

        public int Year { get; set; }

        [Display(Name = "Passing Yards")]
        public int PassingYards { get; set; }

        [Display(Name = "Rushing Yards")]
        public int RushingYards { get; set; }

        public int Completions { get; set; }

        public int Attempts { get; set; }

        [Display(Name = "Passing TDs")]
        public int PassingTouchdowns { get; set; }

        [Display(Name = "Rushing TDs")]
        public int RushingTouchdowns { get; set; }

        public int Interceptions { get; set; }

        public int PlayerNumber { get; set; }

        public string Team { get; set; }

    }
}
