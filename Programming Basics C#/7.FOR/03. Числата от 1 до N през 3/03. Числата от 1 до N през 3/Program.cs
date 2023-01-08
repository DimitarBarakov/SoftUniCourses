using System;

namespace _03._Числата_от_1_до_N_през_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i <= n; i+=2)
            {
                Console.WriteLine(Math.Pow(2,i));
            }
        }
    }
}
