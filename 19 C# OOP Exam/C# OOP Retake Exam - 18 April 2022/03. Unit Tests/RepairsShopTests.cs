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
            public void SetUp()
            {
                this.car = new Car("Ford",0);
                this.garage = new Garage("BisnesPark", 3);
            }
            [Test]
            public void Test_CarConstruktor()
            {
                Assert.IsNotNull(this.car);
                Assert.AreEqual("Ford", car.CarModel);
                Assert.AreEqual(0, car.NumberOfIssues);
                Assert.True(car.IsFixed);
                car.NumberOfIssues = 5555;
                Assert.AreEqual(5555, car.NumberOfIssues);
                Assert.False(car.IsFixed);
            }

            [Test]
            public void Test_GarageConstruktor()
            {
                Assert.NotNull(garage);
                Assert.AreEqual("BisnesPark", garage.Name);
                Assert.AreEqual(3, garage.MechanicsAvailable);
            }

            [Test]
            public void Test_GarageName()
            {
                Assert.NotNull(garage);
                Assert.AreEqual("BisnesPark", garage.Name);

                Assert.Throws<ArgumentNullException>(() => new Garage(null, 0), "Invalid garage name.");

            }
            [Test]
            public void Test_MechanicsAvailable()
            {
                Assert.NotNull(garage);
                Assert.AreEqual(3, garage.MechanicsAvailable);

                Assert.Throws<ArgumentException>(() => new Garage("Sofia", 0), "At least one mechanic must work in the garage.");

            }
            [Test]
            public void Test_AddCar()
            {
                garage = new Garage("Sofia", 1);
                garage.AddCar(car);
                Assert.AreEqual(1, garage.CarsInGarage);

                Assert.Throws<InvalidOperationException>(()=>garage.AddCar(car), "No mechanic available.");
            }
            [Test]
            public void Test_FixCar()
            {
                garage = new Garage("Sofia", 3);
                car = new Car("Ford", 3);
                garage.AddCar(car);
                Assert.NotNull(garage.FixCar("Ford"));
                Assert.AreEqual(0,car.NumberOfIssues);
            }
            [Test]
            public void Test_RemoveFixedCar()
            {
                garage = new Garage("Sofia", 3);
                car = new Car("Ford", 3);
                garage.AddCar(car);
                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar(), "No fixed cars available.");
                garage.FixCar("Ford");
                garage.RemoveFixedCar();
                Assert.AreEqual(0, garage.CarsInGarage);
                
            }

            [Test]
            public void Test_Report()
            {
                garage = new Garage("Sofia", 3);
                car = new Car("Ford", 0);
                string expecte = $"There are {0} which are not fixed: .";
                string actual = garage.Report();
                Assert.AreEqual(expecte, actual);

            }
        }
    }
}