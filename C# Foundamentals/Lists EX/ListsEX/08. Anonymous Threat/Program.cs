using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split().ToList();
            string command;
            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] tokens = command.Split();
                string action = tokens[0];
                if (action == "merge")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if (endIndex > elements.Count)
                    {
                        endIndex = elements.Count -1;
                    }
                    Merge(elements, startIndex, endIndex);
                }
                else if (action == "divide")
                {
                    int index = int.Parse(tokens[1]);
                    int portions = int.Parse(tokens[2]);
                }
            }
            Console.WriteLine(String.Join(' ', elements));
        }

        static List<string> Merge(List<string> elements, int startIndex, int endIndex)
        {
            //int count = 0;
            for (int i = startIndex; i < endIndex; i++)
            {
                elements[i] += elements[i + 1];
                elements.RemoveAt(i + 1);
                i--;
                endIndex--;
                //count++;
                //if (count == endIndex-startIndex)
                //{
                //    break;
                //}
            }
            return elements;
        }

        static List<string> Divide(List<string> elements, int index, int portions)
        {
            string elementToDivide
        }
    }
}
