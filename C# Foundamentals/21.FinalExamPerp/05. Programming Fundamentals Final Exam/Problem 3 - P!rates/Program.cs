using System;
using System.Collections.Generic;

namespace Problem_3___P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> cityPopulationGold = new Dictionary<string, List<int>>();
            string command1;
            while ((command1 = Console.ReadLine()) != "Sail")
            {
                string[] target = command1.Split("||");
                string city = target[0];
                int population = int.Parse(target[1]);
                int gold = int.Parse(target[2]);
                if (cityPopulationGold.ContainsKey(city))
                {
                    cityPopulationGold[city][0] += population;
                    cityPopulationGold[city][1] += gold;
                }
                else
                {
                    cityPopulationGold.Add(city, new List<int> { population, gold });
                }
            }

            string command2;
            while ((command2 = Console.ReadLine()) != "End")
            {
                string[] tokens = command2.Split("=>");
                string action = tokens[0];
                if (action=="Plunder")
                {
                    string town = tokens[1];
                    int population = int.Parse(tokens[2]);
                    int gold = int.Parse(tokens[3]);
                    cityPopulationGold[town][0] -= population;
                    cityPopulationGold[town][1] -= gold;
                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {population} citizens killed.");
                    if (cityPopulationGold[town][0] == 0 || cityPopulationGold[town][1] == 0)
                    {
                        Console.WriteLine($"{town} has been wiped off the map!");
                        cityPopulationGold.Remove(town);
                    }
                }
                else if (action == "Prosper")
                {
                    string town = tokens[1];
                    int gold = int.Parse(tokens[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        cityPopulationGold[town][1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cityPopulationGold[town][1]} gold.");
                    }
                }
            }

            if (cityPopulationGold.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cityPopulationGold.Count} wealthy settlements to go to:");
                foreach (var item in cityPopulationGold)
                {
                    string town = item.Key;
                    int pop = item.Value[0];
                    int gold = item.Value[1];
                    Console.WriteLine($"{town} -> Population: {pop} citizens, Gold: {gold} kg");
                }
            }
        }
    }
}
