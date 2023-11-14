using NUnit.Framework;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace PlanetWars.Tests
{
    public class Tests
    {


        [TestFixture]
        public class PlanetWarsTests
        {
            private Weapon weapon;
            private Planet planet;

            [SetUp]

            public void SetUp()
            {
                this.weapon = new Weapon("name", 0.1, 1);
                this.planet = new Planet("Zema", 10.50);
            }
            [Test]
            public void Test_ConstruktorWeapon()
            {
                string name = "Lazer";
                double price = 22.22;
                int level = 1;
                weapon = new Weapon(name, price, level);

                Assert.NotNull(weapon);
                Assert.AreEqual(name, weapon.Name);
                Assert.AreEqual(price, weapon.Price);
                Assert.AreEqual(level, weapon.DestructionLevel);

            }
            [Test]
            public void Test_PriceNegativ()
            {
                string name = "Lazer";
                double price = -22.22;
                int level = 1;

                Assert.Throws<ArgumentException>(() => new Weapon(name, price, level), "Price cannot be negative.");


            }
            [Test]
            public void Test_MethodIncreaseDestructionLevel()
            {
                string name = "Lazer";
                double price = 22.22;
                int level = 1;

                weapon = new Weapon(name, price, level);
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(2, weapon.DestructionLevel);
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(3, weapon.DestructionLevel);
            }

            [Test]
            public void Test_MethodIsNuclear()
            {
                string name = "Lazer";
                double price = 22.22;
                int level = 9;

                weapon = new Weapon(name, price, level);

                Assert.False(weapon.IsNuclear);
                weapon.IncreaseDestructionLevel();
                weapon.IncreaseDestructionLevel();
                Assert.True(weapon.IsNuclear);
            }

            [Test]
            public void Test_ConstruktorPlanet()
            {
                Assert.NotNull(planet);

            }
            [Test]
            public void Test_PlanetNameAndBuget()
            {
                string name = "Mars";
                double buget = 200;

                planet = new Planet(name, buget);

                Assert.AreEqual(name, planet.Name);
                Assert.AreEqual(buget, planet.Budget);
                name = null;

                Assert.Throws<ArgumentException>(() => new Planet(name, buget), "Invalid planet Name");
                Assert.Throws<ArgumentException>(() => new Planet("Zema", -200), "Budget cannot drop below Zero!");


            }
            [Test]
            public void Test_PlanetMethodProfit()
            {
                string name = "Mars";
                double buget = 200;

                planet = new Planet(name, buget);

                double amount = 150;

                planet.Profit(amount);

                Assert.AreEqual(buget + amount, planet.Budget);


            }
            [Test]
            public void Test_PlanetMethodSpendFunds()
            {
                string name = "Mars";
                double buget = 200;

                planet = new Planet(name, buget);

                double amount = 150;

                planet.SpendFunds(amount);

                Assert.AreEqual(buget - amount, planet.Budget);

                amount = 300;

                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(amount), "Not enough funds to finalize the deal.");

            }
            [Test]
            public void Test_PlanetMethodAddWeapon()
            {
                string name = "Mars";
                double buget = 200;

                planet = new Planet(name, buget);
                planet.AddWeapon(weapon);

                Assert.AreEqual(1, planet.Weapons.Count);

                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon), $"There is already a {weapon.Name} weapon.");

            }
            [Test]
            public void Test_PlanetMethodRemoveWeapon()
            {
                string name = "Mars";
                double buget = 200;

                planet = new Planet(name, buget);
                planet.AddWeapon(weapon);

                Assert.AreEqual(1, planet.Weapons.Count);

                planet.RemoveWeapon(weapon.Name);

                Assert.AreEqual(0, planet.Weapons.Count);


            }
            [Test]
            public void Test_PlanetMethodUpgradeWeapon()
            {
                string name = "Mars";
                double buget = 200;

                planet = new Planet(name, buget);
                planet.AddWeapon(weapon);

                planet.UpgradeWeapon(weapon.Name);
                Assert.AreEqual(2, weapon.DestructionLevel);

                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("Smirno"), $"{"Smirno"} does not exist in the weapon repository of {"Mars"}");
            }

            [Test]
            public void Test_PlanetMethodDestructOpponent()
            {
                string name = "Mars";
                double buget = 200;

                planet = new Planet(name, buget);
                planet.AddWeapon(weapon);

                Assert.AreEqual(1, planet.MilitaryPowerRatio);

                var planetOponent = new Planet("Zeta", 100);

                string expecte = $"{planetOponent.Name} is destructed!";
                string actual = planet.DestructOpponent(planetOponent);

                Assert.AreEqual(expecte, actual);

                planetOponent.AddWeapon(new Weapon("name", 10, 8));

                Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(planetOponent)
                , $"{planetOponent.Name} is too strong to declare war to!");

            }
        }
    }
}
