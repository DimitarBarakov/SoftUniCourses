using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            int originalRackCapacity = rackCapacity;
            int racksCount = 1;
            Stack<int> clothes = new Stack<int>(input);
            while (clothes.Count > 0)
            {
                int currCloth = clothes.Peek();
                if (currCloth < rackCapacity)
                {
                    clothes.Pop();
                    rackCapacity -= currCloth;
                }
                else if (currCloth == rackCapacity)
                {
                    clothes.Pop();
                    if (clothes.Count > 0)
                    {
                        racksCount++;
                    }
                    
                    rackCapacity = originalRackCapacity;
                }
                else
                {
                    racksCount++;
                    rackCapacity = originalRackCapacity;
                }
            }
            Console.WriteLine(racksCount);
        }
    }
}
