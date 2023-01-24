using System;

namespace _05._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            CalculatePrice(product, quantity);
        }
        static void CalculatePrice(string product, int quantity)
        {
            double price = 0;
            if (product=="coffee")
            {
                price+=quantity*1.5;
            }
            else if (product == "water")
            {
                price += quantity * 1.00;
            }
            else if (product =="coke")
            {
                price += quantity * 1.4;
            }
            else if (product=="snacks")
            {
                price += quantity * 2.0;
            }
            Console.WriteLine($"{price:f2}");
        }
    }
}
