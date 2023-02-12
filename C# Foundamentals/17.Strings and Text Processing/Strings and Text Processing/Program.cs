using System;
using System.Text;

namespace Strings_and_Text_Processing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string asd = Console.ReadLine();
            StringBuilder text = new StringBuilder(asd);   
            for (int i = 1; i < 4; i++)
            {
                text[i] = Char.ToUpper(text[i]);
            }
            Console.WriteLine(text);
        }
    }
}
