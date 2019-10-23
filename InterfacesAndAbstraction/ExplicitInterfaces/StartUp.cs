using System;
using System.Collections.Generic;
using System.Linq;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        private static List<Citizen> citizens;

        static void Main(string[] args)
        {
            citizens = new List<Citizen>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] lineTokens = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Citizen citizen = CreateCitizen(lineTokens);

                citizens.Add(citizen);

                line = Console.ReadLine();
            }

            PrintOutput();
        }

        private static void PrintOutput()
        {
            foreach (var citizen in citizens)
            {
                if (citizen is IPerson castedPerson)
                {
                    Console.WriteLine(castedPerson.GetName());
                }

                if (citizen is IResident castedResident)
                {
                    Console.WriteLine(castedResident.GetName());
                }
            }
        }

        private static Citizen CreateCitizen(string[] lineTokens)
        {
            string name = lineTokens[0];
            string country = lineTokens[1];
            int age = int.Parse(lineTokens[2]);
            var citizen = new Citizen(name, country, age);
            return citizen;
        }
    }
}
