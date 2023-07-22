using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteBackend.Models
{
    public class Meal
    {
        public Meal() { }

        public string Id { get; set; }

        public string Name { get; set; }

        public int Calorie { get; set; }

        public int Quantity { get; set; }
    }
}
