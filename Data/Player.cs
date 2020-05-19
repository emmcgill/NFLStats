using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

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
        
        public int YearsPro { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "You have to enter at least 5 characters.")]
        [MaxLength(30, ErrorMessage = "You entered too many characters.")]
        public string Team { get; set; }

        public int NumberOfVotes { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
