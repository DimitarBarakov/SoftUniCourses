using System;

namespace _05._Годзила_срещу_Конг
{
    class Program
    {
        static void Main(string[] args)
        {
            double movieBudget = double.Parse(Console.ReadLine());
            int statistsCount = int.Parse(Console.ReadLine());
            double clothesPerStatist = double.Parse(Console.ReadLine());
            double decor = 0.10 * movieBudget;
            double clothesPrize = statistsCount * clothesPerStatist;
            if (statistsCount>150)
            {
                clothesPrize *= 0.90;
            }
            double allMoney = decor + clothesPrize;
            if (movieBudget>=allMoney)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {movieBudget-allMoney:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {allMoney-movieBudget:f2} leva more.");
            }
        }
    }
}
