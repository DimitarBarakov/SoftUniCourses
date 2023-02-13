using System;
using System.Text;

namespace _04.__Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            StringBuilder text = new StringBuilder(a);
            for (int i = 0; i < text.Length; i++)
            {
                int currCharAsNum = (int)text[i];
                char charToReplace = (char)(currCharAsNum + 3);
                text[i] = charToReplace;
            }
            Console.WriteLine(text.ToString());
        }
    }
}
