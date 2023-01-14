using System;

namespace Задача_3._Калкулатор_за_екскурзии
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double sum = 0;
            if (peopleCount <= 5)
            {
                if (season == "spring")
                {
                    sum += peopleCount * 50.00;
                }
                else if (season == "summer")
                {
                    sum += peopleCount * 48.50;
                    sum *= 0.85;
                }
                else if (season == "autumn")
                {
                    sum += peopleCount * 60.00;
                }
                else if (season == "winter")
                {
                    sum += peopleCount * 86.00;
                    sum *= 1.08;
                }
            }
            else if (peopleCount > 5)
            {
                if (season == "spring")
                {
                    sum += peopleCount * 48.00;
                }
                else if (season == "summer")
                {
                    sum += peopleCount * 45.00;
                    sum *= 0.85;
                }
                else if (season == "autumn")
                {
                    sum += peopleCount * 49.50;
                }
                else if (season == "winter")
                {
                    sum += peopleCount * 85.00;
                    sum *= 1.08;
                }
            }
            Console.WriteLine($"{sum:f2} leva.");
        }
    }
}
