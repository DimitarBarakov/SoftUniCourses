using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<product>\w+)<<(?<price>\d+\.\d+|\d+)!(?<count>\d+)";
            string text;
            List<string> products = new List<string>();
            double totalPrice = 0;
            while ((text = Console.ReadLine())!="Purchase")
            {
                Regex regex = new Regex(pattern);
                bool isProductValid = regex.IsMatch(text);
                if (isProductValid)
                {
                    Match product = regex.Match(text);
                    products.Add(product.Groups["product"].Value);
                    totalPrice += double.Parse(product.Groups["price"].Value) * int.Parse(product.Groups["count"].Value);
                }
            }
            Console.WriteLine("Bought furniture:");
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
