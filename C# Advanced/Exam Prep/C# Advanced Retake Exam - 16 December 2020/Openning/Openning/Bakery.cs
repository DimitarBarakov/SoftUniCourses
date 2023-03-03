using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private string name;
        private int capacity;
        private List<Employee> data;

        public List<Employee> Data
        {
            get { return data; }
            set { data = value; }
        }


        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Count
        {
            get => Data.Count();
        }

        public Bakery(string name, int capacity)
        {
            Data = new List<Employee>();
            Name = name;
            Capacity = capacity;
        }

        public void Add(Employee employee)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            if (Data.Any(e=>e.Name == name))
            {
                Data.Remove(data.First(e => e.Name == name));
                return true;
            }
            return false;
        }

        public Employee GetOldestEmployee()
        {
            int oldestAge = 0;
            foreach (var employee in Data)
            {
                if (employee.Age > oldestAge)
                {
                    oldestAge = employee.Age;
                }
            }
            return Data.First(e=>e.Age == oldestAge);
        }
        
        public Employee GetEmployee(string name)
        {
            return Data.First(e => e.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var employee in Data)
            {
                sb.AppendLine(employee.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
