using System;

namespace _06.__Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            for (int i = 0; i < text.Length; i++)
            {
                char currChar = text[i];
                int currCharCount = 1;
                for (int j = i+1; j < text.Length; j++)
                {
                    if (currChar == text[j])
                    {
                        currCharCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (currCharCount > 1)
                {
                    text = text.Remove(i, currCharCount - 1);
                }
            }
            Console.WriteLine(text);
        }
    }
}
