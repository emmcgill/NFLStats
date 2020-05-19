using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class VoteListItem
    {
        public DateTimeOffset CreatedUtc { get; set; }

        public int VoteId { get; set; }
    }
}
