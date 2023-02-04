using System;

namespace Problem_1___SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());
            int allEmployeesEfficiency = thirdEmployeeEfficiency + secondEmployeeEfficiency + firstEmployeeEfficiency;
            int students = int.Parse(Console.ReadLine());
            int hours = 0;
            while (students > 0)
            {
                students -= allEmployeesEfficiency;
                hours++;
                if (hours%4==0)
                {
                    hours++;
                }
            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
