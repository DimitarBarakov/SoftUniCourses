using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> items = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            int entryPoint = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            int leftSum = 0;
            int rightSum = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (type == "cheap")
                {
                    if (i < entryPoint)
                    {
                        if (items[i] < items[entryPoint])
                        {
                            leftSum += items[i];
                        }
                    }
                    else if (i > entryPoint)
                    {
                        if (items[i] < items[entryPoint])
                        {
                            rightSum += items[i];
                        }
                    }
                }
                else if (type == "expensive")
                {
                    if (i < entryPoint)
                    {
                        if (items[i] >= items[entryPoint])
                        {
                            leftSum += items[i];
                        }
                    }
                    else if (i > entryPoint)
                    {
                        if (items[i] >= items[entryPoint])
                        {
                            rightSum += items[i];
                        }
                    }
                }
            }
            if (leftSum >= rightSum)
            {
                Console.WriteLine($"Left - {leftSum}");
            }
            else
            {
                Console.WriteLine($"Right - {rightSum}");
            }
        }
    }
}
