using System;

namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            double result = CalculateFactorial(n1) * 1.0 / CalculateFactorial(n2);
            Console.WriteLine($"{result:f2}");
        }

        static long CalculateFactorial(int n)
        {
            long factorial = 1;
            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
