using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bombAndPower = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bombNumber = bombAndPower[0];
            int bombPower = bombAndPower[1];
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNumber)
                {
                    int bombIndex = i;
                    int startIndex = bombIndex - bombPower;
                    int endIndex = bombIndex + bombPower;
                    if (endIndex >= numbers.Count)
                    {
                        endIndex = numbers.Count - 1;
                    }
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    for (int j = startIndex; j <= endIndex; j++)
                    {
                        numbers.RemoveAt(j);
                        endIndex--;
                        j--;
                    }
                    i = -1;
                }

            }
            int sum = numbers.Sum();
            Console.WriteLine(sum);
        }
    }
}
