using System;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = x => 
            Console.WriteLine(x);
            string[] names = Console.ReadLine().Split();
            foreach (var item in names)
            {
                print(item);
            }
        }
    }
}
