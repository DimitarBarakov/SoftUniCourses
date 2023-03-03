using System;
using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Car
    {
        private int speed;
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public Car(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }
    }
}
