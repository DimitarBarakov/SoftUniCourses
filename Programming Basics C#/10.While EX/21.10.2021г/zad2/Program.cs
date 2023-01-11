using System;

namespace zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int count = 0;
            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (i%2==0)
                {
                    sum += Math.Abs(num);
                    count++;
                }
            }
            Console.WriteLine(sum/count);
        }
    }
}
