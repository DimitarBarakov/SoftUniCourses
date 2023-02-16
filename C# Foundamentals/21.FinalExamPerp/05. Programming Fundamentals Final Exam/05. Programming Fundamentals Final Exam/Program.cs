using System;
using System.Text;

namespace _05._Programming_Fundamentals_Final_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder asd = new StringBuilder("qweasdzxc");
            asd[2] = Char.ToUpper(asd[2]);
            Console.WriteLine(asd);
        }
    }
}
