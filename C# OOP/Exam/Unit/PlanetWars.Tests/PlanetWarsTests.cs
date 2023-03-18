using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void Name()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var planet = new Planet(null, 23);
                }, "Invalid planet Name");

            }
            [Test]
            public void Budget()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var planet = new Planet("asd", -1);
                }, "Budget cannot drop below Zero!");
            }
            [Test]
            public void MilitaryRatio()
            {
                var planet = new Planet("asd", 11);
                Weapon weapon = new Weapon("qwe", 2, 34);
                planet.AddWeapon(weapon);
                Weapon weapon1 = new Weapon("kurec", 1, 33);
                planet.AddWeapon(weapon1);
                Assert.AreEqual(67, planet.MilitaryPowerRatio);
            }
            [Test]
            public void Profit()
            {
                var planet = new Planet("asd", 11);
                planet.Profit(1);
                Assert.AreEqual(12, planet.Budget);
            }
            [Test]
            public void SPendFundsThrowExc()
            {
                var planet = new Planet("asd", 11);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(12);
                }, "Not enough funds to finalize the deal.");
            }
            [Test]
            public void SPendFundsWok()
            {
                var planet = new Planet("asd", 11);
                planet.SpendFunds(2);
                Assert.AreEqual(9, planet.Budget);
            }
            [Test]
            public void AddWeaponWork()
            {
                var planet = new Planet("asd", 11);
                Weapon weapon = new Weapon("qwe", 2, 34);
                planet.AddWeapon(weapon);
                Assert.AreEqual(1, planet.Weapons.Count);
            }
            [Test]
            public void AddWeaponNotWork()
            {
                var planet = new Planet("asd", 11);
                Weapon weapon = new Weapon("qwe", 2, 34);
                planet.AddWeapon(weapon);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon);
                }, "There is already a qwe weapon.");
            }
            [Test]
            public void Remove()
            {
                var planet = new Planet("asd", 11);
                Weapon weapon = new Weapon("qwe", 2, 34);
                planet.AddWeapon(weapon);
                planet.RemoveWeapon(weapon.Name);
                Assert.AreEqual(0, planet.Weapons.Count);
            }
            [Test]
            public void UpgradeWork()
            {
                var planet = new Planet("asd", 11);
                Weapon weapon = new Weapon("qwe", 2, 34);
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weapon.Name);
                Assert.AreEqual(35, weapon.DestructionLevel);
            }
            [Test]
            public void UpgradeNotWork()
            {
                var planet = new Planet("asd", 11);
                Weapon weapon = new Weapon("qwe", 2, 34);
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weapon.Name);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("123");
                }, "123 does not exist in the weapon repository of asd");
            }
            [Test]
            public void DestructOpponent()
            {
                var planet = new Planet("asd", 11);
                Weapon weapon = new Weapon("qwe", 2, 34);
                planet.AddWeapon(weapon);
                var planet1 = new Planet("kur", 12);
                Weapon weapon1 = new Weapon("kurec", 1, 33);
                planet1.AddWeapon(weapon1);
                string res = planet.DestructOpponent(planet1);
                Assert.AreEqual(res, "kur is destructed!");
            }
            [Test]
            public void DestructOpponentNot1()
            {
                var planet = new Planet("asd", 11);
                Weapon weapon = new Weapon("qwe", 2, 33);
                planet.AddWeapon(weapon);
                var planet1 = new Planet("kur", 12);
                Weapon weapon1 = new Weapon("kurec", 1, 33);
                planet1.AddWeapon(weapon1);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    string res = planet1.DestructOpponent(planet);
                }, "qwe is too strong to declare war to!");
            }
            [Test]
            public void DestructOpponentNot()
            {
                var planet = new Planet("asd", 11);
                Weapon weapon = new Weapon("qwe", 2, 34);
                planet.AddWeapon(weapon);
                var planet1 = new Planet("kur", 12);
                Weapon weapon1 = new Weapon("kurec", 1, 33);
                planet1.AddWeapon(weapon1);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    string res = planet1.DestructOpponent(planet);
                }, "qwe is too strong to declare war to!");
            }
            [Test]
            public void Price()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("asd", -1, 12);

                }, "Price cannot be negative.");
            }
            [Test]
            public void INcdr()
            {
                Weapon weapon = new Weapon("asd", 1, 12);
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(13, weapon.DestructionLevel);
            }
            [Test]
            public void NameWork()
            {
                var planet = new Planet("asd", 11);
                Assert.AreEqual("asd", planet.Name);
            }
            [Test]
            public void BudgetWork()
            {
                var planet = new Planet("asd", 11);
                Assert.AreEqual(11, planet.Budget);
            }
        }
        
    }
}
