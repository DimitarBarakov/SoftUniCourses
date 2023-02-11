using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            Dictionary<string, int> resourses = new Dictionary<string, int>();
            while ((command = Console.ReadLine()) != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());
                if (resourses.ContainsKey(command))
                {
                    resourses[command] += quantity;
                }
                else
                {
                     resourses.Add(command, quantity);
                }
            }
            foreach (var item in resourses)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
