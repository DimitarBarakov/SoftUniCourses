using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> nameAndAge = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ");
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                nameAndAge.Add(name, age);
            }

            string filter = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            if (filter == "older")
            {
                nameAndAge = nameAndAge.Where(p => p.Value >= ageFilter).ToDictionary(x => x.Key, x => x.Value);
            }
            else
            {
                nameAndAge = nameAndAge.Where(p => p.Value < ageFilter).ToDictionary(x => x.Key, x => x.Value);
            }

            string pattern = Console.ReadLine();
            if (pattern == "name age")
            {
                foreach (var person in nameAndAge)
                {
                    Console.WriteLine($"{person.Key} - {person.Value}");
                }
            }
            else if (pattern == "age")
            {
                foreach (var person in nameAndAge)
                {
                    Console.WriteLine($"{person.Value}");
                }
            }
            else if (pattern == "name")
            {
                foreach (var person in nameAndAge)
                {
                    Console.WriteLine($"{person.Key}");
                }
            }
        }
    }
}
