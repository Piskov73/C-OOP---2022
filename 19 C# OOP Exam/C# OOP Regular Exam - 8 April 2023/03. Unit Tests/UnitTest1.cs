using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Xml;

namespace RobotFactory.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

       
        [Test]
        public void Test_ConstuktorFactory()
        {
            string name = "Plovdib";
            int capacity = 10;

            Factory factory = new Factory(name, capacity);

            Assert.NotNull(factory);
            Assert.AreEqual(name, factory.Name);
            Assert.AreEqual(capacity, factory.Capacity);
            Assert.AreEqual(0, factory.Robots.Count);
            Assert.AreEqual(0, factory.Supplements.Count);

            Assert.NotNull(factory.Robots);
            Assert.NotNull(factory.Supplements);
        }

        [Test]
        public void Test_ConstuktorRobot()
        {


            string model = "Ziro";
            double price = 320.50;
            int interfaceStandard = 1010;

            Robot robot = new Robot(model, price, interfaceStandard);

            Assert.NotNull(robot);
            Assert.AreEqual(model, robot.Model);
            Assert.AreEqual(price, robot.Price);
            Assert.AreEqual(interfaceStandard, robot.InterfaceStandard);
            Assert.AreEqual(0, robot.Supplements.Count);

            string expecte = $"Robot model: {model} IS: {interfaceStandard}, Price: {price:f2}";
            string actual = robot.ToString();

            Assert.AreEqual(expecte, actual);
        }

        [Test]
        public void Test_ConstruktorSupplement()
        {
            //      public string Name { get; set; }

            //public int InterfaceStandard { get; set; }

            string name = "Lazer";
            int interfaceStandard = 1010;

            Supplement supplement = new Supplement(name,    interfaceStandard);

            Assert.NotNull(supplement);
            Assert.AreEqual(name, supplement.Name);
            Assert.AreEqual(interfaceStandard,supplement.InterfaceStandard);

            string expecte= $"Supplement: {name} IS: {interfaceStandard}";
            string actual=supplement.ToString();

            Assert.AreEqual(expecte, actual);
        }

        [Test]
        public void Test_MethodProduceRobot()
        {
            string name = "Plovdib";
            int capacity = 1;

            Factory factory = new Factory(name, capacity);

            string model = "Ziro";
            double price = 320.50;
            int interfaceStandard = 1010;

            Robot robot = new Robot(model, price, interfaceStandard);
            string expecte = $"Produced --> {robot.ToString()}";
            string actual=factory.ProduceRobot(model, price, interfaceStandard);

            Assert.AreEqual(expecte , actual);

            expecte = "The factory is unable to produce more robots for this production day!";

            actual = factory.ProduceRobot("Hachiko", price, interfaceStandard);

            Assert.AreEqual(expecte , actual);

            Assert.AreEqual(1,factory.Robots.Count);

        }

      
        [Test]
        public void Test_MethodProduceSupplement()
        {
            string nameSuplemrnt = "Lazer";
            int interfaceStandard = 1010;

            Supplement supplement = new Supplement(nameSuplemrnt, interfaceStandard);

            string nameFactory = "Plovdib";
            int capacity = 1;

            Factory factory = new Factory(nameFactory, capacity);

            string expecte = supplement.ToString();

            string actual=factory.ProduceSupplement(nameSuplemrnt, interfaceStandard);

            Assert.AreEqual(expecte , actual);

            Assert.AreEqual(1,factory.Supplements.Count);
        }

     
        [Test]

        public void Test_MethodUpgradeRobot()
        {
            string nameFactory = "Plovdib";
            int capacity = 10;

            Factory factory = new Factory(nameFactory, capacity);

            string nameSuplemrnt = "Lazer";
            int interfaceStandard = 1010;

            Supplement supplement = new Supplement(nameSuplemrnt, interfaceStandard);

            string model = "Ziro";
            double price = 320.50;
            int interfaceStandardRobot = 1010;

            Robot robot = new Robot(model, price, interfaceStandardRobot);

            factory.ProduceSupplement(nameSuplemrnt, interfaceStandard);
            factory.ProduceRobot(model, price, interfaceStandardRobot);

            Assert.True(factory.UpgradeRobot(robot, supplement));
            Assert.False(factory.UpgradeRobot(robot, supplement));

            supplement = new Supplement(nameSuplemrnt, 021);
            Assert.False(factory.UpgradeRobot(robot, supplement));

        }

        [Test]
        public void Test_MethodSellRobot()
        {
            string nameFactory = "Plovdib";
            int capacity = 10;

            Factory factory = new Factory(nameFactory, capacity);
            string model = "Ziro";
            double price = 320.50;
            int interfaceStandardRobot = 1010;

            

            factory.ProduceRobot(model, price,interfaceStandardRobot);
            factory.ProduceRobot(model, 250,interfaceStandardRobot);
            factory.ProduceRobot(model, 500,interfaceStandardRobot);

            Assert.NotNull(factory.SellRobot(356.25));
            Assert.Null(factory.SellRobot(100));




        }
    }
}