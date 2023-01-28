using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Remove_Negatives_and_Reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> second = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            for (int i = 0; i < second.Count; i++)
            {
                if (second[i] < 0)
                {
                    second.Remove(second[i]);
                    i--;
                }
            }
            second.Reverse();
            if (second.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(String.Join(' ', second));
            }
            
        }
    }
}
