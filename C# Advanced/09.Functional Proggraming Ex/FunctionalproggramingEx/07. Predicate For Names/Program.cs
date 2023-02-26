using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();
            Predicate<string> isLenghtLessOrEqual = x => x.Length <= n;
            names = names.FindAll(isLenghtLessOrEqual).ToList();
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}
