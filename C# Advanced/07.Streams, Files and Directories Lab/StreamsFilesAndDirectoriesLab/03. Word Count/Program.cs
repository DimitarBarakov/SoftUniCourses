namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            using (StreamReader wordsReader = new StreamReader(wordsFilePath))
            {
                string[] line = wordsReader.ReadLine().Split();
                foreach (var word in line)
                {
                    words.Add(word, 0);
                }
            }
            using (StreamReader reader = new StreamReader(textFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] tokens = line.Split().Select(w => w.ToLower()).ToArray();
                    foreach (var w in tokens)
                    {
                        if (words.ContainsKey(w))
                        {
                            words[w]++;
                        }
                    }
                }
            }
            using(StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var word in words)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");

                }
            }
        }
    }
}