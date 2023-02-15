using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            double total = 0;
            while ((command = Console.ReadLine())!="end of shift")
            {
                string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*?<(?<product>\w+)>[^|$%.]*?\|(?<count>\d+)\|[^|$%.]*?((?<price>\d+\.\d+|\d+))\$";
                Regex regex = new Regex(pattern);
                bool isValid = regex.IsMatch(command);
                if (isValid)
                {
                    Match validOrder = regex.Match(command);
                    Console.WriteLine($"{validOrder.Groups["customer"].Value}: {validOrder.Groups["product"].Value} - {(int.Parse(validOrder.Groups["count"].Value) * double.Parse(validOrder.Groups["price"].Value)):f2}");
                    total += int.Parse(validOrder.Groups["count"].Value) * double.Parse(validOrder.Groups["price"].Value);
                }
            }
            Console.WriteLine($"Total income: {total:f2}");
        }
    }
}
