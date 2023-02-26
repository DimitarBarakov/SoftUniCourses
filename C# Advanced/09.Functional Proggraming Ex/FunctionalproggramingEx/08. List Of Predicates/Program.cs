using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> nums = new List<int>();
            //for (int i = 1; i <= end; i++)
            //{
            //    int currNum = i;
            //    bool isDivisibleByAll = true;
            //    for (int j = 0; j < dividers.Count; j++)
            //    {
            //        if (currNum%dividers[j] != 0)
            //        {
            //            isDivisibleByAll = false;
            //        }
            //    }
            //    if (isDivisibleByAll)
            //    {
            //        nums.Add(i);
            //    }
            //}
            //Console.WriteLine(String.Join(" ", nums));
            
        }
    }
}
 