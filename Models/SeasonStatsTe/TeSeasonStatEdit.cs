using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SeasonStatsTe
{
    public class TeSeasonStatEdit
    {
        public int TeSeasonId { get; set; }

        public int PlayerId { get; set; }

        [Required]
        [Range(1996, 2019, ErrorMessage = "Year must be between 1996 & 2019")]
        public int Year { get; set; }

        [Required]
        [Range(0, 149, ErrorMessage = "Receptions must be between 0 & 149")]
        public int Receptions { get; set; }

        [Required]
        [Range(0, 300, ErrorMessage = "Targets must be between 0 & 300")]
        public int Targets { get; set; }

        [Required]
        [Range(0, 50, ErrorMessage = "Drops must be between 0 & 50")]
        public int Drops { get; set; }

        [Required]
        [Range(0, 1964, ErrorMessage = "Yards must be between 0 & 1964")]
        public int ReceivingYards { get; set; }

        [Required]
        [Range(0, 1500, ErrorMessage = "Yards After Catch must be between 0 & 1500")]
        public int YardsAfterCatch { get; set; }

        [Required]
        [Range(0, 23, ErrorMessage = "Touchdowns must be between 0 & 23")]
        public int Touchdowns { get; set; }

        [Required]
        public int PlayerNumber { get; set; }

        [Required]
        public string Team { get; set; }
    }
}
