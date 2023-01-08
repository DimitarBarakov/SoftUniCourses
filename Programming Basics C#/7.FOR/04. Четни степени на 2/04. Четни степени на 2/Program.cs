using System;

namespace _04._Четни_степени_на_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i <= n; i += 2)
            {
                Console.WriteLine(Math.Pow(2, i));
            }
        }
    }
}
