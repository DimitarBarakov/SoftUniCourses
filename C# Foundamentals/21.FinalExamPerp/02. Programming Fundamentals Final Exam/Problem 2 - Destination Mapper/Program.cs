using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem_2___Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(=|\/)(?<place>[A-Z][A-z]{2,})\1";
            string map = Console.ReadLine();
            Regex regex = new Regex(pattern);
            MatchCollection places = regex.Matches(map);
            int totalPoint = 0;
            List<string> placesInList = new List<string>();
            foreach (Match match in places)
            {
                placesInList.Add(match.Groups["place"].Value);
                totalPoint+=match.Groups["place"].Value.Length;
            }
            Console.Write("Destinations: ");
            Console.WriteLine(string.Join(", ", placesInList));
            Console.WriteLine($"Travel Points: {totalPoint}");
        }
    }
}
