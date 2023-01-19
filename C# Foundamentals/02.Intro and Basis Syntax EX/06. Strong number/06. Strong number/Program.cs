using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int res = num;
            int sum = 0;
            while (res > 0)
            {
                int currDigit = res % 10;
                int fact = 1;
                for (int i = 2; i <= currDigit; i++)
                {
                    fact *= i;
                }
                sum += fact;
                res /= 10;
            }
            if (sum == num)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
