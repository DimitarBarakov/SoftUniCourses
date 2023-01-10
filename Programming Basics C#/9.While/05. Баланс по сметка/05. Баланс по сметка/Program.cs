using System;

namespace _05._Баланс_по_сметка
{
    class Program
    {
        static void Main(string[] args)
        {
            string comm = Console.ReadLine();
            double total = 0;
            while (comm!="NoMoreMoney")
            {
                double money = double.Parse(comm);
                if (money<0)
                {
                    Console.WriteLine("Invalid operation!");
                    Console.WriteLine($"Total: {total:f2}");
                    return;
                }
                else
                {
                    Console.WriteLine($"Increase: {money:f2}");
                    total += money;
                }
                comm = Console.ReadLine();
            }
            Console.WriteLine($"Total: {total:f2}");
        }
    }
}
