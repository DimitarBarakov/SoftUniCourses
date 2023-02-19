using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(input);
            int maxOrder = 0;
            while (orders.Count > 0)
            {
                int currOrder = orders.Peek();
                if (currOrder > maxOrder)
                {
                    maxOrder = currOrder;
                }
                if (currOrder <= foodQuantity)
                {
                    
                    orders.Dequeue();
                    foodQuantity-= currOrder;
                }
                else
                {
                    Console.WriteLine(maxOrder);
                    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                    return;
                }
            }
            Console.WriteLine(maxOrder);
            Console.WriteLine("Orders complete");
        }
    }
}
