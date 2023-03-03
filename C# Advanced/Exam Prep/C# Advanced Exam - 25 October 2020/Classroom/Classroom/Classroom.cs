using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        private int capacity;
        public int Count { get => Students.Count; }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }


        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        public Classroom(int capacity)
        {
            Students = new List<Student>();
            Capacity = capacity;
        }

        public string RegisterStudent(Student student)
        {
            if (Students.Count < Capacity)
            {
                Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}".TrimEnd();
            }
            return "No seats in the classroom".TrimEnd();
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (Students.Any(s=>s.FirstName == firstName && s.LastName==lastName))
            {
                Students.Remove(Students.First(s => s.FirstName == firstName && s.LastName == lastName));
                return $"Dismissed student {firstName} {lastName}".TrimEnd();
            }
            return "Student not found".TrimEnd();
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> studentsBySubject = students.Where(s => s.Subject == subject).ToList();
            if (studentsBySubject.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (Student student in studentsBySubject)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
                return sb.ToString().TrimEnd();
            }
            return "No students enrolled for the subject".TrimEnd();
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return Students.First(s=>s.FirstName == firstName && s.LastName == lastName);
        }


    }
}
