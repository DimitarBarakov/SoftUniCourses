using System;

namespace _07._Работно_време
{
    class Program
    {
        static void Main(string[] args)
        {
            int time = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            if (day=="Sunday")
            {
                Console.WriteLine("closed");
            }
            else
            {
                if (time>=10&&time<=18)
                {
                    Console.WriteLine("open");
                }
                else
                {
                    Console.WriteLine("closed");
                }
            }
        }
    }
}
