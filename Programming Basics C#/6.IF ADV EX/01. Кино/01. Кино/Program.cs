using System;

namespace _01._Кино
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            if (type=="Premiere")
            {
                Console.WriteLine($"{rows*cols*12.00:f2} leva.");
            }
            else if (type == "Normal")
            {
                Console.WriteLine($"{rows * cols * 7.50:f2} leva.");
            }
            else if (type == "Discount")
            {
                Console.WriteLine($"{rows * cols * 5.00:f2} leva.");
            }
        }
    }
}
