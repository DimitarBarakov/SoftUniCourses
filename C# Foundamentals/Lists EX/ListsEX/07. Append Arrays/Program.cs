using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> arrays = Console.ReadLine().Split('|',StringSplitOptions.RemoveEmptyEntries).ToList();
            List<int> res = new List<int>();
            for (int i = arrays.Count-1; i >= 0; i--)
            {
                string[] arr = arrays[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < arr.Length; j++)
                {
                    int num = int.Parse(arr[j]);
                    res.Add(num);
                }
            }
            Console.WriteLine(String.Join(' ', res));
        }
    }
}
