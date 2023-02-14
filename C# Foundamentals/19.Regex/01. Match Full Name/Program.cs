using System;
using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string namePattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            string text = Console.ReadLine();
            Regex regex = new Regex(namePattern);
            MatchCollection validNames = regex.Matches(text);
            foreach (Match name in validNames)
            {
                Console.Write(name.Value + " ");
            }
        }
    }
}
