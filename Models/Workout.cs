using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteBackend.Models
{
    public class Workout
    {
        public Workout() { }

        public string Id { get; set; }

        public string Name { get; set; }

        public int Calorie { get; set; }

        public int Time { get; set; }
    }
}
