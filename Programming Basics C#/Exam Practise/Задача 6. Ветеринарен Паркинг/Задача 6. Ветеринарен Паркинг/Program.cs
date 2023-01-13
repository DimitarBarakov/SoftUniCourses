using System;

namespace Задача_6._Ветеринарен_Паркинг
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            double totalSum = 0;
            for (int day = 1; day <= days; day++)
            {
                double sumForDay = 0;
                for (int hour = 1; hour <= hours; hour++)
                {
                    if (day%2==0&&hour%2!=0)
                    {
                        totalSum += 2.50;
                        sumForDay += 2.50;
                    }
                    else if(day % 2 != 0 && hour % 2 == 0)
                    {
                        totalSum += 1.25;
                        sumForDay += 1.25;
                    }
                    else
                    {
                        totalSum += 1.00;
                        sumForDay += 1.00;
                    }
                }
                Console.WriteLine($"Day: {day} – {sumForDay:f2} leva");
            }
            Console.WriteLine($"Total: {totalSum:f2} leva");

        }
    }
}
