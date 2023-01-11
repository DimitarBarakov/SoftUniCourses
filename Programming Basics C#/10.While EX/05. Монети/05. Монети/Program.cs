using System;

namespace _05._Монети
{
    class Program
    {
        static void Main(string[] args)
        {
            double exchange = double.Parse(Console.ReadLine());
            double exchangeInCents = exchange * 100;
            int count = 0;
            while (exchangeInCents != 0)
            {
                while (exchangeInCents>=200)
                {
                    exchangeInCents -= 200;
                    count++;
                }
                while (exchangeInCents<200&&exchangeInCents>=100)
                {
                    exchangeInCents -= 100;
                    count++;
                }
                while (exchangeInCents < 100 && exchangeInCents >= 50)
                {
                    exchangeInCents -= 50;
                    count++;
                }
                while (exchangeInCents < 50 && exchangeInCents >= 20)
                {
                    exchangeInCents -= 20;
                    count++;
                }
                while (exchangeInCents < 20 && exchangeInCents >= 10)
                {
                    exchangeInCents -= 10;
                    count++;
                }
                while (exchangeInCents < 10 && exchangeInCents >= 5)
                {
                    exchangeInCents -= 5;
                    count++;
                }
                while (exchangeInCents < 5 && exchangeInCents >= 2)
                {
                    exchangeInCents -= 2;
                    count++;
                }
                while (exchangeInCents == 1)
                {
                    exchangeInCents -= 1;
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
