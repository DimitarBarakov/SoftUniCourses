using System;
using System.Text.RegularExpressions;

namespace Problem_2___Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string pattern = @"@#+[A-Z]\w[^_]{4,}[A-z]@#+";
            string pattern = @"@#+[A-Z][A-Za-z0-9]{4,}[A-Z]@#+";
            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                bool isValid = regex.IsMatch(barcode);
                if (isValid)
                {
                    string productGroup = string.Empty;
                    for (int j = 0; j < barcode.Length; j++)
                    {
                        if (Char.IsDigit(barcode[j]))
                        {
                            productGroup += barcode[j];
                        }
                    }
                    if (productGroup == string.Empty)
                    {
                        productGroup = "00";
                    }
                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
