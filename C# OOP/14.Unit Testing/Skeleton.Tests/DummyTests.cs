using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void LoosingHealthWhetItIsAttacked()
        {
            //Arrange
            var dummy = new Dummy(10, 10);

            //Act
            dummy.TakeAttack(1);

            //Assert
            Assert.That(dummy.Health, Is.EqualTo(9));
        }

        [Test]
        public void DeadDummyThrowsAnExceptionIfAttacked()
        {
            var dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(1);
            }, "Dummy is dead.");
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            //Arrange
            var dummy = new Dummy(0, 10);

            //Act
            dummy.GiveExperience();

            //Assert
            Assert.That(dummy.Experience, Is.EqualTo(10));
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            var dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            }, "Target is not dead.");
        }
    }
}