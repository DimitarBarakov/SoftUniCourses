namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void CreateThrowExceptionIfPresentINull()
        {
            Present present = null;
            Bag bag  = new Bag();
            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(present);
            }, "Present is null");
        }
        [Test]
        public void CreateThrowExceptionIfPresentExist()
        {
            Present present = new Present("asd",12);
            Bag bag = new Bag();
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            }, "This present already exists!");
        }
        [Test]
        public void CreateShouldWork()
        {
            Present present = new Present("asd", 12);
            Bag bag = new Bag();
            bag.Create(present);

            Assert.AreEqual(1, bag.GetPresents().Count);
        }

        [Test]
        public void Remove()
        {
            Present present = new Present("asd", 12);
            Present present1 = new Present("asd1", 13);
            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present1);

            Assert.AreEqual(true, bag.Remove(present));
            Assert.AreEqual(1, bag.GetPresents().Count);
        }
        [Test]
        public void GetPresentWithLeastMagic()
        {
            Present present = new Present("asd", 12);
            Present present1 = new Present("asd1", 13);
            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present1);

            Present present2 = bag.GetPresentWithLeastMagic();
            Assert.AreEqual(present2, present);
        }
        [Test]
        public void GetPresent()
        {
            Present present = new Present("asd", 12);
            Present present1 = new Present("asd1", 13);
            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present1);

            Present present2 = bag.GetPresent("asd");
            Assert.AreEqual(present2, present);
        }
    }
}
