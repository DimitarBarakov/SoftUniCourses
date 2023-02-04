using System;

namespace Problem_1___Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double foodQuantiy = double.Parse(Console.ReadLine());
            double hayQuantiy = double.Parse(Console.ReadLine());
            double coverQuantiy = double.Parse(Console.ReadLine());
            double guineaWeight = double.Parse(Console.ReadLine());
            for (int i = 1; i <= 30; i++)
            {
                foodQuantiy -= 0.3;
                if (i % 2 == 0)
                {
                    hayQuantiy -= foodQuantiy * 0.05;
                }
                if (i % 3 == 0)
                {
                    coverQuantiy -= 1.0 / 3 * guineaWeight;
                }
                if ((foodQuantiy <= 0) || (hayQuantiy <= 0) || (coverQuantiy <= 0))
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }
            }
            //if (foodQuantiy <= 0.00 || hayQuantiy <= 0 || coverQuantiy <= 0)
            //{
            //    Console.WriteLine("Merry must go to the pet store!");
            //    return;
            //}
            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {foodQuantiy:f2}, Hay: {hayQuantiy:f2}, Cover: {coverQuantiy:f2}.");
        }
    }
}
