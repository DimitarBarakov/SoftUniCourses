using System;

namespace _07._Доставка_на_храна
{
    class Program
    {
        static void Main(string[] args)
        {
            int chickenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int vegMenu = int.Parse(Console.ReadLine());

            double chickenMenuBill = chickenMenu * 10.35;
            double fishMenuBill = fishMenu * 12.4;
            double vegMenuBill = vegMenu * 8.15;
            double desrtBill = (chickenMenuBill + fishMenuBill + vegMenuBill) * 0.2;
            double finalBill = chickenMenuBill + fishMenuBill + vegMenuBill + desrtBill + 2.5;
            Console.WriteLine(finalBill);
        }
    }
}
