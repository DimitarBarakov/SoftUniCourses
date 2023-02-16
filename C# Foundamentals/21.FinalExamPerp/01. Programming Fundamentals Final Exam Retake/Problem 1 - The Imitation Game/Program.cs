using System;

namespace Problem_1___The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string command;
            while ((command = Console.ReadLine()) != "Decode")
            {
                string[] tokens = command.Split('|');
                string action = tokens[0];
                if (action == "Move")
                {
                    int lettersCount = int.Parse(tokens[1]);
                    string letters = text.Substring(0, lettersCount);
                    text = text.Remove(0, lettersCount);
                    text += letters;
                }
                else if (action == "Insert")
                {
                    int index = int.Parse(tokens[1]);
                    string newText = tokens[2];
                    text = text.Insert(index, newText);
                }
                else if (action == "ChangeAll")
                {
                    char oldChar = char.Parse(tokens[1]);
                    char newChar = char.Parse(tokens[2]);
                    text = text.Replace(oldChar, newChar);
                }
            }
            Console.WriteLine($"The decrypted message is: {text}");
        }
    }
}
