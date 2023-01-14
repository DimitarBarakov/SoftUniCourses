using System;

namespace Задача_6._Таблица_за_умножение
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sto = num / 100;
            int des = num / 10 % 10;
            int ed = num % 10;
            for (int i = 1; i <= ed; i++)
            {
                for (int j = 1; j <= des; j++)
                {
                    for (int k = 1; k <= sto; k++)
                    {
                        Console.WriteLine($"{i} * {j} * {k} = {i*j*k};");
                    }
                }
            }
        }
    }
}
