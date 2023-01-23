using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //List<int> topIntegers = new List<int>();
            string res = string.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                bool isTopINteger = true;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] <= arr[j])
                    {
                        isTopINteger = false;
                        break;
                    }
                }
                if (isTopINteger)
                {
                    res += $"{arr[i]} ";
                }
                //if (isTopINteger)
                //{
                //    topIntegers.Add(arr[i]);
                //}
            }
            //Console.WriteLine(String.Join(" ", topIntegers));
            Console.WriteLine(res);
        }
    }
}
