using System;

namespace _02._Бонус_точки
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double bonus = 0;
            if (a<=100)
            {
                bonus = 5;
            }
            else if (a>100&&a<1000)
            {
                bonus = a * 0.2;
            }
            else
            {
                bonus = a * 0.10;
            }
            if (a%2==0)
            {
                bonus += 1;
            }
            if (a%10==5)
            {
                bonus += 2;
            }
            Console.WriteLine(bonus);
            Console.WriteLine(a+bonus);
        }
    }
}
