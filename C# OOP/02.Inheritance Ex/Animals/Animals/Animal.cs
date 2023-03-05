using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }


        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("Invalid output!");
                }
            }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public virtual void ProduceSound()
        {

        } 
    }
}
