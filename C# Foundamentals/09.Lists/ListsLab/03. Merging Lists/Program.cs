using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> first = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            List<double> second = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            List<double> result = new List<double>();
            int biggerCount = Math.Max(first.Count,second.Count);
            for (int i = 0; i < biggerCount; i++)
            {
                if (i<first.Count)
                {
                    result.Add(first[i]);
                }
                if (i < second.Count)
                {
                    result.Add(second[i]);
                }
            }
            Console.WriteLine(String.Join(' ',result));
        }
    }
}
