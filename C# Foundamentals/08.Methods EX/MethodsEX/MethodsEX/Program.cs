using System;
using System.Collections.Generic;
using System.Linq;

namespace MethodsEX
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int count = int.Parse(Console.ReadLine());
            //string type = Console.ReadLine();
            Console.WriteLine(string.Join(' ', ReturnLastEvenOddCount(arr, count)));
        }

        static List<int> ReturnFirstEvenOddCount(int[] arr)
        {
            List<int> firstEven = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    firstEven.Add(arr[i]);
                }
            }
            return firstEven;
        }

        static List<int> ReturnLastEvenOddCount(int[] arr, int count)
        {
            List<int> lastEven = new List<int>();
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] % 2 == 0)
                {
                    lastEven.Add(arr[i]);
                    if (lastEven.Count == count)
                    {
                        break;
                    }
                }
            }

            lastEven.Reverse();
            return lastEven;
        }
    }
}
