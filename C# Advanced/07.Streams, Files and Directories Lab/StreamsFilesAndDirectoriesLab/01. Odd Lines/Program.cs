using System;
using System.IO;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader streamReader = new StreamReader(inputFilePath);
            using (streamReader)
            {
                int lineNum = 0;
                string line;
                StreamWriter streamWriter = new StreamWriter(outputFilePath);
                using (streamWriter)
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (lineNum % 2 != 0)
                        {
                            streamWriter.WriteLine(line);
                        }
                        lineNum++;
                    }
                }
            }
        }
    }
}
