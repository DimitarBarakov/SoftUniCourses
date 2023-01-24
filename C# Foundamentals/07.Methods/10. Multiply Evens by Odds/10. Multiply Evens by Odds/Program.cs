using System;

namespace _10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            GetMultipleOfEvenAndOdds(CalculateEvevSum(Math.Abs(n)), CalculateOddSum(Math.Abs(n)));
        }

        static void GetMultipleOfEvenAndOdds(int a, int b)
        {
            Console.WriteLine(a * b);
        }
        static int CalculateEvevSum(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                int current = n % 10;
                if (current % 2 == 0)
                {
                    sum += Math.Abs(current);
                }
                n /= 10;
            }
            return sum;
        }
        static int CalculateOddSum(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                int current = n % 10;
                if (current % 2 != 0)
                {
                    sum += Math.Abs(current);
                }
                n /= 10;
            }
            return sum;
        }
    }
}
