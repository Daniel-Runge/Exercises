using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class PersonPrinter
    {
        // Exercise 1.1.d
        public static void PrintPerson(Person person)
        {
            Console.WriteLine($"{person.Name}, {person.Age}, with ID: {person.PersonID}");
        }

        public static void PrintFamilyTree(Person person)
        {
            Console.WriteLine($"The family tree of:");
            List<Person> family = GenerateFamilyTree(person, new List<Person>());

            foreach (var member in family)
            {
                PrintPerson(member);
            }
        }

        private static List<Person> GenerateFamilyTree(Person person, List<Person> family)
        {
            if (person is null)
            {
                return family;
            }
            family.Add(person);
            GenerateFamilyTree(person.Father, family);
            GenerateFamilyTree(person.Mother, family);
            return family;
        }
    }
}
