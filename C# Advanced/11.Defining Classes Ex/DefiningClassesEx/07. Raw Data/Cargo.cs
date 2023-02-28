

namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Cargo
    {
        private string type;
        private int height;

        public int Weight
        {
            get { return height; }
            set { height = value; }
        }


        public string Type
        {
            get { return type; }
            set { type = value; }
        }

    }
}
