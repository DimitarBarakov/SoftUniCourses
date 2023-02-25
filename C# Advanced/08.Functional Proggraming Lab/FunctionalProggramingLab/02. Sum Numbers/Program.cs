using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = n => int.Parse(n);
            int[] nums = Console.ReadLine().Split(", ").Select(parser).ToArray();
            Console.WriteLine(nums.Count());
            Console.WriteLine(nums.Sum());
        }
    }
}
