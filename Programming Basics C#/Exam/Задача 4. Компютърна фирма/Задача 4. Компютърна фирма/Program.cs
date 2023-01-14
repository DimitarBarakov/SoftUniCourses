using System;

namespace Задача_4._Компютърна_фирма
{
    class Program
    {
        static void Main(string[] args)
        {
            int computersCount = int.Parse(Console.ReadLine());
            double madeSales = 0;
            double allRating = 0;
            for (int i = 1; i <= computersCount; i++)
            {
                int num = int.Parse(Console.ReadLine());
                int rating = num % 10;
                double sales = num / 10;
                allRating += rating;
                switch (rating)
                {
                    case 2: madeSales += 0; break;
                    case 3:madeSales += 0.5 * sales; break;
                    case 4: madeSales += 0.70 * sales; break;
                    case 5: madeSales += 0.85 * sales; break;
                    case 6: madeSales += sales; break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"{madeSales:f2}");
            Console.WriteLine($"{allRating/computersCount:f2}");
        }
    }
}
