using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteBackend.Models
{
    public class WeightGoal
    {
        public WeightGoal() { }
        public int Weight { get; set; }
        public double StartingDate { get; set; }
        public int Days { get; set; }
    }
}
