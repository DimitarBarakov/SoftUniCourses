using System;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine().Split(", ").Select(int.Parse).OrderBy(n => n).Where(n => n % 2 == 0).ToList()));
        }
    }
}
