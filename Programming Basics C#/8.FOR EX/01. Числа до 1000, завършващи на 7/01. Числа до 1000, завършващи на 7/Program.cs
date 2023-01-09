using System;

namespace _01._Числа_до_1000__завършващи_на_7
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 1000; i++)
            {
                if (i%10==7)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
