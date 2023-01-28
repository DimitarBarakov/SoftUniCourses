using System;

namespace _01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            PrintTheSmallestNumber(a, b, c);
        }

        static void PrintTheSmallestNumber(int a, int b, int c)
        {
            int min = int.MaxValue;
            if (a<min)
            {
                min = a;
            }
            if (b < min)
            {
                min = b;
            }
            if (c < min)
            {
                min = c;
            }
            Console.WriteLine(min);
        }
    }
}
