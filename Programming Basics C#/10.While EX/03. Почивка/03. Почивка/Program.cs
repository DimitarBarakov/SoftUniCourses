using System;

namespace _03._Почивка
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double savedMoney = double.Parse(Console.ReadLine());
            int daysCount = 0;
            int spendingDays = 0;
            while (savedMoney < neededMoney)
            {
                string action = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                daysCount++;
                if (action=="spend")
                {
                    if (savedMoney<money)
                    {
                        savedMoney = 0;
                    }
                    else
                    {
                        savedMoney -= money;
                    }
                    spendingDays++;
                }
                else
                {
                    savedMoney += money;
                    spendingDays = 0;
                }
                if (spendingDays==5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine(daysCount);
                    return;
                }
            }
            Console.WriteLine($"You saved the money for {daysCount} days.");
        }
    }
}
