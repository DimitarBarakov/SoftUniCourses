using System;

namespace _08._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine(MathPower(a,b));
        }
        static double MathPower(double a, int b)
        {
            double resul = 1;
            for (int i = 1; i <= b; i++)
            {
                resul *= a;
            }
            return resul;
        }
    }
}
