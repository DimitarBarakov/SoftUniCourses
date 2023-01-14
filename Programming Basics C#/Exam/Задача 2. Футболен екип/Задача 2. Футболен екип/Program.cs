using System;

namespace Задача_2._Футболен_екип
{
    class Program
    {
        static void Main(string[] args)
        {
            double tshirtPrice = double.Parse(Console.ReadLine());
            double sumToWin = double.Parse(Console.ReadLine());
            double shortsPrice = 0.75 * tshirtPrice;
            double socksPrice = 0.20 * shortsPrice;
            double shoesPrice = (tshirtPrice + shortsPrice) * 2;
            double sum = 0.85*(tshirtPrice + shortsPrice + socksPrice + shoesPrice);
            if (sum>=sumToWin)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {sum:f2} lv.");
            }
            else
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {sumToWin-sum:f2} lv. more.");
            }
        }
    }
}
