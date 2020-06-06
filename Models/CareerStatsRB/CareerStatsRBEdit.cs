using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CareerStatsRB
{
    public class CareerStatsRBEdit
    {
        public int CareerRBId { get; set; }
        public int PlayerId { get; set; }
        public string Name { get; set; }
    }
}
