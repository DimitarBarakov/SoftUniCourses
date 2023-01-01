using System;

namespace _08._Зоомагазин
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogFoodCount = int.Parse(Console.ReadLine());
            double catFoodCount = double.Parse(Console.ReadLine());
            Console.WriteLine(catFoodCount*4 + dogFoodCount*2.5 + " lv.");
        }
    }
}
