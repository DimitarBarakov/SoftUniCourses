using System;

namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            if (!IsValidLenght(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!IsCharactersValid(password.ToLower()))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!isPassContainsTwoDigits(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (IsValidLenght(password) && IsCharactersValid(password.ToLower())&& isPassContainsTwoDigits(password))
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool IsValidLenght(string pass)
        {
            if (pass.Length >= 6 && pass.Length <= 10)
            {
                return true;
            }
            return false;
        }
        static bool IsCharactersValid(string pass)
        {
            bool isValid = true;
            for (int i = 0; i < pass.Length; i++)
            {
                if (((int)pass[i]>=48&&(int)pass[i]<=57)||((int)pass[i] >= 97 && (int)pass[i] <= 121))
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }
        static bool isPassContainsTwoDigits(string pass)
        {
            int count = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                if ((int)pass[i] >= 48 && (int)pass[i] <= 57)
                {
                    count++;
                }
            }
            if (count>=2)
            {
                return true;
            }
            return false;
        }
    }
}
