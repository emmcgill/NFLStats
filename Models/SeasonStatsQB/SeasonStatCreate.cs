using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SeasonStatCreate
    {

        public int PlayerId { get; set; }

        [Required]
        [Range(1996, 2019, ErrorMessage = "Year must be between 1996 & 2019")]
        public int Year { get; set; }
       
        [Required]
        [Range(0, 5477, ErrorMessage = "Passing yardage must be between 0 & 5477")]
        public int PassingYards { get; set; }
       
        [Required]
        [Range(-1000, 1901, ErrorMessage = "Rushing yardage must be between -1000 & 1901")]
        public int RushingYards { get; set; }
      
        [Required]
        [Range(0, 471, ErrorMessage = "Completions must be between 0 & 471")]
        public int Completions { get; set; }
       
        [Required]
        [Range(0, 727, ErrorMessage = "Passing attempts must be between 0 & 727")]
        public int Attempts { get; set; }
       
        [Required]
        [Range(0, 55, ErrorMessage = "Passing touchdowns must be between 0 & 55")]
        public int PassingTouchdowns { get; set; }
       
        [Required]
        [Range(0, 55, ErrorMessage = "Rushing touchdowns must be between 0 & 14")]
        public int RushingTouchdowns { get; set; }
       
        [Required]
        [Range(0, 25, ErrorMessage = "Interceptions must be between 0 & 25")]
        public int Interceptions { get; set; }

        [Required]
        public int PlayerNumber { get; set; }

        [Required]
        public string Team { get; set; }


    }
}
