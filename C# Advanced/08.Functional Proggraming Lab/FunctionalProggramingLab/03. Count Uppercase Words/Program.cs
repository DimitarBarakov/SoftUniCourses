using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();
            Predicate<string> isUpper = s => s.Length > 0 && char.IsUpper(s[0]);
            List<string> capitalWords = words.Where(w => isUpper(w)).ToList();
            foreach (string word in capitalWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
