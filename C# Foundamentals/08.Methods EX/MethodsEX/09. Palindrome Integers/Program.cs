using System;

namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            while ((command=Console.ReadLine())!="END")
            {
                int number = int.Parse(command);
                Console.WriteLine(IsPolindrome(number).ToString().ToLower());
            }
        }

        static bool IsPolindrome(int n)
        {
            int num = n;
            int reversed = 0;
            while (num>0)
            {
                reversed = reversed * 10 + num%10;
                num /= 10;
            }
            if (reversed==n)
            {
                return true;
            }
            return false;
        }
    }
}
