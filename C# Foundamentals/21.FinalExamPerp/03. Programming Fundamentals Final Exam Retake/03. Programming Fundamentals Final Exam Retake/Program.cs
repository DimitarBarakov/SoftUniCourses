using System;

namespace _03._Programming_Fundamentals_Final_Exam_Retake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string substring = "asd";
            text = text.Remove(text.IndexOf(substring), substring.Length);
            Console.WriteLine(text);
        }
    }
}
