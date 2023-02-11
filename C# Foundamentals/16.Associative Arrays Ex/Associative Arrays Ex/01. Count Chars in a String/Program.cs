using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<char, int> charsCount = new Dictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                {
                    if (charsCount.ContainsKey(text[i]))
                    {
                        charsCount[text[i]]++;
                    }
                    else
                    {
                          charsCount.Add(text[i], 1);
                    }
                }
            }
            foreach (var item in charsCount)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
