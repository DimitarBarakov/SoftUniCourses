using System;
using System.Collections.Generic;

namespace _08._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalCarsPassed = 0;
            Queue<string> cars = new Queue<string>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "end")
            {
                if (cmd == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count>0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            totalCarsPassed++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(cmd);
                }
            }
            Console.WriteLine($"{totalCarsPassed} cars passed the crossroads.");
        }
    }
}
