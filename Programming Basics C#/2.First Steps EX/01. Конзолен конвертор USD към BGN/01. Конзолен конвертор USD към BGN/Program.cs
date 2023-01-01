using System;

namespace _01._Конзолен_конвертор_USD_към_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());
            Console.WriteLine(usd * 1.79549);
        }
    }
}
