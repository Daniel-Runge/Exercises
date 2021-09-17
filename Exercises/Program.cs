using System;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercise 1.1.c
            var daniel = new Person("daniel", "Petersen", 29)
            {
                Mother = new Person("Inger-Lise", "Petersen", 50, new Person("Anton", "Fiandbo", 67), new Person("Else", "Petersen", 71)),
                Father = new Person("Ole", "Johnsen", 55, new Person("Peter", "Johnsen", 90), new Person("Inga", "Johnsen", 87))
            };
            PersonPrinter.PrintFamilyTree(daniel);
        }
    }
}
