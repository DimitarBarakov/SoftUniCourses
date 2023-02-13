using System;

namespace _07.__String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '>')
                {
                    int power = (int)(text[i + 1] - '0');
                    int j = i + 1;
                    while (power > 0)
                    {
                        if (text[j] == '>')
                        {
                            power += (int)(text[j + 1] - '0');
                            j++;
                            i++;
                        }
                        text = text.Remove(j, 1);
                        power--;
                    }
                }
            }
            Console.WriteLine(text);
        }
    }
}
