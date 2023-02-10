using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            SortedDictionary<int, int> numbersAndCount = new SortedDictionary<int, int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbersAndCount.ContainsKey(numbers[i]))
                {
                    numbersAndCount[numbers[i]]++;
                }
                else
                {
                    numbersAndCount.Add(numbers[i], 1);
                }
            }
            foreach (var item in numbersAndCount)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
