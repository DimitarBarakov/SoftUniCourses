using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen:ICreature,IBirthable
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Birthdate = birthdate;
            this.Name = name;
            this.Age = age;
            this.Id = id;
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

        public string Birthdate
        { 
            get
            { 
                return this.birthdate; 
            }
            set 
            {
                this.birthdate = value; 
            } 
        }
    }
}
