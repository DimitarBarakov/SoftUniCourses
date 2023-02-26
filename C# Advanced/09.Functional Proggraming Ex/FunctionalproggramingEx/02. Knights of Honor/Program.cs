using System;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = x =>
            Console.WriteLine("Sir " + x);
            string[] names = Console.ReadLine().Split();
            foreach (var item in names)
            {
                print(item);
            }
        }
    }
}
