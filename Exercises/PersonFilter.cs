using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public abstract class PersonFilter
    {
        public abstract bool FilterPredicate(Person person);

        public virtual List<Person> Filter(in List<Person> plist)
        {
            var people = new List<Person>();
            foreach (var person in plist)
            {
                if (FilterPredicate(person))
                {
                    people.Add(person);
                }
            }
            return people;
        }
    }
    public class NameFilter : PersonFilter
    {
        private readonly string name;

        public NameFilter(string name)
        {
            this.name = name;
        }
        public override bool FilterPredicate(Person person)
        {
            return name == person.Name;
        }
    }

    public class AgeFilter : PersonFilter
    {
        private readonly int minimumAge;
        private readonly int maximumAge;

        public AgeFilter(int minimumAge, int maximumAge)
        {
            this.minimumAge = minimumAge;
            this.maximumAge = maximumAge;
        }
        public override bool FilterPredicate(Person person)
        {
            return person.Age <= maximumAge && person.Age >= minimumAge;
        }
    }

    public class EmployeeFilter : PersonFilter
    {
        public override bool FilterPredicate(Person person)
        {
            return person is Employee; 
        }
    }

    public class NotFilter : PersonFilter
    {
        private readonly PersonFilter personFilter;

        public NotFilter(PersonFilter personFilter)
        {
            this.personFilter = personFilter;
        }
        public override bool FilterPredicate(Person person)
        {
            return !personFilter.FilterPredicate(person);
        }
    }

    public class AndFilter : PersonFilter
    {
        private readonly PersonFilter personFilter1;
        private readonly PersonFilter personFilter2;

        public AndFilter(PersonFilter personFilter1, PersonFilter personFilter2)
        {
            this.personFilter1 = personFilter1;
            this.personFilter2 = personFilter2;
        }
        public override bool FilterPredicate(Person person)
        {
            var result = personFilter1.FilterPredicate(person) && personFilter2.FilterPredicate(person);
            return result;
        }
    }

    public class OrFilter : PersonFilter
    {
        private readonly PersonFilter personFilter1;
        private readonly PersonFilter personFilter2;

        public OrFilter(PersonFilter personFilter1, PersonFilter personFilter2)
        {
            this.personFilter1 = personFilter1;
            this.personFilter2 = personFilter2;
        }
        public override bool FilterPredicate(Person person)
        {
            var result = personFilter1.FilterPredicate(person) || personFilter2.FilterPredicate(person);
            return result;
        }
    }

    public class XOrFilter : PersonFilter
    {
        private readonly PersonFilter personFilter1;
        private readonly PersonFilter personFilter2;

        public XOrFilter(PersonFilter personFilter1, PersonFilter personFilter2)
        {
            this.personFilter1 = personFilter1;
            this.personFilter2 = personFilter2;
        }
        public override bool FilterPredicate(Person person)
        {
            var result = personFilter1.FilterPredicate(person) ^ personFilter2.FilterPredicate(person);
            return result;
        }
    }

    abstract class PassThroughFilter : PersonFilter
    {
        public override bool FilterPredicate(Person person)
        {
            return true;
        }
        public override List<Person> Filter(in List<Person> plist)
        {
            foreach (Person person in plist)
                FilterPredicate(person);
            return plist;
        }
    }
}
