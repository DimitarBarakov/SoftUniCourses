﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet:IBirthable
    {
        private string name;
        private string birthdate;

        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
        public string Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
