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
        [MinLength(4, ErrorMessage = "You have to enter at least 4 characters.")]
        [MaxLength(30, ErrorMessage = "You entered too many characters.")]
        public string PlayerPosition { get; set; }

        public int TotalVotes { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
