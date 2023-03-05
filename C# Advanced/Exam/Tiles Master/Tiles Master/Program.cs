using System;
using System.Collections.Generic;
using System.Linq;

namespace Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whiteAreas = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            Queue<int> greyAreas = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());

            Dictionary<string,int> locations = new Dictionary<string,int>();
            locations.Add("Sink", 0);
            locations.Add("Oven", 0);
            locations.Add("Countertop", 0);
            locations.Add("Wall", 0);
            locations.Add("Floor", 0);

            while (whiteAreas.Count > 0 && greyAreas.Count > 0)
            {
                int currWhiteArea = whiteAreas.Peek();
                int currGreyArea = greyAreas.Peek();

                if (currGreyArea == currWhiteArea)
                {
                    int sum = currWhiteArea + currGreyArea;
                    switch (sum)
                    {
                        case 40: locations["Sink"]++; break;
                        case 50: locations["Oven"]++; break;
                        case 60: locations["Countertop"]++; break;
                        case 70: locations["Wall"]++; break;
                        default:locations["Floor"]++;break;
                    }
                    whiteAreas.Pop();
                    greyAreas.Dequeue();
                }
                else
                {
                    currWhiteArea /= 2;
                    whiteAreas.Pop();
                    whiteAreas.Push(currWhiteArea);

                    greyAreas.Dequeue();
                    greyAreas.Enqueue(currGreyArea);
                }
            }

            if (whiteAreas.Count > 0)
            {
                Console.WriteLine($"White tiles left: {string.Join(", ",whiteAreas)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }
            if (greyAreas.Count > 0)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyAreas)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            var decoratedLocations = locations.Where(l => l.Value > 0).OrderByDescending(l => l.Value).ThenBy(l => l.Key);

            foreach (var location in decoratedLocations)
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }
    }
}
