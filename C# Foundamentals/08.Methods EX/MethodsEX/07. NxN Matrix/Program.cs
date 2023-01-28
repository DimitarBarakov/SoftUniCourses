using System;

namespace _07._NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                PrintLine(n);
            }
        }

        static void PrintLine(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.Write(n+" ");
            }
            Console.WriteLine();
        }
    }
}
