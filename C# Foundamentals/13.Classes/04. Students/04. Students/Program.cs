using System;
using System.Collections.Generic;

namespace _04._Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();   
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split();
                
                Student student = new Student();
                student.FirstName = tokens[0];
                student.LastName = tokens[1];
                student.Age = int.Parse(tokens[2]);
                student.HomeTown = tokens[3];

                students.Add(student);
            }

            string city = Console.ReadLine();
            foreach (var student in students)
            {
                if (student.HomeTown == city)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
}
