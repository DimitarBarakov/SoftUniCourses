using System;

namespace _03._Калкулатор_депозити
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            Console.WriteLine(money + months * ((percent/100 * money) / 12));
        }
    }
}
