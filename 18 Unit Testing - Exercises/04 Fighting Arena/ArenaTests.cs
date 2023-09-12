namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        private Warrior warrior;
        private Warrior warrior1;
        private Arena arena;
        [SetUp]
        public void SetUp()
        {
            this.warrior = new Warrior("Nenko", 50, 100);
            this.warrior1 = new Warrior("Petko", 10, 50);
            this.arena = new Arena();
        }

        [Test]
        public void TestingAddValidWarrior()
        {
            int expectCount = 1;
            arena.Enroll(warrior);
            int actualCount = arena.Count;
            Assert.AreEqual(expectCount, actualCount);
        }
        [Test]
        public void TestingInvalidOperationExceptionAddRecurringWarrior()
        {
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior)
            , "Warrior is already enrolled for the fights!");
        }
        [Test]
        public void TestingBattleValidWarrior()
        {
            int expecktCount = 2;
            arena.Enroll(warrior);
            arena.Enroll(warrior1);
            arena.Fight("Petko", "Nenko");
            int actualCount = arena.Count;

            Assert.AreEqual(expecktCount, actualCount);
        }
        [Test]
        public void TestingInvalidOperationExceptionInvalidAttackerInBattle()
        {
            string missingName = "Stojan";
            arena.Enroll(warrior);
            arena.Enroll(warrior1);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(missingName, warrior.Name)
            , $"There is no fighter with name {missingName} enrolled for the fights!");
        }
       
        public void TestingInvalidOperationExceptionInvalidDefendgerInBattle()
        {
            string missingName = "Stojan";
            arena.Enroll(warrior);
            arena.Enroll(warrior1);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(warrior.Name, missingName)
            , $"There is no fighter with name {missingName} enrolled for the fights!");
        }
        [Test]
        public void TestingPropertyCount()
        {
            arena.Enroll(warrior);
            arena.Enroll(warrior1);
            int expeckCount=2;
            int actualCount = arena.Count;
            Assert.AreEqual (expeckCount, actualCount);
        }

        [Test]
        public void TestingCollectionsWarriors()
        {
            List<Warrior> expectCollection=new List<Warrior>();
            expectCollection.Add(warrior);
            expectCollection.Add(warrior1);
            arena.Enroll(warrior);
            arena.Enroll(warrior1);
            List<Warrior> actualCollection = (List<Warrior>)arena.Warriors;
            CollectionAssert.AreEqual (expectCollection, actualCollection);
        }
    }
}
