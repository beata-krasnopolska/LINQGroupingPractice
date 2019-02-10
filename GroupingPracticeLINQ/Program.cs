using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupingPracticeLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                new Person() {Name ="Jan", Surname ="Kowalski", Age = 28,Gender= "man"},
                new Person() {Name = "Anna", Surname = "Nowak", Age = 30, Gender = "woman"},
                new Person() {Name ="John", Surname ="Doe", Age = 36, Gender= "man"},
                new Person() {Name ="Joanna", Surname ="Dark", Age =45, Gender= "woman"},
                new Person() {Name ="Mickey", Surname ="Mouse", Age =22, Gender= "woman"},
            };

            Console.WriteLine("Grouping people by gender");
            var genderGroup = from p in people
                              group p by p.Gender;
            var genderGroupLambda = people.GroupBy(p => p.Gender);

            Console.WriteLine("First check by LINQ guery");
            foreach (var per in genderGroup)
            {
                Console.WriteLine($"{per.Key}");
                foreach (var p in per)
                {
                    Console.WriteLine($"    {p.Gender}  {p.Name}");
                }
            }

            Console.WriteLine("Second check by LINQ method");
            foreach (var pers in genderGroupLambda)
            {
                Console.WriteLine($"{pers.Key}");
                foreach (var p in pers)
                {
                    Console.WriteLine($"    {p.Gender}  {p.Name}");
                }
            }
            //-----------------------------------------------------------------------
            Console.WriteLine();
            var ageGrouping = from p in people
                              where p.Age > 30
                              group p by p.Age;

            var ageGroupLambda = people.Where(p => p.Age > 30).GroupBy(p => p.Age);


            Console.WriteLine("Grouping people form the collection by age, assumption age>30");
            Console.WriteLine("First check by LINQ guery");
            foreach (var per in ageGrouping)
            {
                Console.WriteLine($"{per.Key}");
                foreach (var p in per)
                {
                    Console.WriteLine($"    {p.Name}  {p.Age}");
                }
            }

            Console.WriteLine("Second check by LINQ method");
            foreach (var pers in ageGroupLambda)
            {
                Console.WriteLine($"{pers.Key}");
                foreach (var p in pers)
                {
                    Console.WriteLine($"    {p.Name}  {p.Age}");
                }
            }
            //---------------------------------------------------------------------------
            Console.WriteLine();

            var alphabeticalOrder = from p in people
                                    orderby p.Name
                                    group p by p.Name[0];
            var alphabeticalOrderLambda = people.OrderBy(p => p.Name).GroupBy(p => p.Name[0]);

            Console.WriteLine("Grouping people form the collection by first letter of the name");
            Console.WriteLine("First check by LINQ guery");
            foreach (var per in alphabeticalOrder)
            {
                Console.WriteLine($"{per.Key}");
                foreach (var p in per)
                {
                    Console.WriteLine($"    {p.Name}  {p.Surname}");
                }
            }

            Console.WriteLine("Second check by LINQ method");
            foreach (var pers in alphabeticalOrderLambda)
            {
                Console.WriteLine($"{pers.Key}");
                foreach (var p in pers)
                {
                    Console.WriteLine($"    {p.Name}  {p.Surname}");
                }                
            }

            Console.ReadKey();
        }
    }
}
