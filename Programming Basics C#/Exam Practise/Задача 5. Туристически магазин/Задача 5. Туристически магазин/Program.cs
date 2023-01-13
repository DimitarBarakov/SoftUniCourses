using System;

namespace Задача_5._Туристически_магазин
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string product = Console.ReadLine();
            double totalSum = 0;
            int productsCount = 0;
            while (product!="Stop")
            {
                double price = double.Parse(Console.ReadLine());
                productsCount++; 
                if (price > budget)
                {
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {price-budget:f2} leva!");
                    return;
                }
                if (productsCount%3==0)
                {
                    price /= 2;
                    totalSum += price;
                    budget -= price;
                }
                else
                {
                    totalSum += price;
                    budget -= price;
                }
                product = Console.ReadLine();
            }
            Console.WriteLine($"You bought {productsCount} products for {totalSum:f2} leva.");
        }
    }
}
