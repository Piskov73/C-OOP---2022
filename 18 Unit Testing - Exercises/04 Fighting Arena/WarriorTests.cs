namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        private Warrior warriorAttacked;
        private const int MIN_ATTACK_HP = 30;
        [SetUp]
        public void SetUp()
        {
            this.warrior = new Warrior("Nenko", 10, 50);
            this.warriorAttacked = new Warrior("Pesho", 10, 50);
        }
        [Test]
        public void TestingWithValidPropertyName()
        {
            string expectName = "Super Matio";

            warrior = new Warrior(expectName, 10, 50);
            string actualName = warrior.Name;
            Assert.AreEqual(expectName, actualName);
        }

        [TestCase(null)]
        [TestCase("  ")]
        public void TestingArgumentExceptionPropertyNameIsNullOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 10, 50), "Name should not be empty or whitespace!");
        }

        [TestCase(1)]
        [TestCase(50)]
        [TestCase(100)]
        public void TestingWithValidPropertyDamage(int damage)
        {
            int expectDamage = damage;
            warrior = new Warrior("Nenko", expectDamage, 50);
            int actualDamage = warrior.Damage;
            Assert.AreEqual(expectDamage, actualDamage);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(-10000000)]
        public void TestingArgumentExceptionPropertyDamageZeroOrNegative(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Nenko", damage, 50), "Damage value should be positive!");
        }

        [TestCase(1)]
        [TestCase(50)]
        [TestCase(100)]
        public void TestingWithValidPropertyHP(int hp)
        {
            int expectHP = hp;
            warrior = new Warrior("Nenko", 10, expectHP);
            int actualHP = warrior.HP;
            Assert.AreEqual(expectHP, actualHP);
        }

        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(-10000000)]
        public void TestingArgumentExceptionPropertyHPNegative(int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Nenko", 10, hp), "HP should not be negative!");
        }

        [Test]
        public void TestingValidMethodAttack()
        {
            int expectHP = 40;
            warrior.Attack(warriorAttacked);
            int actualHPWarrior = warrior.HP;
            int actualHPWarriorAttacker = warriorAttacked.HP;
            Assert.AreEqual(expectHP, actualHPWarrior);
            Assert.AreEqual(expectHP, actualHPWarriorAttacker);
        }
        [Test]
        public void TestingValidMethodAttackAttackerIsStronger()
        {
            this.warrior = new Warrior("Nenko", 60, 50);
            this.warriorAttacked = new Warrior("Pesho", 10, 50);
            int expectAtackedHP = 0;
            this.warrior.Attack(this.warriorAttacked);
            Assert.AreEqual(expectAtackedHP, this.warriorAttacked.HP);
        }

        [Test]
        public void TestingMethodAttackInvalidOperationExceptionAttackerHPTooLowFromMIN_ATTACK_HP()
        {
            warrior = new Warrior("Nenko", 10, 30);

            Assert.Throws<InvalidOperationException>(() =>
            warrior.Attack(warriorAttacked), "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        public void TestingMethodAttackInvalidOperationExceptionAttackedHPTooLowFromMIN_ATTACK_HP()
        {
            warriorAttacked = new Warrior("Pesho", 10, 30);

            Assert.Throws<InvalidOperationException>(() =>
            warrior.Attack(warriorAttacked), $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
        }
        [Test]
        public void TestingMethodAttackInvalidOperationExceptionAttackerHPTooLowAttackedDamage()
        {
            warrior = new Warrior("Nenko", 10, 50);
            warriorAttacked = new Warrior("Pesho", 60, 30);

            Assert.Throws<InvalidOperationException>(() =>
            warrior.Attack(warriorAttacked), "You are trying to attack too strong enemy");
        }


    }
}