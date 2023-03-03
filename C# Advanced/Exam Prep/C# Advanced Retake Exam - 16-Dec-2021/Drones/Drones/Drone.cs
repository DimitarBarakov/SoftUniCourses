using System;

namespace Drones
{
    public class Drone
    {
        private int range;
        private string name;
        private string brand;
        private bool available;

        public Drone()
        {

        }
        public bool Available
        {
            get { return available; }
            set { available = value; }
        }


        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }



        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int Range
        {
            get { return range; }
            set { range = value; }
        }

        public Drone(string name, string brand, int range)
        {
            this.Name = name;
            this.Brand = brand;
            this.Range = range;
            Available = true;
        }

        public override string ToString()
        {
            return $"Drone: {this.Name} \n\rManufactured by: { this.Brand} \n\rRange: { this.Range} kilometers";

        }

        internal static object OrderByDescending(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}