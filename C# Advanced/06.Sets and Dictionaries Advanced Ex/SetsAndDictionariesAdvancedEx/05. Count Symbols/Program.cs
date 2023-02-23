using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> countOfElements = new SortedDictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!countOfElements.ContainsKey(input[i]))
                {
                    countOfElements.Add(input[i],0);
                }
                countOfElements[input[i]]++;
            }
            foreach (var element in countOfElements)
            {
                Console.WriteLine($"{element.Key}: {element.Value} time/s");
            }
        }
    }
}
