using System;
using System.Text;

namespace Problem_1___Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder key = new StringBuilder(text);
            string command;
            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] tokens = command.Split(">>>");
                string action = tokens[0];
                if (action == "Contains")
                {
                    string substring = tokens[1];
                    if (key.ToString().Contains(substring))
                    {
                        Console.WriteLine($"{key} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (action == "Flip")
                {
                    string type = tokens[1];
                    int startIndex = int.Parse(tokens[2]);
                    int endIndex = int.Parse(tokens[3]);
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        if (type == "Lower")
                        {
                            if (Char.IsLetter(key[i]))
                            {
                                key[i] = Char.ToLower(key[i]);
                            }
                        }
                        else if (type == "Upper")
                        {
                            if (Char.IsLetter(key[i]))
                            {
                                key[i] = Char.ToUpper(key[i]);
                            }
                        }
                    }
                    Console.WriteLine(key);
                }
                else if (action == "Slice")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    int lenght = endIndex - startIndex;
                    key.Remove(startIndex, lenght);
                    Console.WriteLine(key);
                }
            }
            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
