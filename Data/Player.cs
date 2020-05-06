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
        public Guid playerId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "You have to enter at least 1 character.")]
        [MaxLength(40, ErrorMessage = "You entered too many characters.")]
        public string name { get; set; }

        [Required]
        public int playerNumber { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "You have to enter at least 4 characters.")]
        [MaxLength(30, ErrorMessage = "You entered too many characters.")]
        public string playerPosition { get; set; }
        
        [Required]
        public int yearsPro { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "You have to enter at least 5 characters.")]
        [MaxLength(30, ErrorMessage = "You entered too many characters.")]
        public string team { get; set; }

        [Required]
        public int numberOfVotes { get; set; }

        [Required]
        public DateTimeOffset createdUtc { get; set; }

        public DateTimeOffset? modifiedUtc { get; set; }
    }
}
