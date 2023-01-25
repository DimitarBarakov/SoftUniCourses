using System;

namespace _10._Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if (IsSumOfDigitsDivisibleBy8(i)&&HoldsAtLeastOneOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool IsSumOfDigitsDivisibleBy8(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            if (sum % 8 == 0)
            {
                return true;
            }
            return false;
        }

        static bool HoldsAtLeastOneOddDigit(int n)
        {
            int count = 0;
            while (n > 0)
            {
                if (n % 10 % 2 != 0)
                {
                    count++;
                }
                n /= 10;
            }
            if (count >= 1)
            {
                return true;
            }
            return false;
        }
    }
}
