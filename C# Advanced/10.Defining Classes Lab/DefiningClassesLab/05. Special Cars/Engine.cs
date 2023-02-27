namespace CarManufacturer
{
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public double CubicCapacity
        {
            get { return cubicCapacity; }
            set { cubicCapacity = value; }
        }

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

        public Engine(int horsePower, double cubiccapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubiccapacity;
        }
    }
}
