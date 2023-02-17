using System;
using System.Text.RegularExpressions;

namespace Problem2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\|(?<bossName>[A-Z]{4,})\|:#(?<title>[A-Za-z]{2,} [A-Za-z]{2,})#";
            Regex regex = new Regex(pattern);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string bossAndTItle = Console.ReadLine();
                bool IsMatch = regex.IsMatch(bossAndTItle);
                if (IsMatch)
                {
                    Match match = regex.Match(bossAndTItle);
                    string bossName = match.Groups["bossName"].Value;
                    string bossTitle = match.Groups["title"].Value;
                    Console.WriteLine($"{bossName}, The {bossTitle}");
                    Console.WriteLine($">> Strength: {bossName.Length}");
                    Console.WriteLine($">> Armor: {bossTitle.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
