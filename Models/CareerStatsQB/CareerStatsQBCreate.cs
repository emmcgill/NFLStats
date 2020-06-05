using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CareerStatsQBModels
{
    public class CareerStatsQBCreate
    {
        public int PlayerId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "You have to enter at least 1 character.")]
        [MaxLength(40, ErrorMessage = "You entered too many characters.")]
        public string Name { get; set; }
    }
}
