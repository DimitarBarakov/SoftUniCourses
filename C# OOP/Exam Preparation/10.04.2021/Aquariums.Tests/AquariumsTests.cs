namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        [Test]
        public void NameSetShouldThrowExceptionForNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium("", 2);
                aquarium = new Aquarium(null, 2);
            }, "Invalid aquarium name!");
        }
        [Test]
        public void CapacitySetShouldThrowExceptionIfItsBelow0()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("asd", -1);
            }, "Invalid aquarium capacity!");
        }
        [Test]
        public void AddFishShouldThrowExceptionIfThereIsNoSpace()
        {
            Aquarium aquarium = new Aquarium("qwe", 1);
            Fish fish1 = new Fish("asd");
            aquarium.Add(fish1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                Fish fish2 = new Fish("qw");
                aquarium.Add(fish2);
            }, "Aquarium is full!");
        }
        [Test]
        public void AddFishShouldWorkProperly()
        {
            Aquarium aquarium = new Aquarium("qwe", 1);
            Fish fish1 = new Fish("asd");
            aquarium.Add(fish1);

            Assert.That(aquarium.Count, Is.EqualTo(1));
        }
        [Test]
        public void RemoveFishShouldThrowExceptionIfFishDoesntExist()
        {
            string fishname = "mite";
            Aquarium aquarium = new Aquarium("qwe", 1);
            Fish fish1 = new Fish("asd");
            aquarium.Add(fish1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish(fishname);
            },$"Fish with the name {fishname} doesn't exist!");
        }
        [Test]
        public void RemoveFishShouldWorkCorrectly()
        {
            Aquarium aquarium = new Aquarium("qwe", 2);
            Fish fish1 = new Fish("asd");
            Fish fish2 = new Fish("zxc");
            aquarium.Add(fish1);
            aquarium.Add(fish2);

            aquarium.RemoveFish("zxc");

            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void SellFishShouldThrowExceptionIfFishDoesntExist()
        {
            string fishname = "mite";
            Aquarium aquarium = new Aquarium("qwe", 1);
            Fish fish1 = new Fish("asd");
            aquarium.Add(fish1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish(fishname);
            }, $"Fish with the name {fishname} doesn't exist!");
        }

        [Test]
        public void SellFishShouldWorkCorrectly()
        {
            string fishname = "mite";
            Aquarium aquarium = new Aquarium("qwe", 2);
            Fish fish1 = new Fish("asd");
            Fish fish2 = new Fish(fishname);
            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Fish returnedFish = aquarium.SellFish(fishname);
            Assert.That(returnedFish, Is.EqualTo(fish2));
            Assert.That(returnedFish.Available, Is.EqualTo(false));
        }

        [Test]
        public void ReportShouldWorkCorrectly()
        {
            string fishname = "mite";
            Aquarium aquarium = new Aquarium("qwe", 2);
            Fish fish1 = new Fish("asd");
            Fish fish2 = new Fish(fishname);
            aquarium.Add(fish1);
            aquarium.Add(fish2);

            string report = aquarium.Report();
            Assert.That(report, Is.EqualTo("Fish available at qwe: asd, mite"));
        }
    }
}
