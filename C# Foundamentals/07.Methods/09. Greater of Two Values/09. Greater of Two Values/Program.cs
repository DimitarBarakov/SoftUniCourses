using System;

namespace _09._Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            if (type == "int")
            {
                int n1 = int.Parse(Console.ReadLine());
                int n2 = int.Parse(Console.ReadLine());
                Console.WriteLine(PrintGreater(n1, n2));
            }
            else if (type == "char")
            {
                char n1 = char.Parse(Console.ReadLine());
                char n2 = char.Parse(Console.ReadLine());
                Console.WriteLine(PrintGreater(n1, n2));
            }
            else if (type == "string")
            {
                string s1 = Console.ReadLine();
                string s2 = Console.ReadLine();
                Console.WriteLine(PrintGreater(s1, s2)); 
            }
        }

        static int PrintGreater(int a, int b)
        {
            if (a>b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
        static char PrintGreater(char a, char b)
        {
            return a >= b ? a : b;
        }
        static string PrintGreater(string a, string b)
        {
            return a.CompareTo(b) >= 0 ? a : b;
        }
    }
}
