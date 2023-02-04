using System;

namespace Problem_1___Black_Flag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double dailyPlunder = double.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());
            double collectedPlunder = 0;
            for (int i = 1; i <= days; i++)
            {
                collectedPlunder += dailyPlunder;
                if (i % 3 == 0)
                {
                    collectedPlunder += dailyPlunder / 2;
                }
                if (i % 5 == 0)
                {
                    collectedPlunder *= 0.7;
                }
            }
            if (collectedPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {collectedPlunder:f2} plunder gained.");
            }
            else
            {
                double percentLeft = collectedPlunder / (expectedPlunder / 100);
                Console.WriteLine($"Collected only {percentLeft:f2}% of the plunder.");
            }
        }
    }
}
