using System;

namespace _07._Пазаруване
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget= double.Parse(Console.ReadLine());
            int videocards = int.Parse(Console.ReadLine());
            int procesor = int.Parse(Console.ReadLine());
            int ram = int.Parse(Console.ReadLine());

            double videocardsPrize = videocards * 250;
            double procesorsPrize = procesor * (0.35 * videocardsPrize);
            double ramPrize = ram * (0.10 * videocardsPrize);

            double finalPrize = videocardsPrize + procesorsPrize + ramPrize;
            if (videocards>=procesor)
            {
                finalPrize *= 0.85;
            }
            if (budget>=finalPrize)
            {
                Console.WriteLine($"You have {budget-finalPrize:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {finalPrize-budget:f2} leva more!");
            }
        }
    }
}
