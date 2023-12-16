using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitCar car;
        private UnitDriver driver;
        private RaceEntry race;

        [SetUp]
        public void Setup()
        {
            car = new UnitCar("CarModel", 1000, 600);
            driver = new UnitDriver("Name", car);
            race = new RaceEntry();
        }
        [Test]
        public void Test_UnitCarConstructor()
        {
            Assert.NotNull(car);
            Assert.AreEqual("CarModel", car.Model);
            Assert.AreEqual(1000, car.HorsePower);
            Assert.AreEqual(600, car.CubicCentimeters);
        }
        [Test]
        public void Test_UnitDriverConstructor()
        {
            Assert.NotNull (driver);
            Assert.NotNull (driver.Car);
            Assert.AreEqual("Name", driver.Name);
            
            Assert.Throws<ArgumentNullException>(()=>new  UnitDriver(null, driver.Car), "Name cannot be null!");
        }
        [Test]
        public void Test_RaceEntryConstructor()
        {
            Assert.NotNull(race);
            Assert.AreEqual(0, race.Counter);
        }
        [Test]
        public void Test_RaceEntryAddDriver()
        {
            string expectet = $"Driver {driver.Name} added in race.";
            string actual = race.AddDriver(driver);

            Assert.AreEqual (expectet, actual);

            Assert.Throws<InvalidOperationException>(()=>race.AddDriver(driver), $"Driver {driver.Name} is already added.");

            driver = null;
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver), "Driver cannot be null.");
        }
        [Test]
        public void Test_RaceEntryCalculateAverageHorsePower()
        {
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(()=>race.CalculateAverageHorsePower(),
                "The race cannot start with less than 2 participants.");

            car = new UnitCar("Model2", 600, 1000);
            driver = new UnitDriver("Name2", car);
            race.AddDriver (driver);

            Assert.AreEqual(800.0, race.CalculateAverageHorsePower());
        }
       
    }
}