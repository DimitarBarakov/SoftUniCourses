using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split().ToArray();
                string name = tokens[0];
                if (tokens[2] == "going!")
                {
                    if (names.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        names.Add(name);
                    }
                }
                else if(tokens[2] == "not")
                {
                    if (names.Contains(name))
                    {
                        names.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}
