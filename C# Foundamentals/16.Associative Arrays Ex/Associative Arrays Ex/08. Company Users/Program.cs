using System;
using System.Collections.Generic;

namespace _08._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyAndEmployee = new Dictionary<string, List<string>>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" -> ");
                string company = tokens[0];
                string employee = tokens[1];
                if (companyAndEmployee.ContainsKey(company))
                {
                    if (!companyAndEmployee[company].Contains(employee))
                    {
                        companyAndEmployee[company].Add(employee);
                    }
                }
                else
                {
                    companyAndEmployee.Add(company, new List<string> { employee });
                }
            }

            foreach (var item in companyAndEmployee)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var emp in item.Value)
                {
                    Console.WriteLine($"-- {emp}");
                }
            }
        }
    }
}
