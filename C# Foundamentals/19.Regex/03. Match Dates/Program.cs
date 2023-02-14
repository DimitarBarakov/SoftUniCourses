using System;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string datePattern = @"(?<day>\d{2})(\.|-|\/)(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})";
            string input = Console.ReadLine();
            Regex regex = new Regex(datePattern);
            MatchCollection validDates = regex.Matches(input);
            foreach (Match date in validDates)
            {
                Console.WriteLine($"Day: {date.Groups["day"]}, Month: {date.Groups["month"]}, Year: {date.Groups["year"]}");
            }
         }
    }
}
