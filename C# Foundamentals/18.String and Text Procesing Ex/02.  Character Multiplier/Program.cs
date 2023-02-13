using System;

namespace _02.__Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            string firstString = words[0];
            string secondString = words[1];
            Console.WriteLine(SumOfDigits(secondString,firstString));
        }

        static int SumOfDigits(string s1, string s2)
        {
            int sum = 0;
            int smallerLength = Math.Min(s1.Length, s2.Length);
            int biggerLength = Math.Max(s1.Length, s2.Length);
            for (int i = 0; i < smallerLength; i++)
            {
                sum += s1[i] * s2[i];
            }
            if (biggerLength!=smallerLength)
            {
                for (int i = smallerLength; i < biggerLength; i++)
                {
                    if (s1.Length == biggerLength)
                    {
                        sum += s1[i];
                    }
                    else
                    {
                        sum += s2[i];
                    }
                }
            }
            return sum;
        }
    }
}
