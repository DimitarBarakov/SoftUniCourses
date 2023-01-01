using System;

namespace _05._Учебни_материали
{
    class Program
    {
        static void Main(string[] args)
        {
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            int litres = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());
            double price = pens * 5.80 + markers * 7.20 + litres * 1.20;
            double finalprice = price * 0.75;
            Console.WriteLine(finalprice);
        }
    }
}
