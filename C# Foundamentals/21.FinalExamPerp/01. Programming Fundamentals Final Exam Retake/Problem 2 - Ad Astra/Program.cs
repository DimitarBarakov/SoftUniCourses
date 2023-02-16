using System;
using System.Text.RegularExpressions;

namespace Problem_2___Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(#|\|)(?<name>[A-z]+ *[A-z]*)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1";
            string text = Console.ReadLine();
            Regex regex = new Regex(pattern);
            MatchCollection validFoofInfo = regex.Matches(text);

            int totalCalories = 0;
            foreach (Match match in validFoofInfo)
            {
                totalCalories += int.Parse(match.Groups["calories"].Value);
            }
            int days = 0;
            while (totalCalories>=2000)
            {
                days++;
                totalCalories -= 2000;
            }
            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (Match match in validFoofInfo)
            {
                Console.WriteLine($"Item: {match.Groups["name"].Value}, Best before: {match.Groups["date"].Value}, Nutrition: {match.Groups["calories"].Value}");
            }
        }
    }
}
