using System;

namespace _09._Лява_и_дясна_сума
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int lestSum = 0;
            int rightSUm = 0;
            for (int i = 1; i <= 2*n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (i<=n)
                {
                    lestSum += num;
                }
                else
                {
                    rightSUm += num;
                }
            }
            if (lestSum==rightSUm)
            {
                Console.WriteLine($"Yes, sum = {lestSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(lestSum-rightSUm)}");
            }
        }
    }
}
