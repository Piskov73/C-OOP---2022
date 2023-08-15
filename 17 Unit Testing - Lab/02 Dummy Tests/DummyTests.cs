using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private int health;
        private int experience;
        private Dummy dummy;
        private Dummy deadDummy;
        private int attackPoints;
        [SetUp]
        public void Setup()
        {
            health = 10;
            experience = 10;
            dummy=new Dummy(health, experience);
            deadDummy = new Dummy(0, experience);
            attackPoints = 4;
        }
        [Test]
        public void Test_CreateNewDummy()
        {
            Assert.AreEqual(10,dummy.Health);
        }
        [Test]
        public void Test_DommyIsDeadHealthZiro()
        {
           
            Assert.IsTrue(deadDummy.IsDead());
        }
        [Test]
        public void Test_DommyIsDeadHealthNegativ()
        {
            deadDummy=new Dummy(-5,experience); 
            Assert.IsTrue(deadDummy.IsDead());
        }
        [Test]
        public void Test_TakeAttackHealthPozitiv()
        {
           
            dummy.TakeAttack(attackPoints);
            Assert.AreEqual(6,dummy.Health);
        }
        [Test]
        public void Test_TakeAttackDummyIsDead()
        {
            Assert.Throws(typeof(InvalidOperationException), () =>
            {
                deadDummy.TakeAttack(attackPoints);
            });
        }
        [Test]
        public void Test_GiveExperienceDummyIsDead()
        {
            Assert.AreEqual(10, deadDummy.GiveExperience());

        }
        [Test]
        public void Test_GiveExperienceDummyLiving()
        {
            Assert.Throws(typeof(InvalidOperationException), () =>
            {
                dummy.GiveExperience();
            });
        }
    }
}