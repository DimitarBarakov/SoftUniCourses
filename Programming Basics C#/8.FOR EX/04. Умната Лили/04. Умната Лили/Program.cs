using System;

namespace _04._Умната_Лили
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double laundryPrice = double.Parse(Console.ReadLine());
            double toysPrice = double.Parse(Console.ReadLine());
            int toysCount = 0;
            double money = 0;
            for (int i = 1; i <= age; i++)
            {
                if (i%2==0)
                {
                    money += i * 5;
                    money--;
                }
                else
                {
                    toysCount++;
                }
            }
            double moneyFromToys = toysCount * toysPrice;
            double allMoney = money + moneyFromToys;
            if (allMoney>=laundryPrice)
            {
                Console.WriteLine($"Yes! {allMoney - laundryPrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {laundryPrice - allMoney:f2}");
            }
        }
    }
}
