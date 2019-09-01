using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                var personInfo = Console.ReadLine()
                    .Split();

                var person = new Person(personInfo[0], personInfo[1], int.Parse(personInfo[2]));

                people.Add(person);
            }

            people.OrderBy(p => p.FirstName)
                 .ThenBy(p => p.Age)
                 .ToList()
                 .ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
