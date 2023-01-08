using System;

namespace _08._Редица_цели_числа
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int min = int.MaxValue;
            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num>max)
                {
                    max = num;
                }

                if (num<min)
                {
                    min = num;
                }

            }
            Console.WriteLine($"Max number: {max}");
            Console.WriteLine($"Min number: {min}");
        }
    }
}
