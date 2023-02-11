using System;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> carAndLicense = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                string[] tokens = command.Split(' ');
                string action = tokens[0];
                string username= tokens[1];

                if (action == "register")
                {
                    string license = tokens[2];
                    if (carAndLicense.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {license}");
                    }
                    else
                    {
                        carAndLicense.Add(username, license);
                        Console.WriteLine($"{username} registered {license} successfully");
                    }
                }
                else
                {
                    if (carAndLicense.ContainsKey(username))
                    {
                        carAndLicense.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");     
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }
            foreach (var item in carAndLicense)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
