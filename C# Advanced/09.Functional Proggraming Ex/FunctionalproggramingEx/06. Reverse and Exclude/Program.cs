using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_and_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());
            Predicate<int> isDivisible = x => x % n == 0;
            nums.RemoveAll(isDivisible);
            nums.Reverse();
            Console.WriteLine(String.Join(" ", nums));
        }
    }
}
