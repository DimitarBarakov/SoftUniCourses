using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            for (int i = 0; i < wagons.Count; i++)
            {
                while (wagons[i] < 4 && people > 0)
                {
                    wagons[i]++;
                    people--;
                }
            }
            if (wagons.Sum() != wagons.Count*4)
            {
                Console.WriteLine("The lift has empty spots!");
            }
            else
            {
                if (people == 0)
                {
                    Console.WriteLine(String.Join(' ', wagons));
                    return;
                }
                else
                {
                    Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                }
                
            }
            Console.WriteLine(String.Join(' ',wagons));
        }
    }
}
