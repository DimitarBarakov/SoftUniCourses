using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void AddDriverShouldThrowExceptionIfDriverIsNull()
        {
            RaceEntry entry = new RaceEntry();
            UnitDriver driver = null;

            Assert.Throws<InvalidOperationException>(() =>
            {
                entry.AddDriver(driver);
            }, "Driver cannot be null.");
        }
        [Test]
        public void AddDriverShouldThrowExceptionIfDriverExists()
        {
            RaceEntry entry = new RaceEntry();
            UnitDriver driver = new UnitDriver("asd", new UnitCar("qwe", 123, 21));
            UnitDriver driver1 = new UnitDriver("asd", new UnitCar("bmw", 134, 56));

            Assert.Throws<InvalidOperationException>(() =>
            {
                entry.AddDriver(driver);
                entry.AddDriver(driver1);
            }, "Driver asd is already added.");
        }
        [Test]
        public void AddDriverShouldWork()
        {
            RaceEntry entry = new RaceEntry();
            UnitDriver driver = new UnitDriver("asd", new UnitCar("qwe", 123, 21));
            UnitDriver driver1 = new UnitDriver("mite", new UnitCar("bmw", 134, 56));
            entry.AddDriver(driver);
            string res = entry.AddDriver(driver1);
            Assert.AreEqual(res, "Driver mite added in race.");
            Assert.AreEqual(2, entry.Counter);
        }
        [Test]
        public void CalculateAverageHorsePowerShouldThrowException()
        {
            RaceEntry entry = new RaceEntry();
            UnitDriver driver = new UnitDriver("asd", new UnitCar("qwe", 123, 21));
            UnitDriver driver1 = new UnitDriver("mite", new UnitCar("bmw", 134, 56));
            entry.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() =>
            {
                entry.CalculateAverageHorsePower();
            }, "The race cannot start with less than 2 participants.");
        }
        [Test]
        public void CalculateAverageHorsePowerShouldWork()
        {
            RaceEntry entry = new RaceEntry();
            UnitDriver driver = new UnitDriver("asd", new UnitCar("qwe", 20, 21));
            UnitDriver driver1 = new UnitDriver("mite", new UnitCar("bmw", 50, 56));
            entry.AddDriver(driver);
            entry.AddDriver(driver1);
            double res = entry.CalculateAverageHorsePower();
            Assert.AreEqual(35, res);
        }
    }
}