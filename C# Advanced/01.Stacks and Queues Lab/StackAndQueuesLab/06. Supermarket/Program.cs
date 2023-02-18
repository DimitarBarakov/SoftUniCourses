using System;
using System.Collections.Generic;

namespace _06._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                if (cmd == "Paid")
                {
                    while (customers.Count > 0)
                    {
                        Console.WriteLine(customers.Dequeue());
                    }
                }
                else
                {
                    customers.Enqueue(cmd);
                }
            }
            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
