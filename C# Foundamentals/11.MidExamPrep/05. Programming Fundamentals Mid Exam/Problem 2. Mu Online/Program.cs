using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Mu_Online
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List<string> rooms = Console.ReadLine().Split('|').ToList();
            string[] rooms = Console.ReadLine().Split('|').ToArray();
            int health = 100;
            int bitcoins = 0;
            for (int i = 0; i < rooms.Length; i++)
            {
                string currentRoom = rooms[i];
                string[] splittedCurrentRoom = currentRoom.Split();
                string action = splittedCurrentRoom[0];
                if (action == "potion")
                {
                    int healing = int.Parse(splittedCurrentRoom[1]);
                    if (health + healing > 100)
                    {

                        Console.WriteLine($"You healed for {100 - health} hp.");
                        health = 100;
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else
                    {
                        health += healing;
                        Console.WriteLine($"You healed for {healing} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                }
                else if (action == "chest")
                {
                    int bitcoinsFound = int.Parse(splittedCurrentRoom[1]);
                    bitcoins += bitcoinsFound;
                    Console.WriteLine($"You found {bitcoinsFound} bitcoins.");
                }
                else
                {
                    string monster = action;
                    int monsterPower = int.Parse(splittedCurrentRoom[1]);
                    health -= monsterPower;
                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {i+1}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {monster}.");
                    }
                }
            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
