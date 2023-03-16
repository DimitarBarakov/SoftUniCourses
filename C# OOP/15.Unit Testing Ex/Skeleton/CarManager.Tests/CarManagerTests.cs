namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        [Test]
        public void ConstructorShouldReturnTheRIghtValues()
        {
            string make = "audi";
            string model = "a5";
            double fuelConsumption = 0.9;
            double fuelCapacity = 20;
            this.car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(this.car.Make, Is.EqualTo("audi"));
            Assert.That(this.car.Model, Is.EqualTo("a5"));
            Assert.That(this.car.FuelConsumption, Is.EqualTo(0.9));
            Assert.That(this.car.FuelCapacity, Is.EqualTo(20));
            Assert.That(this.car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void MakeSetterShouldThrowArgumentException()
        {
            string make = "";
            string model = "a5";
            double fuelConsumption = 0.9;
            double fuelCapacity = 20;

            Assert.Throws<ArgumentException>(() =>
            {
                this.car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Make cannot be null or empty!");
        }

        [Test]
        public void ModelSetterShouldThrowArgumentException()
        {
            string make = "audi";
            string model = "";
            double fuelConsumption = 0.9;
            double fuelCapacity = 20;

            Assert.Throws<ArgumentException>(() =>
            {
                this.car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Model cannot be null or empty!");
        }

        [Test]
        [TestCase(new double[] { 0 })]
        [TestCase(new double[] { -2 })]
        public void FuelConsuptionSetterShouldThrowArgumentException(double[] cons)
        {
            string make = "audi";
            string model = "a5";
            double fuelConsumption = cons[0];
            double fuelCapacity = 20;

            Assert.Throws<ArgumentException>(() =>
            {
                this.car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Fuel consumption cannot be zero or negative!");
        }

        //[Test]
        //public void FuelAmountSetterShouldThrowArgumentException()
        //{
        //    string make = "audi";
        //    string model = "a5";
        //    double fuelConsumption = 0.9;
        //    double fuelCapacity = 20;

        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        this.car = new Car(make, model, fuelConsumption, fuelCapacity);
        //    }, "Fuel amount cannot be negative!");
        //}

        [Test]
        [TestCase(new double[] { 0 })]
        [TestCase(new double[] { -2 })]
        public void FuelCapacitySetterShouldThrowArgumentException(double[] cap)
        {
            string make = "audi";
            string model = "a5";
            double fuelConsumption = 0;
            double fuelCapacity = cap[0];

            Assert.Throws<ArgumentException>(() =>
            {
                this.car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        [TestCase(new double[] { 0 })]
        [TestCase(new double[] { -21 })]
        public void RefuelShouldThrowArgumentException(double[] fuel)
        {
            string make = "audi";
            string model = "a5";
            double fuelConsumption = 0.9;
            double fuelCapacity = 20;
            this.car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuel[0]);
            }, "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void RefuelShouldAddFuelToAmount()
        {
            string make = "audi";
            string model = "a5";
            double fuelConsumption = 0.9;
            double fuelCapacity = 20;
            this.car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(10);
            Assert.AreEqual(10,car.FuelAmount);
        }

        [Test]
        public void RefuelShouldAddFuelOnlyToFillCapacity()
        {
            string make = "audi";
            string model = "a5";
            double fuelConsumption = 0.9;
            double fuelCapacity = 20;
            this.car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(25);
            Assert.AreEqual(car.FuelCapacity,car.FuelAmount);
        }

        [Test]
        public void DriveShouldThrowInvalidOperation()
        {
            string make = "audi";
            string model = "a5";
            double fuelConsumption = 10;
            double fuelCapacity = 20;

            this.car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(10);

            double distance = 200;
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            }, "You don't have enough fuel to drive!");
        }

        [Test]
        public void DriveShoulReduceFuelAmount()
        {
            string make = "audi";
            string model = "a5";
            double fuelConsumption = 10;
            double fuelCapacity = 50;

            this.car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(30);

            double distance = 200;
            car.Drive(distance);

            Assert.AreEqual(10, car.FuelAmount);
        }
        [Test]
        public void TestFuelAmount()
        {
            string make = "audi";
            string model = "a5";
            double fuelConsumption = 10;
            double fuelCapacity = 50;

            this.car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.AreEqual(0, this.car.FuelAmount);
        }
    }
}