using System;
using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Racer
    {
        private string name;
        private int age;
        private Car car;
        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }


        public Car Car
        {
            get { return car; }
            set { car = value; }
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

        public Racer(string name, int age, string country, Car Car)
        {
            Name = name;
            Age = age;
            Country = country;
            this.Car = Car;
        }
        public override string ToString()
        {
            return $"Racer: {Name}, {Age} ({Country})".TrimEnd();
        }
    }
}
