using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Tire[] tires = new Tire[]
            {
                new Tire(1,2.5),
                new Tire(2,2.3),
                new Tire(1,0.8),
                new Tire(2, 0.9)
            };

            Engine engine = new Engine(560, 6300);
            Car lambo = new Car("Lambo", "Gallardo", 2010, 250, 9,engine,tires);
        }
    }
}
