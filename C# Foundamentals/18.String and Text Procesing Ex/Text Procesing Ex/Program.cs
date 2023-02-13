using System;

namespace Text_Procesing_Ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            text = text.Remove(2, 1);
            Console.WriteLine(text);
        }
    }
}
