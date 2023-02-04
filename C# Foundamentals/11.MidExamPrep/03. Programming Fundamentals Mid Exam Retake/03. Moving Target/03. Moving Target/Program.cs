using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //(startIndex < 0) || (startIndex >= targets.Count) || (index <= 0) || (index >= targets.Count) || (endIndex < 0) || (endIndex >= targets.Count)
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();
                string action = tokens[0];
                if (action == "Shoot")
                {
                    int index = int.Parse(tokens[1]);
                    int power = int.Parse(tokens[2]);
                    if (index >= 0 && index < targets.Count)
                    {
                        targets[index] -= power;
                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                }
                else if (action == "Add")
                {
                    int index = int.Parse(tokens[1]);
                    int value = int.Parse(tokens[2]);
                    if (index >= 0 && index < targets.Count)
                    {
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (action == "Strike")
                {
                    int index = int.Parse(tokens[1]);
                    int radius = int.Parse(tokens[2]);
                    int startIndex = index - radius;
                    int endIndex = index + radius;
                    if (startIndex < 0 || endIndex >= targets.Count)
                    {
                        Console.WriteLine("Strike missed!");
                    }
                    else
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            targets.RemoveAt(i);
                            i--;
                            endIndex--;
                        }
                    }
                }
            }
            Console.WriteLine(String.Join('|', targets));
        }
    }
}
