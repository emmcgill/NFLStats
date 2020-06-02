using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PlayerListItem
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string PlayerPosition { get; set; }
        public int TotalVotes { get; set; }
    }
}
