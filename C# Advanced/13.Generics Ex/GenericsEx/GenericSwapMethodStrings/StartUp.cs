using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Box<int>> list = new List<Box<int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int text = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(text);
                list.Add(box);
            }
            int[] indexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;

            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
