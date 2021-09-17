using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class Person
    {
        // Exercise 1.3
        static int nextID = 1;
        public int PersonID { get; private set; }
        // Exercise 1.1.a and 1.1.b
        private string _firstName;
        private string _lastName;
        private int _age;
        private Person _mother;
        private Person _father;
        public string Name
        {
            get => $"{FirstName} {LastName}";
            set
            {
                string[] names;
                names = value.Split(' ');
                if (names.Length != 2)
                {
                    throw new ArgumentException($"Assigned value {nameof(value)} is invalid");
                }
                FirstName = names[0];
                LastName = names[1];
            }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(value)} can't be below 0.");
                }
                _age = value;
            }
        }


        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value.Length <= 0) throw new ArgumentException($"{nameof(value)} is too short.");
                _lastName = char.ToUpper(value[0]) + value[1..];
            }
        }


        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value.Length <= 0) throw new ArgumentException($"{nameof(value)} is too short.");
                _firstName = char.ToUpper(value[0]) + value[1..];
            }
        }
        // Exercise 1.2
        public Person(string firstName)
        {
            PersonID = nextID;
            nextID++;
            FirstName = firstName;
        }

        public Person(string firstName, string lastName) : this(firstName)
        {
            LastName = lastName;
        }
        public Person(string firstName, string lastName, int age) : this(firstName, lastName)
        {
            Age = age;
        }

        public Person(string firstName, string lastName, int age, Person father, Person mother) : this(firstName, lastName, age)
        {
            Father = father;
            Mother = mother;
        }

        public Person Father
        {
            get => _father;
            set => _father = value;
        }


        public Person Mother
        {
            get => _mother;
            set => _mother = value;
        }
    }
}
