﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot:ICreature
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }

    }
}
