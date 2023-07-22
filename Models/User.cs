using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteBackend.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Waist { get; set; }
        public double Neck { get; set; }
        public double Hip { get; set; }
        public int Age { get; set; }
        public String AveargeActivityType { get; set; }
        public WeightGoal WeightGoal { get; set; }
        public bool IntialSetup { get; set; }
        public List<Meal> Meals { get; set; }

        public List<Workout> Workouts { get; set; }

    }
}
