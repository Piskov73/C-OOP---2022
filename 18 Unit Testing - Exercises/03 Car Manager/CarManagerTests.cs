namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void Test_InputValidPropertieMake()
        {
            string expectMake = "Ford";
            var car = new Car(expectMake,"Fokus",10,50);
            string actualyMake = car.Make;
            Assert.AreEqual(expectMake, actualyMake);
        }
        [Test]
        public void Test_ArgumentExceptionInputPropertieMakeNull()
        {
            string expectMake = null;

            Assert.Throws<ArgumentException>(() => new Car(expectMake, "Fokus", 10, 50), "Make cannot be null or empty!");
        }
        [Test]
        public void Test_InputValidPropertieModel()
        {
            string expectModel = "Fokus";
            Car car = new Car("Ford", expectModel, 10, 50);
            string actualyModel = car.Model;
            Assert.AreEqual(expectModel, actualyModel);
        }
        [Test]
        public void Test_ArgumentExceptionInputPropertieModelNull()
        {
            string expectModl = null;
            Assert.Throws<ArgumentException>(() => new Car("Ford", expectModl, 10, 50), "Model cannot be null or empty!");
        }
        [Test]
        public void Test_InputValidPropertieFuelConsumption()
        {
            double expectFuelConsumption = 10;
            Car car = new Car("Ford", "Fokus", expectFuelConsumption, 50);
            double actualyFuelConsumption = car.FuelConsumption;
            Assert.AreEqual(expectFuelConsumption, actualyFuelConsumption);

        }
        [TestCase(0.0)]
        [TestCase(-20.0)]
        [TestCase(-2000000.0)]
        public void Test_ArgumentExceptionInputPropertieFuelConsumptionZeroOrNegativ(double valio)
        {
            double expectFuelConsumption = valio;
            Assert.Throws<ArgumentException>(() => new Car("Ford", "Fokus", expectFuelConsumption, 50), "Fuel consumption cannot be zero or negative!");
        }
        [TestCase(1.0)]
        [TestCase(20.0)]
        [TestCase(100.0)]
        public void Test_InputValidPropertieFuleCapacity(double fule)
        {
            double expectFuleCapacity= fule;
            Car car = new Car("Ford", "Focus", 10, expectFuleCapacity);
            double actualFuleCapacity = car.FuelCapacity;
            Assert.AreEqual(expectFuleCapacity, actualFuleCapacity);
        }
        [TestCase(0.0)]
        [TestCase(-20.0)]
        [TestCase(-2000000.0)]
        public void Test_ArgumentExceptionInputPropertieFuelCapacityZeroOrNegative(double fuel)
        {
            double expectFuleCapacity = fuel;
            Assert.Throws<ArgumentException>(() => new Car("Ford", "Fokus", 10, expectFuleCapacity), "Fuel capacity cannot be zero or negative!");
        }

        [TestCase(10.0)]
        [TestCase(50.0)]
       
        public void Test_InputValidPropertieFuelAmount(double fule)
        {
            double expectFuelAmount=fule;
            Car car = new Car("Ford", "Focus", 10, 50);
            car.Refuel(fule);
            double actualFuleAmont= car.FuelAmount;
            Assert.AreEqual(expectFuelAmount, actualFuleAmont);
            
        }
        [TestCase(10.0)]
        [TestCase(50.0)]

        public void Test_InputValidMethodRefuel(double fule)
        {
            double expectFuelAmount = fule;
            Car car = new Car("Ford", "Focus", 10, 50);
            car.Refuel(fule);
            double actualFuleAmont = car.FuelAmount;
            Assert.AreEqual(expectFuelAmount, actualFuleAmont);

        }
        [Test]
        public void Test_FillingWithFuelMoreThanTheCapacityOfTheTank()
        {
            double fuel = 100;
            Car car = new Car("Ford", "Focus", 10, 50);
            car.Refuel(fuel);
            double expectFuelAmount = car.FuelCapacity;
            double actualFuel = car.FuelAmount;
            Assert.AreEqual(expectFuelAmount,actualFuel);

        }
        [TestCase(0.0)]
        [TestCase(-20.0)]
        [TestCase(-2000000.0)]
        public void Test_ArgumentExceptionMethodRefuelZeroOrNegativ(double fuel)
        {
            Car car = new Car("Ford", "Focus", 10, 50);
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel), "Fuel amount cannot be zero or negative!");
        }
        [Test]
        public void Test_ValidMethodDrive()
        {
            double distance = 200;
            double expectFuelAmount =50.0- (distance / 100) * 10;
            Car car = new Car("Ford", "Focus", 10, 50);
            car.Refuel(50);
            car.Drive(distance);
            double actualFuelAmount=car.FuelAmount;
            Assert.AreEqual(expectFuelAmount,actualFuelAmount);

        }
        [Test]
        public void Test_InvalidOperationExceptionMethodDrive() 
        {
            Car car = new Car("Ford", "Focus", 10, 50);
            Assert.Throws<InvalidOperationException>(() => car.Drive(100), "You don't have enough fuel to drive!");
        }


    }
}