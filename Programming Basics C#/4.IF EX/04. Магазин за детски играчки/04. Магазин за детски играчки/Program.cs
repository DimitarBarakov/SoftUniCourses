using System;

namespace _04._Магазин_за_детски_играчки
{
    class Program
    {
        static void Main(string[] args)
        {
            double vacationPrize = double.Parse(Console.ReadLine());
            int puzzlesCount = int.Parse(Console.ReadLine());
            int talkingDollsCount = int.Parse(Console.ReadLine());
            int teddyBearsCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int trucksCount = int.Parse(Console.ReadLine());
            int allToysCount = puzzlesCount + talkingDollsCount + trucksCount + teddyBearsCount + minionsCount;
            double profit = puzzlesCount * 2.60 + talkingDollsCount * 3.00 + teddyBearsCount * 4.10 + minionsCount * 8.20 + trucksCount * 2.00;
            if (allToysCount>=50)
            {
                profit *= 0.75;
            }
            double afterRentPayment = profit *= 0.90;
            if (afterRentPayment>=vacationPrize)
            {
                Console.WriteLine($"Yes! {afterRentPayment-vacationPrize:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {vacationPrize-afterRentPayment:f2} lv needed.");
            }
        }
    }
}
