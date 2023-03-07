using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ');
            string[] sites = Console.ReadLine().Split(' ');
            IPhone phone;

            foreach (var number in numbers)
            {
                if (number.All(char.IsDigit))
                {
                    if (number.Length == 10)
                    {
                        phone = new Smartphone();
                    }
                    else
                    {
                        phone = new Stationary();
                    }
                    phone.Calling(number);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
            foreach (var site in sites)
            {
                if (ValidateSite(site))
                {
                    Smartphone smartphone = new Smartphone();
                    smartphone.Browsing(site);
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }
        public static bool ValidateSite(string site)
        {
            bool isValid = true;
            foreach (var character in site)
            {
                if (char.IsDigit(character))
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }
    }
}
