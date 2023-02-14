using System;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string numberPattern = @"\+359( |-)2\1\d{3}\1\d{4}\b";
            string text = Console.ReadLine();
            Regex regex = new Regex(numberPattern);
            MatchCollection validNumbers = regex.Matches(text);
            Console.WriteLine(String.Join(", ", validNumbers));
        }
    }
}
