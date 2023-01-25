using System;

namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            PrintCountOfVowels(text.ToLower());
        }
        static void PrintCountOfVowels(string text)
        {
            int counter = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i]=='a'|| text[i] == 'e' || text[i] == 'i' || text[i] == 'u' || text[i] == 'o')
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
