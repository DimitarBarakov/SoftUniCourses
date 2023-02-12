using System;
using System.Text;

namespace _05._Digits__Letters__and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder nums = new StringBuilder();
            StringBuilder chars = new StringBuilder();
            StringBuilder other = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                string asd = text[i].ToString().ToLower();
                if (char.IsLetter(text[i]))
                {
                    chars.Append(text[i]);
                }
                else if(char.IsDigit(text[i]))
                {
                    nums.Append(text[i]);
                }
                else
                {
                    other.Append(text[i]);
                }
            }
            Console.WriteLine(nums);
            Console.WriteLine(chars);
            Console.WriteLine(other);
        }
    }
}
