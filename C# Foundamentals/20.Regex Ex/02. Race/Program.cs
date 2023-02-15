using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> racers = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string, int> namesAndTIme = new Dictionary<string, int>();
            string input;
            while ((input = Console.ReadLine())!= "end of race")
            {
                string name = "";
                int kilo = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    if (char.IsLetter(input[i]))
                    {
                        name += input[i];
                    }
                    else if (char.IsDigit(input[i]))
                    {
                        kilo += (int)(input[i] - '0');
                    }
                }
                if (racers.Contains(name))
                {
                    if (namesAndTIme.ContainsKey(name))
                    {
                        namesAndTIme[name] += kilo;
                    }
                    else
                    {
                        namesAndTIme.Add(name, kilo);
                    }
                }
            }
            var ordered = namesAndTIme.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"1st place: {ordered.ElementAt(0).Key}");
            Console.WriteLine($"2nd place: {ordered.ElementAt(1).Key}");
            Console.WriteLine($"3rd place: {ordered.ElementAt(2).Key}");
        }
    }
}
