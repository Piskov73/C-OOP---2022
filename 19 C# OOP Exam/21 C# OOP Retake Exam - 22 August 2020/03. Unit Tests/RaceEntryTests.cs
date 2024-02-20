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
            this.car = new UnitCar("model", 100, 500);

            this.driver = new UnitDriver("Name", car);

            this.race = new RaceEntry();
        }

        [Test]
        public void Test_UnitCarConstructor()
        {
            string model = "Forf";
            int horsePower = 100;
            double cubicCentimeters = 1600;

            car = new UnitCar(model, horsePower, cubicCentimeters);

            Assert.NotNull(car);

            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(horsePower, car.HorsePower);
            Assert.AreEqual(cubicCentimeters, car.CubicCentimeters);
        }
        [Test]
        public void Test_UnitDriver()
        {
            string model = "Forf";
            int horsePower = 100;
            double cubicCentimeters = 1600;

            car = new UnitCar(model, horsePower, cubicCentimeters);

            string nameDriveer = "NameDriver";

            driver = new UnitDriver(nameDriveer, car);

            Assert.NotNull(driver);

            Assert.AreEqual(nameDriveer, driver.Name);

            Assert.AreEqual(car, driver.Car);

            nameDriveer = null;

            Assert.Throws<ArgumentNullException>(() => new UnitDriver(nameDriveer, car), "Name cannot be null!");

        }
        [Test]
        public void Test_RaceEntryConstructor()
        {
            race = new RaceEntry();

            Assert.NotNull(race);
        }
        [Test]
        public void Test_RaceEntryAddDriver()
        {
            string model = "Forf";
            int horsePower = 100;
            double cubicCentimeters = 1600;

            car = new UnitCar(model, horsePower, cubicCentimeters);

            string nameDriveer = "NameDriver";

            driver = new UnitDriver(nameDriveer, car);

            race = new RaceEntry();

            string expected = $"Driver {nameDriveer} added in race.";

            string actual = race.AddDriver(driver);

            Assert.AreEqual(expected, actual);

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver), $"Driver {nameDriveer} is already added.");

            driver = null;

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver), "Driver cannot be null.");
        }
        [Test]
        public void Test_RaceEntryCalculateAverageHorsePower()
        {
            string model = "Forf";
            int horsePower = 100;
            double cubicCentimeters = 1600;

            car = new UnitCar(model, horsePower, cubicCentimeters);

            string nameDriveer = "NameDriver";

            driver = new UnitDriver(nameDriveer, car);

            race = new RaceEntry();

            race.AddDriver(driver);

            Assert.AreEqual(1, race.Counter);

            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower()
            , "The race cannot start with less than 2 participants.");

            race.AddDriver(new UnitDriver("Name", car));

            Assert.AreEqual(horsePower,race.CalculateAverageHorsePower());
        }
    }
}