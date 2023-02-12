using System;

namespace _01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            while (text != "end")
            {
                string res = "";
                for (int i = text.Length - 1; i >= 0; i--)
                {
                    res += text[i];
                }
                Console.WriteLine($"{text} = {res}");
                text = Console.ReadLine();
            }
        }
    }
}
