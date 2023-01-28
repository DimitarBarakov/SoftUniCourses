using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Gauss__Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> res = new List<int>();
            for (int i = 0; i < first.Count / 2; i++)
            {
                int num = first[i] + first[first.Count - i - 1];
                res.Add(num);
            }
            if (first.Count % 2 != 0)
            {
                res.Add(first[first.Count / 2]);
            }
            Console.WriteLine(String.Join(" ", res));
        }
    }
}
