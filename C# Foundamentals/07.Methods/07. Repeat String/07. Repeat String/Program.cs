using System;
using System.Text;

namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int repeatedTimes = int.Parse(Console.ReadLine());
            Console.WriteLine(ReturnNewString(text,repeatedTimes));
        }
        static string ReturnNewString(string text, int n)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                result.Append(text);
            }
            return result.ToString();
        }
    }
}
