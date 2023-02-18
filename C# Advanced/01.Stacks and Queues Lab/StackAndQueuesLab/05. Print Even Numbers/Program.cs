using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> list = new List<int>();
            Queue<int> queue = new Queue<int>(nums);
            while (queue.Count > 0)
            {
                int currNum = queue.Dequeue();
                if (currNum % 2 == 0)
                {
                    list.Add(currNum);
                }
            }
            Console.WriteLine(String.Join(", ", list));
        }
    }
}
