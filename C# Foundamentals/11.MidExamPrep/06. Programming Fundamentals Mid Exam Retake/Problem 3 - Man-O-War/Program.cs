using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3___Man_O_War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine().Split('>').Select(int.Parse).ToList();
            List<int> warShip = Console.ReadLine().Split('>').Select(int.Parse).ToList();
            int maximumHealth = int.Parse(Console.ReadLine());
            string command;
            while ((command = Console.ReadLine()) != "Retire")
            {
                string[] tokens = command.Split();
                string action = tokens[0];
                if (action == "Fire")
                {
                    int index = int.Parse(tokens[1]);
                    if (index >= 0 && index < warShip.Count)
                    {
                        int damage = int.Parse(tokens[2]);
                        warShip[index] -= damage;
                        if (warShip[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                }
                else if (action == "Defend")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    int damage = int.Parse(tokens[3]);
                    if ((startIndex >= 0) && (startIndex < pirateShip.Count) && (endIndex >= 0) && (endIndex < pirateShip.Count))
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirateShip[i] -= damage;
                            if (pirateShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }
                }
                else if (action == "Repair")
                {
                    int index = int.Parse(tokens[1]);
                    int health = int.Parse(tokens[2]);
                    if (index >= 0 && index < pirateShip.Count)
                    {
                        pirateShip[index] += health;
                        if (pirateShip[index] > maximumHealth)
                        {
                            pirateShip[index] = maximumHealth;
                        }
                    }
                }
                else if (action == "Status")
                {
                    int count = 0;
                    for (int i = 0; i < pirateShip.Count; i++)
                    {
                        if (pirateShip[i] < maximumHealth*0.2)
                        {
                            count++;
                        }
                    }
                    Console.WriteLine($"{count} sections need repair.");
                }
            }
            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {warShip.Sum()}");
        }
    }
}
