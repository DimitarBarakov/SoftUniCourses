using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> nums = Console.ReadLine().Split(", ").Select(double.Parse).ToList();
            Func<double, double> addVAT = x => x += x / 5;
            nums = nums.Select(addVAT).ToList();
            foreach (double x in nums)
            {
                Console.WriteLine(x.ToString("f2"));
            }
        }
    }
}
