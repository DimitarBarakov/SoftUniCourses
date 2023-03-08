using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public string  Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }


        public string Id
        {
            get { return id; }
            set { id = value; }
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

        private int food;
        public int Food
        {
            get { return this.food; }
            set { this.food = value; }
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
