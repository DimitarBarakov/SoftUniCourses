using System;

namespace _03._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] filePath = Console.ReadLine().Split("\\");
            string[] fileNameAndEx = filePath[filePath.Length - 1].Split('.');
            string fileNmae = fileNameAndEx[0];
            string fileEx = fileNameAndEx[1];
            Console.WriteLine($"File name: {fileNmae}");
            Console.WriteLine($"File extension: {fileEx}");
        }
    }
}
