using System;

namespace _02._Елемент__равен_на_сумата_на_останалите
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int allSum = 0;
            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                allSum += num;
                if (num>max)
                {
                    max = num;
                }
            }
            int sumWithoutMax = allSum - max;
            if (sumWithoutMax==max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {max}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(max-sumWithoutMax)}");
            }
        }
    }
}
