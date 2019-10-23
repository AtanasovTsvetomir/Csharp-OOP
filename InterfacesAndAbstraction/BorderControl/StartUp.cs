using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl
{
    public class StartUp
    {
        public static List<string> birthdays;

        static void Main(string[] args)
        {
            string input = string.Empty;

            birthdays = new List<string>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] line = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = line[0];

                if (type == "Citizen")
                {
                    string name = line[1];
                    int age = int.Parse(line[2]);
                    string id = line[3];
                    string birthday = line[4];
                    ICitizen citizen = new Control(name, age, id, birthday);
                    birthdays.Add(citizen.Birthday);
                }
                else if (type == "Pet")
                { 
                    string name = line[1];
                    string birthday = line[2];
                    IPet pet = new Control(name, birthday);
                    birthdays.Add(pet.Birthday);
                }
            }

            string birthdayFilter = Console.ReadLine();
            Console.WriteLine(GetFakeId(birthdayFilter));
        }

        public static string GetFakeId(string birthdayFilter)
        {
            StringBuilder sb = new StringBuilder();
            List<string> birthdaysList = birthdays.Where(x => x.EndsWith(birthdayFilter)).ToList();

            foreach (var birthday in birthdaysList)
            {
                sb.AppendLine(birthday);
                //sb.AppendLine(Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
