using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void WeaponLoosingDurabilityAfterEachAttack()
        {
            var axe = new Axe(10, 10);
            var dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints.Equals(9));
        }

        [Test]
        public void AttackingWithBrokenWeapon()
        {
            var axe = new Axe(0, 0);
            var dummy = new Dummy(10, 10);


            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);

            }, "Axe is broken.");
        }
    }
}