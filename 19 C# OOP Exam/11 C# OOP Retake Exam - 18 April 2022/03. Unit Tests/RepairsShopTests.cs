using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            private Car car;
            private Garage garage;
            [SetUp]
            public void Setup()
            {
                this.car = new Car("Ford", 0);
                this.garage = new Garage("Parking", 2);
            }

            [Test]
            public void Test_CarConstruktor()
            {
                string carModel = "Fodd";
                int numberOfIssues = 0;

                car = new Car(carModel, numberOfIssues);

                Assert.AreEqual(carModel, car.CarModel);

                Assert.AreEqual(numberOfIssues, car.NumberOfIssues);

                Assert.True(car.IsFixed);
            }
            [Test]
            public void Test_GarageConstructor()
            {
                string name = "Parking";
                int mechanicsAvailable = 2;

                garage = new Garage(name, mechanicsAvailable);

                Assert.AreEqual(name, garage.Name);

                Assert.AreEqual(mechanicsAvailable, garage.MechanicsAvailable);

                Assert.AreEqual(0, garage.CarsInGarage);

                Assert.NotNull(garage);
            }
            [Test]
            public void Test_GarageName()
            {
                string name = "Parking";
                int mechanicsAvailable = 2;

                garage = new Garage(name, mechanicsAvailable);
                Assert.AreEqual(name, garage.Name);
                name = null;

                Assert.Throws<ArgumentNullException>(() => new Garage(name, mechanicsAvailable), "Invalid garage name.");
            }
            [Test]
            public void Test_GarageMechanicsAvailable()
            {
                string name = "Parking";
                int mechanicsAvailable = 2;

                garage = new Garage(name, mechanicsAvailable);

                Assert.AreEqual(mechanicsAvailable, garage.MechanicsAvailable);

                mechanicsAvailable = -25;

                Assert.Throws<ArgumentException>(() => new Garage(name, mechanicsAvailable)
                , "At least one mechanic must work in the garage.");
            }
            [Test]
            public void Test_GarageAddCar()
            {
                string name = "Parking";
                int mechanicsAvailable = 2;

                garage = new Garage(name, mechanicsAvailable);

                string carModel = "Ford";
                int numberOfIssues = 0;

                car = new Car(carModel, numberOfIssues);

                garage.AddCar(car);

                garage.AddCar(new Car("Note", numberOfIssues));

                Assert.AreEqual(2, garage.CarsInGarage);

               Assert.Throws<InvalidOperationException>(() =>garage.AddCar(new Car("Nesto", numberOfIssues + 1)) , "No mechanic available.");

            }
            [Test]
            public void Test_GarageFixCar()
            {
                string name = "Parking";
                int mechanicsAvailable = 2;

                garage = new Garage(name, mechanicsAvailable);

                string carModel = "Ford";
                int numberOfIssues = 3;

                car = new Car(carModel, numberOfIssues);

                garage.AddCar(car);

                garage.AddCar(new Car("Note", numberOfIssues));

                var carFixCar = garage.FixCar(carModel);

                Assert.AreEqual(0, carFixCar.NumberOfIssues);

                Assert.Throws<InvalidOperationException>(() => garage.FixCar("Fiat"), "The car Fiat doesn't exist.");

            }
            [Test]
            public void Test_GarageRemoveFixedCar()
            {
                string name = "Parking";
                int mechanicsAvailable = 2;

                garage = new Garage(name, mechanicsAvailable);

                string carModel = "Ford";
                int numberOfIssues = 3;

                car = new Car(carModel, numberOfIssues);

                garage.AddCar(car);

                garage.AddCar(new Car("Fiat", numberOfIssues+9));

                var carFixCar = garage.FixCar(carModel);

                int count = garage.RemoveFixedCar();

                Assert.AreEqual(1, count);

                Assert.AreEqual(1, garage.CarsInGarage);

                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar(), "No fixed cars available.");
            }
            [Test]
            public void Test_GarageReport()
            {
                string name = "Parking";
                int mechanicsAvailable = 2;

                garage = new Garage(name, mechanicsAvailable);

                string carModel = "Ford";
                int numberOfIssues = 3;

                car = new Car(carModel, numberOfIssues);

                garage.AddCar(car);

                garage.AddCar(new Car("Fiat", numberOfIssues + 9));

                var carFixCar = garage.FixCar("Fiat");

                garage.RemoveFixedCar();

                string expected = $"There are {1} which are not fixed: {carModel}.";
                string actual = garage.Report();

                Assert.AreEqual(expected, actual);
            }

        }
    }
}