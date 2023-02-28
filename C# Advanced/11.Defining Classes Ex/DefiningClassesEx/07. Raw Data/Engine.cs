

namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Engine
    {
        private int speed;
        private int power;

        public int Power
        {
            get { return power; }
            set { power = value; }
        }


        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

    }
}
