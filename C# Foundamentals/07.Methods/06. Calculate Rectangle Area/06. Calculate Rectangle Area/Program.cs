using System;

namespace _06._Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int widht = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine(CalculateRectangleArea(widht,height));
        }
        static int CalculateRectangleArea(int widht, int height)
        {
            return widht * height;
        }
    }
}
