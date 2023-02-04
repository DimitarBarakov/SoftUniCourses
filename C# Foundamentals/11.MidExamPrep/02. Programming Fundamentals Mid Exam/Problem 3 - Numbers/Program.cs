using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3___Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            double average = numbers.Average();
            List<int> res = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > average)
                {
                    res.Add(numbers[i]);
                }
            }
            res.Sort();
            res.Reverse();
            while (res.Count > 5)
            {
                res.RemoveAt(res.Count - 1);
            }
            if (res.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(String.Join(' ', res));
            }
           
        }
    }
}
