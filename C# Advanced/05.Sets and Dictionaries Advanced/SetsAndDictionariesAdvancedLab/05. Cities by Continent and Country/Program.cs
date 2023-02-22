using System;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string,List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string continent = input[0];
                string country = input[1];  
                string city = input[2];
                if (continents.ContainsKey(continent))
                {
                    if (continents[continent].ContainsKey(country))
                    {
                        continents[continent][country].Add(city);
                    }
                    else
                    {
                        continents[continent].Add(country, new List<string> { city});
                    }
                }
                else
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                    continents[continent].Add(country, new List<string> { city });
                }
            }
            foreach (var continent in continents)
            {
                Console.WriteLine(continent.Key+":");
                Dictionary<string, List<string>> countriesAndCities = continent.Value;
                foreach (var item in countriesAndCities)
                {
                    Console.WriteLine($"  {item.Key} -> {string.Join(", ",item.Value)}");
                }
            }
        }
    }
}
