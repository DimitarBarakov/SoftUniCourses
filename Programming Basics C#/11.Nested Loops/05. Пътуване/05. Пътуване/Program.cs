using System;

namespace _05._Пътуване
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            
            while (destination!="End")
            {
                double neededMoney = double.Parse(Console.ReadLine());
                double savedMoney = 0;
                while (savedMoney<neededMoney)
                {
                    double savings = double.Parse(Console.ReadLine());
                    savedMoney += savings;
                }
                Console.WriteLine($"Going to {destination}!");
                destination = Console.ReadLine();
            }
        }
    }
}
