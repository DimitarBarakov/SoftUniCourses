using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ").ToList();
            string command;
            while ((command = Console.ReadLine()) != "course start")
            {
                string[] tokens = command.Split(':');
                string action = tokens[0];
                if (action == "Add")
                {
                    string lesson = tokens[1];
                    if (lessons.Contains(lesson))
                    {
                        continue;
                    }
                    else
                    {
                        lessons.Add(lesson);
                    }
                }
                else if (action == "Insert")
                {
                    string lesson = tokens[1];
                    if (lessons.Contains(lesson))
                    {
                        continue;
                    }
                    else
                    {
                        int index = int.Parse(tokens[2]);
                        lessons.Insert(index, lesson);
                    }
                }
                else if (action == "Remove")
                {
                    string lesson = tokens[1];
                    if (lessons.Contains(lesson))
                    {
                        lessons.Remove(lesson);
                        if (lessons.Contains($"{lesson}-Exercise"))
                        {
                            lessons.Remove($"{lesson}-Exercise");
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (action == "Swap")
                {
                    string firstElement = tokens[1];
                    string secondElement = tokens[2];
                    if (lessons.Contains(firstElement)&&lessons.Contains(secondElement))
                    {
                        int firstElementIndex = lessons.IndexOf(firstElement);
                        int secondElementIndex = lessons.IndexOf(secondElement);
                        string temp = lessons[firstElementIndex];
                        lessons[firstElementIndex] = lessons[secondElementIndex];
                        lessons[secondElementIndex] = temp;
                        if (lessons.Contains($"{firstElement}-Exercise") && lessons.Contains($"{secondElement}-Exercise"))
                        {
                            string temp1 = lessons[firstElementIndex + 1];
                            lessons[firstElementIndex + 1] = lessons[secondElementIndex + 1];
                            lessons[secondElementIndex + 1] = temp1;
                        }
                        else if (lessons.Contains($"{firstElement}-Exercise") && !lessons.Contains($"{secondElement}-Exercise"))
                        {
                            lessons.Insert(lessons.IndexOf(firstElement) + 1,$"{firstElement}-Exercise");
                            lessons.Remove($"{firstElement}-Exercise");
                        }
                        else if (!lessons.Contains($"{firstElement}-Exercise") && lessons.Contains($"{secondElement}-Exercise"))
                        {
                            lessons.Remove($"{secondElement}-Exercise");
                            lessons.Insert(lessons.IndexOf(secondElement) + 1, $"{secondElement}-Exercise");
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (action == "Exercise")
                {
                    string lesson = tokens[1];
                    if (lessons.Contains(lesson))
                    {
                        if (lessons.Contains($"{lesson}-Exercise"))
                        {
                            continue;
                        }
                        else
                        {
                            lessons.Insert(lessons.IndexOf(lesson) + 1, $"{lesson}-Exercise");
                        }
                    }
                    else
                    {
                        lessons.Add(lesson);
                        lessons.Add($"{lesson}-Exercise");
                    }
                }
            }
            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i+1}.{lessons[i]}");
            }
        }
    }
}
