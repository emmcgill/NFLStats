using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RankCreate
    {
        public int RankId { get; set; }

        public int PlayerId { get; set; }

        public int NumberOfVotes { get; set; }
    }
}
