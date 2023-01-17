using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string pass = string.Empty;
            for (int i = 0; i < user.Length; i++)
            {
                pass += user[user.Length - i - 1];
            }
            string passTry = Console.ReadLine();
            int trys = 1;
            while (passTry != pass)
            {
                if (trys==4)
                {
                    Console.WriteLine($"User {user} blocked!");
                    return;
                }
                Console.WriteLine("Incorrect password. Try again.");
                passTry = Console.ReadLine();
                trys++;
            }

            Console.WriteLine($"User {user} logged in.");
        }
    }
}
