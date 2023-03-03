using System;
using System.Collections.Generic;
using System.Linq;

namespace Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine().Split().Select(double.Parse));
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split().Select(double.Parse));

            Dictionary<string, int> products = new Dictionary<string, int>();
            products.Add("Croissant", 0);
            products.Add("Muffin", 0);
            products.Add("Baguette", 0);
            products.Add("Bagel", 0);

            while (water.Count > 0 && 0 < flour.Count)
            {
                double waterAmount = water.Peek();
                double flourAmount = flour.Peek();
                double all = waterAmount + flourAmount;

                double waterPercentage = waterAmount * 100 / all;
                double flourPercentage = 100 - waterPercentage;

                water.Dequeue();
                flour.Pop();

                if (waterPercentage == 50)
                {
                    products["Croissant"]++;
                }
                else if (waterPercentage == 40)
                {
                    products["Muffin"]++;
                }
                else if (waterPercentage == 30)
                {
                    products["Baguette"]++;
                }
                else if (waterPercentage == 20)
                {
                    products["Bagel"]++;
                }
                else
                {
                    double newFlour = waterAmount;
                    flourAmount -= newFlour;
                    products["Croissant"]++;
                    flour.Push(flourAmount);
                }
            }

            var bakedProducts = products.Where(p => p.Value > 0).OrderByDescending(p => p.Value).ThenBy(p => p.Key);
            foreach (var product in bakedProducts)
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }

            if (water.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ",water)}");
            }

            if (flour.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
        }
    }
}
