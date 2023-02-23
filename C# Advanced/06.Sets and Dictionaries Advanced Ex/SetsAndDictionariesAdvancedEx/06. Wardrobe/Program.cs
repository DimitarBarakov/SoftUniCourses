using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Dictionary<string,int>> wardrobe = new Dictionary<string,Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                string[] colthes = input[1].Split(',');
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                foreach (var clothe in colthes)
                {
                    if (!wardrobe[color].ContainsKey(clothe))
                    {
                        wardrobe[color].Add(clothe, 0);
                    }
                    wardrobe[color][clothe]++;
                }
            }
            string[] searching = Console.ReadLine().Split();
            string searchingColor = searching[0];
            string searchingClothe = searching[1];
            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var clothe in color.Value)
                {
                    Console.Write($"* {clothe.Key} - {clothe.Value}");
                    if (color.Key == searchingColor && clothe.Key == searchingClothe)
                    {
                        Console.Write(" (found!)");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
