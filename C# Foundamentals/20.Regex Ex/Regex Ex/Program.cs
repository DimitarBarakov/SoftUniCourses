using System;
using System.Text.RegularExpressions;

namespace Regex_Ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string namePattern = @"[A-z]";
            string kilosPattern = @"[0-9]";
            Regex regex = new Regex(namePattern);
            MatchCollection letters = regex.Matches(input);
            foreach (Match match in letters)
            {
                name += match.Value;
            }
            MatchCollection numbers = regex.Matches(input);
            foreach (Match item in numbers)
            {
                kilo += int.Parse(item.Value);
            }
            Console.WriteLine(kilo);
        }
    }
}
