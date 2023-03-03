using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryOpenning
{
    public class Employee
    {
        private string name;
        private int age;
        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }


        public int Age
        {
            get { return age; }
            set { age = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Employee(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }
        public override string ToString()
        {
            return $"Employee: {Name}, {Age} ({Country})".TrimEnd(); 
        }
    }
}
