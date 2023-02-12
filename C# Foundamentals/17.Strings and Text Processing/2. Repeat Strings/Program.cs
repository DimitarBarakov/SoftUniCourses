using System;

namespace _2._Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');
            string res = "";
            foreach (string word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    res += word;
                }
            }
            Console.WriteLine(res);
        }
    }
}
