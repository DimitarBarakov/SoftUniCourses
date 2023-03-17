using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            Garage garage;
            [SetUp]
            public void SetUp()
            {
                string name = "asd";
                int mechs = 2;
                garage = new Garage(name, mechs);
            }
            [Test]
            public void Constructor()
            {
                string name = "asd";
                int mechs = 2;
                Garage garage = new Garage(name, mechs);
                Assert.That(name, Is.EqualTo(garage.Name));
                Assert.That(mechs, Is.EqualTo(garage.MechanicsAvailable));
            }
            [Test]
            [TestCase("")]
            [TestCase(null)]
            public void NameShouldThrowException(string name)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    this.garage = new Garage(name,2);
                }, "Invalid garage name.");
            }

            [Test]
            [TestCase(0)]
            [TestCase(-1)]
            public void MechsShouldBeMoreThan0(int mechs)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    this.garage = new Garage("asd", mechs);
                }, "At least one mechanic must work in the garage.");
            }
        }
    }
}