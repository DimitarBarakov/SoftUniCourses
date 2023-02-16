using System;

namespace Problem_1___Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string command;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] tokens = command.Split(":|:");
                string action  = tokens[0];
                if (action == "InsertSpace")
                {
                    int index = int.Parse(tokens[1]);
                    text = text.Insert(index, " ");
                    Console.WriteLine(text);
                }
                else if (action == "Reverse")
                {
                    string substring = tokens[1];
                    if (text.Contains(substring))
                    {
                        text = text.Remove(text.IndexOf(substring), substring.Length);
                        string reversedSubstring = "";
                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            reversedSubstring += substring[i];
                        }
                        text = text.Insert(text.Length, reversedSubstring);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    
                }
                else if (action == "ChangeAll")
                {
                    string old = tokens[1];
                    string newString = tokens[2];
                    text = text.Replace(old, newString);
                    Console.WriteLine(text);
                }
            }
            Console.WriteLine($"You have a new text message: {text}");
        }
    }
}
