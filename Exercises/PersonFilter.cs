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
            var result = new List<Person>();
            foreach (var person in plist)
            {
                if (FilterPredicate(person))
                {
                    result.Add(person);
                }
            }
            return result;
        }
    }
    public class NameFilter : PersonFilter
    {
        private readonly string _name;

        public NameFilter(string name)
        {
            _name = name;
        }
        public override bool FilterPredicate(Person person)
        {
            return _name == person.Name;
        }
    }

    public class AgeFilter : PersonFilter
    {
        private readonly int _minimumAge;
        private readonly int _maximumAge;

        public AgeFilter(int minimumAge, int maximumAge)
        {
            _minimumAge = minimumAge;
            _maximumAge = maximumAge;
        }
        public override bool FilterPredicate(Person person)
        {
            return person.Age <= _maximumAge && person.Age >= _minimumAge;
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
        private readonly PersonFilter _personFilter;

        public NotFilter(PersonFilter personFilter)
        {
            _personFilter = personFilter;
        }
        public override bool FilterPredicate(Person person)
        {
            return !_personFilter.FilterPredicate(person);
        }
    }

    public class AndFilter : PersonFilter
    {
        private readonly PersonFilter _personFilter1;
        private readonly PersonFilter _personFilter2;

        public AndFilter(PersonFilter personFilter1, PersonFilter personFilter2)
        {
            _personFilter1 = personFilter1;
            _personFilter2 = personFilter2;
        }
        public override bool FilterPredicate(Person person)
        {
            var result = _personFilter1.FilterPredicate(person) && _personFilter2.FilterPredicate(person);
            return result;
        }
    }

    public class OrFilter : PersonFilter
    {
        private readonly PersonFilter _personFilter1;
        private readonly PersonFilter _personFilter2;

        public OrFilter(PersonFilter personFilter1, PersonFilter personFilter2)
        {
            _personFilter1 = personFilter1;
            _personFilter2 = personFilter2;
        }
        public override bool FilterPredicate(Person person)
        {
            var result = _personFilter1.FilterPredicate(person) || _personFilter2.FilterPredicate(person);
            return result;
        }
    }

    public class XOrFilter : PersonFilter
    {
        private readonly PersonFilter _personFilter1;
        private readonly PersonFilter _personFilter2;

        public XOrFilter(PersonFilter personFilter1, PersonFilter personFilter2)
        {
            _personFilter1 = personFilter1;
            _personFilter2 = personFilter2;
        }
        public override bool FilterPredicate(Person person)
        {
            var result = _personFilter1.FilterPredicate(person) ^ _personFilter2.FilterPredicate(person);
            return result;
        }
    }

    abstract class PassThroughFilter : PersonFilter
    {
        public override List<Person> Filter(in List<Person> plist)
        {
            foreach (Person person in plist)
                FilterPredicate(person);
            return plist;
        }
    }
}
