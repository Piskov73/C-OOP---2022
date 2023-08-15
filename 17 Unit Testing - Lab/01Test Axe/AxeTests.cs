using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private int attackPoints;
        private int durabilityPoints;
        private Axe axe;
        private Dummy dummy;
        [SetUp]
        public void Setup()
        {
            attackPoints = 10;
            durabilityPoints = 10;
            axe = new Axe(attackPoints, durabilityPoints);
            dummy = new Dummy(20, 20);
        }
        [Test]
        public void Test_CreateNewAxe()
        {
            Assert.AreEqual(attackPoints, axe.AttackPoints);
            Assert.AreEqual(durabilityPoints, axe.DurabilityPoints);
        }

        [Test]
        public void Test_AxeAttackReturnsPositiveDurabilityPoints()
        {
            axe.Attack(dummy);
            Assert.AreEqual(9, axe.DurabilityPoints);
        }
        [Test]
        public void Test_AxeAttackDurabilityPointsZiro()
        {
            axe = new Axe(10, 0);
            Assert.Throws(typeof(InvalidOperationException),() =>
                {
                axe.Attack(dummy);
            });

        }
        [Test]
        public void Test_AxeAttackDurabilityPointsNegative()
        {
            axe = new Axe(10, -100);
            Assert.Throws(typeof(InvalidOperationException), () =>
            {
                axe.Attack(dummy);
            });

        }
    }
}