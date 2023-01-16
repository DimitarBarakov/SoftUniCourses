using System;

namespace _02.Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            if (num % 2 == 0)
            {
                if (num % 10 == 0)
                {
                    Console.WriteLine("The number is divisible by 10");
                    return;
                }
                else if (num % 3 == 0)
                {
                    Console.WriteLine("The number is divisible by 6");
                    return;
                }
                else
                {
                    Console.WriteLine("The number is divisible by 2");
                    return;
                }
            }
            if (num % 7 == 0)
            {
                Console.WriteLine("The number is divisible by 7");
                return;
            }
            if (num % 3 == 0)
            {
                Console.WriteLine("The number is divisible by 3");
            }
            if (num % 2 != 0 && num % 3 != 0 && num % 6 != 0 && num % 7 != 0 && num % 10 != 0)
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}
