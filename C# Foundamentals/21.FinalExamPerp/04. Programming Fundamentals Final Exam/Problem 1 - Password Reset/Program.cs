using System;

namespace Problem_1___Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string comand;
            while ((comand = Console.ReadLine()) != "Done")
            {
                string[] tokens = comand.Split(' ');
                string action = tokens[0];
                if (action == "TakeOdd")
                {
                    string newPassword = "";
                    for (int i = 1; i < password.Length; i+=2)
                    {
                        newPassword += password[i];
                    }
                    password = newPassword;
                    Console.WriteLine(newPassword);
                }
                else if (action == "Cut")
                {
                    int index = int.Parse(tokens[1]);
                    int lenght = int.Parse(tokens[2]);
                    password = password.Remove(index, lenght);
                    Console.WriteLine(password);
                }
                else if (action == "Substitute")
                {
                    string substring = tokens[1];
                    if (password.Contains(substring))
                    {
                        string subtitude = tokens[2];
                        password = password.Replace(substring, subtitude);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
