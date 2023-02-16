using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem_2___Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(::|\*\*)(?<emoji>[A-Z][a-z]{2,})\1";
            string  text = Console.ReadLine();
            Regex regex = new Regex(pattern);
            MatchCollection validEmojis = regex.Matches(text);

            long threshold = 1;
            foreach (var letter in text)
            {
                if (Char.IsDigit(letter))
                {
                    int digit = letter - '0';
                    threshold *= digit;
                }
            }
            List<string> coolEmojis = new List<string>();
            foreach (Match emoji in validEmojis)
            {
                int currentEmojiCoolness = 0;
                foreach(char letter in emoji.Groups["emoji"].Value)
                {
                    currentEmojiCoolness += letter;
                }
                if (currentEmojiCoolness >= threshold)
                {
                    coolEmojis.Add(emoji.Value);
                }
            }
            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{validEmojis.Count} emojis found in the text. The cool ones are:");
            foreach (string emoji in coolEmojis)
            {
                Console.WriteLine(emoji);
            }
        }
    }
}
