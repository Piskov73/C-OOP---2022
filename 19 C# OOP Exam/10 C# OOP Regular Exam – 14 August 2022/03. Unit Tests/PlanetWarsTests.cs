using NUnit.Framework;
using System;
using System.ComponentModel;

namespace PlanetWars.Tests
{
    public class Tests
    {
        private Weapon rockets;
        private Planet planet1;
        [SetUp]
        public void SetUp()
        {
            this.rockets = new Weapon("Rocket", 200, 6);
            this.planet1 = new Planet("Planet1", 1000);
        }
        [Test]
        public void Test_WeaponConsructor()
        {
            Assert.NotNull(rockets);
        }
        [Test]
        public void Test_WeaponName()
        {
            string name = "Rocket";
            double price = 20;
            int destructionLevel = 5;

            rockets = new Weapon(name, price, destructionLevel);

            Assert.AreEqual(name, rockets.Name);

        }
        [Test]
        public void Test_WeaponPrice()
        {
            string name = "Rocket";
            double price = 20;
            int destructionLevel = 5;

            rockets = new Weapon(name, price, destructionLevel);

            Assert.AreEqual(price, rockets.Price);

            price = -20;

            Assert.Throws<ArgumentException>(() => new Weapon(name, price, destructionLevel), "Price cannot be negative.");
        }
        [Test]
        public void Test_WeaponDestructionLevel()
        {
            string name = "Rocket";
            double price = 20;
            int destructionLevel = 5;

            rockets = new Weapon(name, price, destructionLevel);

            Assert.AreEqual(rockets.DestructionLevel, destructionLevel);
        }
        [Test]
        public void Test_WeaponIncreaseDestructionLevel()
        {
            string name = "Rocket";
            double price = 20;
            int destructionLevel = 9;

            rockets = new Weapon(name, price, destructionLevel);

            Assert.AreEqual(rockets.DestructionLevel, destructionLevel);

            rockets.IncreaseDestructionLevel();

            Assert.AreEqual(destructionLevel + 1, rockets.DestructionLevel);
            rockets.IncreaseDestructionLevel();

            Assert.AreEqual(destructionLevel + 2, rockets.DestructionLevel);
        }
        [Test]
        public void Test_WeaponIsNuclear()
        {
            string name = "Rocket";
            double price = 20;
            int destructionLevel = 9;

            rockets = new Weapon(name, price, destructionLevel);

            Assert.False(rockets.IsNuclear);

            rockets.IncreaseDestructionLevel();

            Assert.True(rockets.IsNuclear);
        }
        [Test]
        public void Test_PlanetConstructor()
        {
            Assert.NotNull(planet1);
            Assert.AreEqual(0, planet1.Weapons.Count);
        }
        [Test]
        public void Test_PlanetName()
        {
            string name = "Planet1";
            double budget = 100;

            planet1 = new Planet(name, budget);

            Assert.AreEqual(name, planet1.Name);

            name = null;

            Assert.Throws<ArgumentException>(() => new Planet(name, budget), "Invalid planet Name");

        }
        [Test]
        public void Test_PlanetBudget()
        {
            string name = "Planet1";
            double budget = 100;

            planet1 = new Planet(name, budget);

            Assert.AreEqual(budget, planet1.Budget);

            budget = -2589;
            Assert.Throws<ArgumentException>(() => new Planet(name, budget), "Budget cannot drop below Zero!");
        }
        [Test]
        public void Test_PlanetProfit()
        {
            string name = "Planet1";
            double budget = 100;

            planet1 = new Planet(name, budget);

            double amount = 50;

            planet1.Profit(amount);
            Assert.AreEqual(budget + amount, planet1.Budget);
        }
        [Test]
        public void Test_PlanetSpendFunds()
        {
            string name = "Planet1";
            double budget = 100;

            planet1 = new Planet(name, budget);

            double amount = 60;
            planet1.SpendFunds(amount);
            Assert.AreEqual(budget - amount, planet1.Budget);

            Assert.Throws<InvalidOperationException>(() => planet1.SpendFunds(amount), "Not enough funds to finalize the deal.");
        }
        [Test]
        public void Test_PlanetAddWeapon()
        {
            string namePlanet = "Planet1";
            double budget = 100;

            planet1 = new Planet(namePlanet, budget);

            string name = "Rocket";
            double price = 20;
            int destructionLevel = 5;

            rockets = new Weapon(name, price, destructionLevel);

            planet1.AddWeapon(rockets);

            Assert.AreEqual(1, planet1.Weapons.Count);

            Assert.AreEqual(destructionLevel, planet1.MilitaryPowerRatio);

            Assert.Throws<InvalidOperationException>(() => planet1.AddWeapon(rockets), $"There is already a {name} weapon.");
        }
        [Test]
        public void Test_PlanetRemoveWeapon()
        {
            string namePlanet = "Planet1";
            double budget = 100;

            planet1 = new Planet(namePlanet, budget);

            string name = "Rocket";
            double price = 20;
            int destructionLevel = 5;

            rockets = new Weapon(name, price, destructionLevel);

            planet1.AddWeapon(rockets);

            Assert.AreEqual(1, planet1.Weapons.Count);

            planet1.RemoveWeapon("None");
            Assert.AreEqual(1, planet1.Weapons.Count);

            planet1.RemoveWeapon(name);
            Assert.AreEqual(0, planet1.Weapons.Count);
        }
        [Test]
        public void Test_PlanetUpgradeWeapon()
        {
            string namePlanet = "Planet1";
            double budget = 100;

            planet1 = new Planet(namePlanet, budget);

            string name = "Rocket";
            double price = 20;
            int destructionLevel = 5;

            rockets = new Weapon(name, price, destructionLevel);

            planet1.AddWeapon(rockets);

            planet1.UpgradeWeapon(name);

            Assert.AreEqual(destructionLevel + 1, rockets.DestructionLevel);

            string nameNone = "None";

            Assert.Throws<InvalidOperationException>(() => planet1.UpgradeWeapon(nameNone)
            , $"{nameNone} does not exist in the weapon repository of {namePlanet}");
        }
        [Test]
        public void Test_PlanetDestructOpponent()
        {
            string namePlanet = "Planet1";
            double budget = 100;

            planet1 = new Planet(namePlanet, budget);

            Planet planet2 = new Planet("Planet2", 200);

            string name = "Rocket";
            double price = 20;
            int destructionLevel = 5;

            rockets = new Weapon(name, price, destructionLevel);

            Weapon laser = new Weapon("Laser", 20, 8);

            planet1.AddWeapon(rockets);
            planet2.AddWeapon(rockets);
            planet1.AddWeapon(laser);

            string expected = $"{planet2.Name} is destructed!";
            string actual = planet1.DestructOpponent(planet2);

            Assert.AreEqual(expected, actual);

            Assert.Throws<InvalidOperationException>(()=>planet2.DestructOpponent(planet1 )
            , $"{planet1.Name} is too strong to declare war to!");
        }
    }
}
