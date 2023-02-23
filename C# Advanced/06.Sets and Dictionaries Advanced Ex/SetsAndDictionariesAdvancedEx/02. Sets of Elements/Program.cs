using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arg = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = arg[0];
            int m = arg[1];
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();
            List<int> equal = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                first.Add(num);
            }
            for (int i = 0; i < m; i++)
            {
                int num = int.Parse(Console.ReadLine());
                second.Add(num);
            }
            List<int> firstAsList = first.ToList();
            List<int> secondAsList = second.ToList();
            for (int i = 0; i < first.Count; i++)
            {
                if (secondAsList.Contains(firstAsList[i]))
                {
                    equal.Add(firstAsList[i]);
                }
            }
            Console.WriteLine(String.Join(" ", equal));
        }
    }
}
