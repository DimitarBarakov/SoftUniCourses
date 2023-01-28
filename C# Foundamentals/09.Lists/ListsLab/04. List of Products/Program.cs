using System;
using System.Collections.Generic;

namespace _04._List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> res = new List<string>();
            for (int i = 0; i < n; i++)
            {
                res.Add(Console.ReadLine());
            }
            res.Sort();
            for (int i = 0; i < res.Count; i++)
            {
                Console.WriteLine($"{i+1}.{res[i]}");
            }
        }
    }
}
