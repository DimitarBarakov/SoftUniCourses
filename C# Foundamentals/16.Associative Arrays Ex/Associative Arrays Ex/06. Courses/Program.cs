using System;
using System.Collections.Generic;

namespace _06._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> coursesANdStudents = new Dictionary<string, List<string>>();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split(" : ");
                string course = tokens[0];
                string student = tokens[1];
                if (coursesANdStudents.ContainsKey(course))
                {
                    coursesANdStudents[course].Add(student);
                }
                else
                {
                    coursesANdStudents.Add(course, new List<string> {student});
                }
            }
            foreach (var item in coursesANdStudents)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                foreach (var student in item.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
