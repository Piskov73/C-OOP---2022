using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace RobotFactory.Tests
{
    public class Tests
    {
        private Supplement supplement;
        private Robot robot;
        private Factory factory;
        [SetUp]
        public void Setup()
        {
            supplement = new Supplement("Name", 1);
            robot = new Robot("Model", 10.5, 2);
            factory = new Factory("name", 1);
        }
        [Test]
        public void Test_SupplementConstructor()
        {
            string nameSupplement = "Lazer";
            int standart = 1020;
            supplement = new Supplement(nameSupplement, standart);

            Assert.NotNull(supplement);

            Assert.That(supplement.Name, Is.EqualTo(nameSupplement));

            Assert.That(supplement.InterfaceStandard, Is.EqualTo(standart));

            string expekted = $"Supplement: {nameSupplement} IS: {standart}";

            string actual = supplement.ToString();

            Assert.That(actual, Is.EqualTo(expekted));
        }
        [Test]
        public void Test_RobotConstructor()
        {
            string model = "Terminator";
            double price = 250.50;
            int interfaceStandard = 2040;

            robot = new Robot(model, price, interfaceStandard);

            Assert.NotNull(robot);

            Assert.That(robot.Model, Is.EqualTo(model));

            Assert.That(robot.Price, Is.EqualTo(price));

            Assert.That(robot.InterfaceStandard, Is.EqualTo(interfaceStandard));
            string expected = $"Robot model: {model} IS: {interfaceStandard}, Price: {price:f2}";
            string actual = robot.ToString();

            Assert.That(actual, Is.EqualTo(expected));

            Assert.That(robot.Supplements.Count, Is.EqualTo(0));
        }
        [Test]
        public void Test_FactoryConstructor()
        {
            string factoryName = "StarFacrory";
            int factoryCapacity = 2;

            factory = new Factory(factoryName, factoryCapacity);

            Assert.NotNull(factory);

            Assert.That(factory.Name, Is.EqualTo(factoryName));
            Assert.That(factory.Capacity, Is.EqualTo(factoryCapacity));
            Assert.That(factory.Robots.Count, Is.EqualTo(0));
            Assert.That(factory.Supplements.Count, Is.EqualTo(0));

        }
        [Test]
        public void Test_FactoryProduceRobot()
        {
            string modelRobot = "Terminator";
            double priceRobot = 250.50;
            int interfaceStandardRobot = 2040;

            robot = new Robot(modelRobot, priceRobot, interfaceStandardRobot);

            string factoryName = "StarFacrory";
            int factoryCapacity = 2;

            factory = new Factory(factoryName, factoryCapacity);

            string actual = factory.ProduceRobot(modelRobot, priceRobot, interfaceStandardRobot);
            string expected = $"Produced --> {robot}";

            Assert.That(expected, Is.EqualTo(actual));

            factory.ProduceRobot(modelRobot, priceRobot, interfaceStandardRobot);

            Assert.That(factory.Robots.Count, Is.EqualTo(2));

            expected = "The factory is unable to produce more robots for this production day!";
            actual = factory.ProduceRobot(modelRobot, priceRobot, interfaceStandardRobot);
            Assert.That(expected, Is.EqualTo(actual));
        }
        [Test]
        public void Test_FactoryProduceSupplement()
        {
            string nameSupplement = "Lazer";
            int standartSupplement = 1020;
            supplement = new Supplement(nameSupplement, standartSupplement);

            string factoryName = "StarFacrory";
            int factoryCapacity = 2;

            factory = new Factory(factoryName, factoryCapacity);

            string expected=supplement.ToString();
            string actual = factory.ProduceSupplement(nameSupplement, standartSupplement);

            Assert.That(actual, Is.EqualTo(expected));

            Assert.That(factory.Supplements.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test_FactoryUpgradeRobot()
        {
            string modelRobot = "Terminator";
            double priceRobot = 250.50;
            int interfaceStandardRobot = 2040;

            robot = new Robot(modelRobot, priceRobot, interfaceStandardRobot);

            string nameSupplement = "Lazer";
            int standartSupplement = 2040;

            supplement = new Supplement(nameSupplement, standartSupplement);

            string factoryName = "StarFacrory";
            int factoryCapacity = 2;

            factory = new Factory(factoryName, factoryCapacity);

            factory.ProduceRobot(modelRobot, priceRobot, interfaceStandardRobot);
            factory.ProduceSupplement(nameSupplement, standartSupplement);

            Assert.True(factory.UpgradeRobot(robot, supplement));

            Assert.That(robot.Supplements.Count, Is.EqualTo(1));

            Assert.False(factory.UpgradeRobot(robot, supplement));

            supplement = new Supplement(nameSupplement, 1010);

            Assert.False(factory.UpgradeRobot(robot, supplement));
        }
        [Test]
        public void Test_FactorySellRobot()
        {
            string modelRobot = "Terminator";
            double priceRobot = 250.50;
            int interfaceStandardRobot = 2040;

            string nameSupplement = "Lazer";
            int standartSupplement = 2040;

            string factoryName = "StarFacrory";
            int factoryCapacity = 2;

            factory = new Factory(factoryName, factoryCapacity);

            factory.ProduceRobot(modelRobot, priceRobot, interfaceStandardRobot);
            factory.ProduceSupplement(nameSupplement, standartSupplement);

            Assert.NotNull(factory.SellRobot(300));
            Assert.Null(factory.SellRobot(200));
        }

    }
}