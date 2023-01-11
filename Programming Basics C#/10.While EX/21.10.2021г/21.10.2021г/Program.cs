using System;

namespace _21._10._2021г_
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            for (int i = 100; i <= 999; i++)
            {
                int a = i % 10;
                int b = i / 10 % 10;
                int c = i / 100;
                if (a!=0&&b!=0&&c!=0)
                {
                    if (i%(a*b*c)==0)
                    {
                        count++;
                        Console.WriteLine(i);
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
