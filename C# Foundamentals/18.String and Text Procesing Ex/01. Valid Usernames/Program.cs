using System;

namespace _01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            foreach (string username in usernames)
            {
                bool isValid = true;
                if (username.Length < 3 || username.Length > 16)
                {
                    isValid = false;
                }
                for (int i = 0; i < username.Length; i++)
                {
                    if (!Char.IsLetterOrDigit(username[i]))
                    {
                        if (username[i] != '-' && username[i] != '_')
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
                if (isValid)
                {
                    Console.WriteLine(username);
                }
            }
        }
    }
}
