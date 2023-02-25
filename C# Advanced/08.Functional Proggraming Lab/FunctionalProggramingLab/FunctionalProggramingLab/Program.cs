using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProggramingLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //zad1
            Console.WriteLine(string.Join(", ",Console.ReadLine().Split(", ").Select(int.Parse).OrderBy(n => n).Where(n => n % 2 == 0).ToList()));

            //zad3
            List<string> words = Console.ReadLine().Split().ToList();
            Predicate<string> isUpper = s => s.Length > 0 && char.IsUpper(s[0]);
            List<string> capitalWords = words.Where(w => isUpper(w)).ToList();
            foreach (string word in capitalWords)
            {
                Console.WriteLine(word);
            }

            //zad4
            List<double> nums = Console.ReadLine().Split(", ").Select(double.Parse).ToList();
            Func<double, double> addVAT = x => x += x / 5;
            nums = nums.Select(addVAT).ToList();
            foreach (double x in nums)
            {
                Console.WriteLine(x.ToString("f2"));
            }

            //zad 5
            int n = int.Parse(Console.ReadLine());

            Dictionary<string,int> nameAndAge = new Dictionary<string,int>();

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
