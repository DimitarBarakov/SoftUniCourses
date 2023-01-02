using System;

namespace _07._Лица_на_фигури
{
    class Program
    {
        static void Main(string[] args)
        {
            string shape = Console.ReadLine();
            if (shape=="square")
            {
                double a = double.Parse(Console.ReadLine());
                Console.WriteLine(a*a);
            }
            if (shape=="rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                Console.WriteLine(a * b);
            }
            if (shape=="triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double ha = double.Parse(Console.ReadLine());
                Console.WriteLine(a*ha/2);
            }
            if (shape=="circle")
            {
                double r = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.PI*r*r);
            }
        }
    }
}
