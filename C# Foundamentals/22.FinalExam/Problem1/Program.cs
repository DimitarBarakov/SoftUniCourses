using System;

namespace Problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string cmd;
            while ((cmd = Console.ReadLine()) != "Done")
            {
                string[] tokens = cmd.Split();
                string action = tokens[0];
                if (action == "Change")
                {
                    char oldChar = char.Parse(tokens[1]);
                    char newChar = char.Parse(tokens[2]);
                    text = text.Replace(oldChar, newChar);
                    Console.WriteLine(text);
                }
                else if (action == "Includes")
                {
                    string substring = tokens[1];
                    Console.WriteLine(text.Contains(substring));
                }
                else if (action == "End")
                {
                    string substring = tokens[1];
                    int substringLenght = substring.Length;
                    //int startIndex = text.Length - substringLenght;
                    //int count = 
                    string endingSubstring = text.Substring(text.Length - substringLenght, substringLenght);
                    if (substring == endingSubstring)
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (action == "Uppercase")
                {
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }
                else if (action == "FindIndex")
                {
                    char charToFind = char.Parse(tokens[1]);
                    Console.WriteLine(text.IndexOf(charToFind));
                }
                else if (action == "Cut")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int count = int.Parse(tokens[2]);
                    text = text.Substring(startIndex, count);
                    Console.WriteLine(text);
                }
            }
        }
    }
}
