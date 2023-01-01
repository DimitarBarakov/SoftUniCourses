using System;

namespace _08._Баскетболно_оборудване
{
    class Program
    {
        static void Main(string[] args)
        {
            double trainingTax = double.Parse(Console.ReadLine());
            double sneakersPrice = trainingTax - trainingTax * 0.4;
            double kitPrice =sneakersPrice - sneakersPrice*0.2;
            double ballPRice = kitPrice * 0.25;
            double accessoriesPrice =ballPRice*0.20;
            double finalPrice = trainingTax + sneakersPrice + kitPrice + ballPRice + accessoriesPrice;
            Console.WriteLine(finalPrice);
        }
    }
}
