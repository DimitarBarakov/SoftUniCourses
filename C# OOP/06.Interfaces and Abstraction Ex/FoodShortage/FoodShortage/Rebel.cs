using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel : IBuyer
    {
        private int food;
        private int age;
        private string name;
        private string group;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }

        public string Group
        {
            get { return group; }
            set { group = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public int Food { get { return food; } set { this.food = value; } }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
