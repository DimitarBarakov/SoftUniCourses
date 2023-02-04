using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2___Treasure_Hunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> treasure = Console.ReadLine().Split('|').ToList();
            string command;
            while ((command = Console.ReadLine()) != "Yohoho!")
            {
                string[] tokens = command.Split();
                string action = tokens[0];
                if (action == "Loot")
                {
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        if (!treasure.Contains(tokens[i]))
                        {
                            treasure.Insert(0, tokens[i]);
                        }
                    }
                }
                else if (action == "Drop")
                {
                    int index = int.Parse(tokens[1]);
                    if (index >= 0 && index < treasure.Count)
                    {
                        string value = treasure[index];
                        treasure.RemoveAt(index);
                        treasure.Add(value);
                    }
                }
                else if (action == "Steal")
                {
                    int count = int.Parse(tokens[1]);
                    List<string> stolenItems = new List<string>(count);
                    if (count >= treasure.Count)
                    {
                        stolenItems = treasure;
                        Console.WriteLine(string.Join(", ", stolenItems));
                        treasure.Clear();
                    }
                    else
                    {
                        int startIndex = treasure.Count - count;
                        for (int i = startIndex; i < treasure.Count; i++)
                        {
                            stolenItems.Add(treasure[i]);
                            treasure.RemoveAt(i);
                            i--;
                        }
                        Console.WriteLine(string.Join(", ", stolenItems));
                    }
                }
            }
            //Console.WriteLine(String.Join(' ', treasure));
            if (treasure.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                int sumOfItemsLebght = 0;
                for (int i = 0; i < treasure.Count; i++)
                {
                    sumOfItemsLebght += treasure[i].Length;
                }
                double averageGain = sumOfItemsLebght * 1.0 / treasure.Count;
                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }
        }
    }
}
