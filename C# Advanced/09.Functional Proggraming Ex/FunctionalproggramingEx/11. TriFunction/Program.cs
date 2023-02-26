using System;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] words = Console.ReadLine().Split();
            foreach (var word in words)
            {
                int sum = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    sum+=word[i];
                }
                if (sum >= n)
                {
                    Console.WriteLine(word);
                    return;
                }
            }
        }
    }
}
