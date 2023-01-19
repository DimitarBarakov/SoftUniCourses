using System;

namespace _01._Convert_Meters_to_Kilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            decimal b = (decimal)(a * 1.0 / 1000);
            Console.WriteLine($"{b:f2}");
        }
    }
}
