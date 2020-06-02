using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SeasonStatsRB
{
    public class RbSeasonStatCreate
    {
        public int PlayerId { get; set; }

        [Required]
        [Range(1996, 2019, ErrorMessage = "Year must be between 1996 & 2019")]
        public int Year { get; set; }

        [Required]
        [Range(-1000, 2105, ErrorMessage = "Rushing yardage must be between -1000 & 2105")]
        public int RushingYards { get; set; }
        [Required]
        [Range(0, 416, ErrorMessage = "Rushing attempts must be between 0 & 416")]
        public int RushingAttempts { get; set; }
        [Required]
        [Range(-1000, 1048, ErrorMessage = "Receiving yardage must be between -1000 & 1048")]
        public int ReceivingYards { get; set; }
        [Required]
        [Range(0, 107, ErrorMessage = "Receptions must be between 0 & 107")]
        public int Receptions { get; set; }
        [Required]
        [Range(0, 28, ErrorMessage = "Rushing Touchdowns must be between 0 & 28")]
        public int RushingTouchdowns { get; set; }
        [Required]
        [Range(0, 28, ErrorMessage = "Receiving Touchdowns must be between 0 & 23")]
        public int ReceivingTouchdowns { get; set; }
        [Required]
        [Range(0, 23, ErrorMessage = "Fumbles must be between 0 & 23")]
        public int Fumbles { get; set; }
        [Required]
        public int PlayerNumber { get; set; }
        [Required]
        public string Team { get; set; }
    }
}
