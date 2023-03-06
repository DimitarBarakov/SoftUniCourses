using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private int age;
        private string firstNamee;
        private string lastName;
        private decimal salary;

        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value < 650)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
                salary = value;
            }
        }


        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                lastName = value;
            }
        }


        public string FirstName
        {
            get { return firstNamee; }
            private set 
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                firstNamee = value; 
            }
        }


        public int Age
        {
            get { return age; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!"); 
                }
                age = value; 
            }
        }

        public Person(string firstname, string lastname, int age, decimal salary)
        {
            this.Salary = salary;
            this.Age = age;
            this.LastName = lastname;
            this.FirstName = firstname;
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                percentage /= 2;
                this.Salary += percentage / 100 * this.Salary; 
            }
            else
            {
                this.Salary += percentage / 100 * this.Salary;
            }
        }
    }
}
