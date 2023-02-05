using System;

namespace Problem_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCities = int.Parse(Console.ReadLine());
            double totalProfit = 0;
            for (int i = 1; i <= numberOfCities; i++)
            {
                string cityName = Console.ReadLine();
                double earnedMoney = double.Parse(Console.ReadLine());
                double expexnses = double.Parse(Console.ReadLine());
                if (i % 3 == 0)
                {
                    if (i % 5 == 0)
                    {
                        earnedMoney *= 0.90;
                    }
                    else
                    {
                        expexnses += expexnses / 2.0;
                    }
                }
                else if (i % 5 == 0)
                {
                    earnedMoney *= 0.90;
                }

                double profit = earnedMoney - expexnses;
                totalProfit += profit;
                Console.WriteLine($"In {cityName} Burger Bus earned {profit:f2} leva.");
            }
            Console.WriteLine($"Burger Bus total profit: {totalProfit:f2} leva.");
        }
    }
}
