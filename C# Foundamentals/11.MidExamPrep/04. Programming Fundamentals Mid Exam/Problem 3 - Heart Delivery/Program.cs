using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3___Heart_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> houses = Console.ReadLine().Split('@').Select(int.Parse).ToList();
            string command;
            int cupidPosition = 0;
            while ((command = Console.ReadLine()) != "Love!")
            {
                string[] tokens = command.Split(' ');
                int length = int.Parse(tokens[1]);
                cupidPosition += length;
                if (cupidPosition >= houses.Count)
                {
                    cupidPosition = 0;
                }
                if (houses[cupidPosition] == 0)
                {
                    Console.WriteLine($"Place {cupidPosition} already had Valentine's day.");
                }
                else
                {
                    houses[cupidPosition] -= 2;
                    if (houses[cupidPosition] == 0)
                    {
                        Console.WriteLine($"Place {cupidPosition} has Valentine's day.");
                    }
                }
            }
            Console.WriteLine($"Cupid's last position was {cupidPosition}.");
            if (houses.TrueForAll(x => x == 0))
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                int leftHouses = 0;
                for (int i = 0; i < houses.Count; i++)
                {
                    if (houses[i] != 0)
                    {
                        leftHouses++;
                    }
                }
                Console.WriteLine($"Cupid has failed {leftHouses} places.");
            }
        }
    }
}
