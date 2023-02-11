using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentAndGrades = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i <n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (studentAndGrades.ContainsKey(name))
                {
                    studentAndGrades[name].Add(grade);
                }
                else
                {
                    studentAndGrades.Add(name, new List<double> { grade });
                }
            }

            Dictionary<string, double> filtered = new Dictionary<string, double>();
            foreach (var item in studentAndGrades)
            {
                if (item.Value.Average() >= 4.50)
                {
                    filtered.Add(item.Key, item.Value.Average());
                }
            }
            foreach (var item in filtered)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:f2}");
            }
        }
    }
}
