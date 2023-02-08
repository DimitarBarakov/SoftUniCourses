using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] elemnets = Console.ReadLine().Split().ToArray();
                Student newStudent = new Student()
                {
                    FirstName = elemnets[0],
                    LastName = elemnets[1],
                    Grade = double.Parse(elemnets[2])
                };
                students.Add(newStudent);
            }
            List<Student> orderedByGrade = students.OrderByDescending(student => student.Grade).ToList();
            foreach (var student in orderedByGrade)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
}
