using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ICreature> creatures = new List<ICreature>();
            List<IBirthable> births = new List<IBirthable>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                IBirthable birthable;

                string[] tokens = cmd.Split(' ');
                if (tokens[0] == "Pet")
                {
                    string name = tokens[1];
                    string birthdate = tokens[2];
                    birthable = new Pet(name, birthdate);
                }
                else if (tokens[0] == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthdate = tokens[4];
                    birthable = new Citizen(name, age, id, birthdate);
                }
                else
                {
                    continue;
                }
                births.Add(birthable);
            }

            string birthYear = Console.ReadLine();
            List<IBirthable> birthsWithSpecificBirthdate = new List<IBirthable>();
            birthsWithSpecificBirthdate = births.Where(b => b.Birthdate.Split('/')[2] == birthYear).ToList();
            //foreach (var creature in creatures)
            //{
            //    if (GetIDLastNDigits(creature.Id, fakeIDsLastDigits.Length) == fakeIDsLastDigits)
            //    {
            //        detainedIDs.Add(creature.Id);
            //    }
            //}
            foreach (var birth in birthsWithSpecificBirthdate)
            {
                Console.WriteLine(birth.Birthdate);
            }
        }

        public static string GetIDLastNDigits(string id, int n)
        {
            string lastDigits = id.Substring(id.Length - n, n);
            return lastDigits;
        }
    }
}
