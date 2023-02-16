using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem_2___Mirror_words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"(@|#)(?<wordOne>[A-z]{3,})\1(@|#)(?<wordTwo>[A-z]{3,})\1";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);
            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }
            Dictionary<string, string> mirrorWords = new Dictionary<string, string>();
            foreach (Match wordPair in matches)
            {
                string wordOne = wordPair.Groups["wordOne"].Value;
                string reversedWordOne = "";
                for (int i = wordOne.Length - 1; i >= 0; i--)
                {
                    reversedWordOne += wordOne[i];
                }
                string wordTwo = wordPair.Groups["wordTwo"].Value;
                if (reversedWordOne == wordTwo)
                {
                    mirrorWords.Add(wordOne, wordTwo);
                }
            }
            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                List<string> res = new List<string>();
                Console.WriteLine("The mirror words are:");
                foreach (var item in mirrorWords)
                {
                    string elemnet = $"{item.Key} <=> {item.Value}";
                    res.Add(elemnet);
                }
                Console.WriteLine(string.Join(", ",res));
            }
        }
    }
}
