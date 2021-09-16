using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class Manager : Employee
    {
        public int Bonus { get; set; } = 100;
        public Manager(string firstName) : base(firstName)
        {
        }

        public Manager(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public Manager(string firstName, string lastName, string jobTitle) : base(firstName, lastName, jobTitle)
        {
        }

        public Manager(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
        }

        public Manager(string firstName, string lastName, int age, Person father, Person mother) : base(firstName, lastName, age, father, mother)
        {
        }

        public override int CalculateYearlySalary()
        {
            return base.CalculateYearlySalary() + Bonus;
        }
    }
}
