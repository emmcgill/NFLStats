using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PlayerCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "You have to enter at least 1 character.")]
        [MaxLength(40, ErrorMessage = "You entered too many characters.")]
        public string Name { get; set; }

        [Required]
        public int PlayerNumber { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "You have to enter at least 4 characters.")]
        [MaxLength(30, ErrorMessage = "You entered too many characters.")]
        public string PlayerPosition { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "You have to enter at least 5 characters.")]
        [MaxLength(30, ErrorMessage = "You entered too many characters.")]
        public string Team { get; set; }
    }
}
