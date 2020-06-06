using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CareerStatsWR
{
    public class CareerStatsWREdit
    {
        public int CareerWRId { get; set; }

        public int PlayerId { get; set; }

        public string Name { get; set; }
    }
}
