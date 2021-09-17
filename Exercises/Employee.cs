using System;

namespace Exercises
{
    public class Employee : Person
    {
        private string _jobTitle;
        private int _salary;
        private int _seniority;

        public int Seniority
        {
            get => _seniority;
            set
            {
                if (value is < 0 or > 10)
                {
                    throw new ArgumentException($"{nameof(value)} must be between 1 and 10.");
                }
                _seniority = value;
            }
        }

        public int Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }


        public string JobTitle
        {
            get { return _jobTitle; }
            set { _jobTitle = value; }
        }

        public Employee(string firstName) : base(firstName)
        {
        }

        public Employee(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public Employee(string firstName, string lastName, string jobTitle) : base(firstName, lastName)
        {
            JobTitle = jobTitle;
        }

        public Employee(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
        }

        public Employee(string firstName, string lastName, int age, Person father, Person mother) : base(firstName, lastName, age, father, mother)
        {
        }

        public virtual int CalculateYearlySalary()
        {
            return (int)(Salary *(12 + 1.2M * Seniority));
        }
    }
}
