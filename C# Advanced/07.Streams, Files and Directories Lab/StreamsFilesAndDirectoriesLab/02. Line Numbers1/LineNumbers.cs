namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            using (reader)
            {
                string line;
                StreamWriter writer = new StreamWriter(outputFilePath);
                using (writer)
                {
                    int num = 1;
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(num + ". " + line);
                        num++;
                    }
                }
            }
        }
    }
}
