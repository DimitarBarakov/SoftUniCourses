using System;
using System.Collections.Generic;

namespace _03._Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> synonymsOfWords = new Dictionary<string, List<string>>();
            for (int i = 1; i <= n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (synonymsOfWords.ContainsKey(word))
                {
                    synonymsOfWords[word].Add(synonym);
                }
                else
                {
                    synonymsOfWords.Add(word, new List<string>() { synonym });
                }
            }
            foreach (var item in synonymsOfWords)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        }
    }
}
