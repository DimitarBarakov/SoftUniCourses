using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arg = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int countToAdd = arg[0];
            int countToRemove = arg[1];
            int searchingNum = arg[2];
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> nums = new Stack<int>(input);
            for (int i = 0; i < countToRemove; i++)
            {
                nums.Pop();
            }
            if (nums.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (nums.Contains(searchingNum))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(nums.Min());
                }
            }
        }
    }
}
