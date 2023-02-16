using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3___Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> plantAndRarity = new Dictionary<string, int>();
            Dictionary<string, List<double>> plantAndRating = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("<->");
                string plant = input[0];
                int rarity = int.Parse(input[1]);
                if (plantAndRarity.ContainsKey(plant))
                {
                    plantAndRarity[plant] = rarity;
                }
                else
                {
                    plantAndRarity.Add(plant, rarity);
                    plantAndRating.Add(plant, new List<double>());
                }
            }
            string command;
            while ((command = Console.ReadLine())!= "Exhibition")
            {
                string[] tokens = command.Split(new string[] { ": "," - " }
                ,StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                if (action == "Rate")
                {
                    string plant = tokens[1];
                    if (plantAndRating.ContainsKey(plant))
                    {
                        double rating = double.Parse(tokens[2]);
                        plantAndRating[plant].Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (action == "Update")
                {
                    string plant = tokens[1];
                    if (plantAndRarity.ContainsKey(plant))
                    {
                        int rarity = int.Parse(tokens[2]);
                        plantAndRarity[plant] = rarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                if (action == "Reset")
                {
                    string plant = tokens[1];
                    if (plantAndRating.ContainsKey(plant))
                    {
                        plantAndRating[plant].Clear();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in plantAndRating)
            {
                if (item.Value.Count == 0)
                {
                    Console.WriteLine($"- {item.Key}; Rarity: {plantAndRarity[item.Key]}; Rating: {0:f2}");
                }
                else
                {
                    Console.WriteLine($"- {item.Key}; Rarity: {plantAndRarity[item.Key]}; Rating: {item.Value.Average():f2}");
                }
            }
        }   
    }
}
