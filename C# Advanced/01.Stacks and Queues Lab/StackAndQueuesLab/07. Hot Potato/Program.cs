using System;
using System.Collections.Generic;

namespace _07._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            Queue<string> players = new Queue<string>(input);
            while (players.Count>1)
            {
                for (int i = 1; i < n; i++)
                {
                    string player = players.Dequeue();
                    players.Enqueue(player);
                }
                Console.WriteLine($"Removed {players.Dequeue()}");
            }
            Console.WriteLine($"Last is {players.Dequeue()}");
        }
    }
}
