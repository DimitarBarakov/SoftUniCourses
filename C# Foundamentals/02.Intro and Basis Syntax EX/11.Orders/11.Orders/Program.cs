using System;

namespace _11.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ordersCount = int.Parse(Console.ReadLine());
            double total = 0;
            for (int i = 1; i <= ordersCount; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int daysInMonth = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());
                total += daysInMonth * capsulesCount * pricePerCapsule;
                Console.WriteLine($"The price for the coffee is: ${daysInMonth* capsulesCount *pricePerCapsule:f2}");
            }
            Console.WriteLine($"Total: ${total:f2}");
        }
    }
}
