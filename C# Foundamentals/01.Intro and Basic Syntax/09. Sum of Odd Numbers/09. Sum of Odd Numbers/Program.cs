using System;

namespace _09._Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int j = 1;
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += j;
                Console.WriteLine(j);
                j += 2;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
