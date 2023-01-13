using System;

namespace Задача_1._Баскетболна_екипировка
{
    class Program
    {
        static void Main(string[] args)
        {
            double tax = double.Parse(Console.ReadLine());
            double shoesPrice = 0.6 * tax;
            double kitPrice = 0.8 * shoesPrice;
            double ballPrice = 0.25 * kitPrice;
            double accsPrice = 0.2 * ballPrice;
            Console.WriteLine($"{tax+shoesPrice+kitPrice+ballPrice+accsPrice:f2}");
        }
    }
}
