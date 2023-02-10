using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split(' ').Select(w => w.ToLower()).ToList();
            Dictionary<string, int> numbersAndCount = new Dictionary<string, int>();
            for (int i = 0; i < words.Count; i++)
            {
                if (numbersAndCount.ContainsKey(words[i]))
                {
                    numbersAndCount[words[i]]++;
                }
                else
                {
                    numbersAndCount.Add(words[i], 1);
                }
            }
            foreach (var item in numbersAndCount)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write(item.Key+" ");
                }
            }
        }
    }
}
