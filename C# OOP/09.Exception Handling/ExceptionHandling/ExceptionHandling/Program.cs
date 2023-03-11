using System;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string a = "\u2663";
            Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}
