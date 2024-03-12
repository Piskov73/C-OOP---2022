namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Xml.Linq;

    public class RobotsTests
    {
        private Robot robot;
        private RobotManager manager;
        [SetUp]
        public void SetUp()
        {
            robot = new Robot("Robot1", 100);
            manager = new RobotManager(10);
        }
        [Test]
        public void Test_RobotConstruktor()
        {
            string name = "Robot1";
            int maximumBattery = 100;

            robot = new Robot(name, maximumBattery);

            Assert.NotNull(robot);

            Assert.AreEqual(name, robot.Name);

            Assert.AreEqual(maximumBattery, robot.MaximumBattery);

            Assert.AreEqual(maximumBattery, robot.Battery);
        }
        [Test]
        public void Test_RobotManagerConstructor()
        {
            int capacity = 2;

            manager = new RobotManager(capacity);

            Assert.NotNull(manager);

            Assert.AreEqual(0, manager.Count);
        }
        [Test]
        public void Test_RobotManagerCapacity()
        {
            int capacity = 2;

            manager = new RobotManager(capacity);

            Assert.AreEqual(capacity, manager.Capacity);

            capacity = -5;

            Assert.Throws<ArgumentException>(() => new RobotManager(capacity), "Invalid capacity!");
        }
        [Test]
        public void Test_RobotManagerAdd()
        {
            int capacity = 2;

            manager = new RobotManager(capacity);

            string name = "Robot1";
            int maximumBattery = 100;

            robot = new Robot(name, maximumBattery);

            manager.Add(robot);

            Assert.AreEqual(1, manager.Count);

            Assert.Throws<InvalidOperationException>(() => manager.Add(robot), $"There is already a robot with name {robot.Name}!");

            manager.Add(new Robot("Robor2", maximumBattery));

            Assert.AreEqual(2, manager.Count);

            Assert.Throws<InvalidOperationException>(() => manager.Add(new Robot("Robot3", maximumBattery)), "Not enough capacity!");
        }
        [Test]
        public void Test_RobotManagerRemove()
        {
            int capacity = 2;

            manager = new RobotManager(capacity);

            string name = "Robot1";

            int maximumBattery = 100;

            robot = new Robot(name, maximumBattery);

            manager.Add(robot);

            manager.Add(new Robot("Robot2", maximumBattery));

            Assert.AreEqual(2, manager.Count);

            manager.Remove(name);

            Assert.AreEqual(1, manager.Count);

            Assert.Throws<InvalidOperationException>(() => manager.Remove(name), $"Robot with the name {name} doesn't exist!");

        }
        [Test]
        public void Test_RobotManagerWork()
        {
            int capacity = 2;

            manager = new RobotManager(capacity);

            string name = "Robot1";

            int maximumBattery = 100;

            robot = new Robot(name, maximumBattery);

            manager.Add(robot);

            manager.Add(new Robot("Robot2", maximumBattery));

            string job = "Job";
            int batteryUsage = 70;

            string noNameRobot = "RobotT1000";

            Assert.Throws<InvalidOperationException>(() => manager.Work(noNameRobot, job, batteryUsage)
            , $"Robot with the name {noNameRobot} doesn't exist!");

            manager.Work(name, job, batteryUsage);

            Assert.AreEqual(maximumBattery - batteryUsage, robot.Battery);

            Assert.Throws<InvalidOperationException>(() => manager.Work(name, job, batteryUsage)
            , $"{robot.Name} doesn't have enough battery!");
        }
        [Test]
        public void Test_RobotManagerCharge()
        {
            int capacity = 2;

            manager = new RobotManager(capacity);

            string name = "Robot1";

            int maximumBattery = 100;

            robot = new Robot(name, maximumBattery);

            manager.Add(robot);

            manager.Add(new Robot("Robot2", maximumBattery));

            string job = "Job";
            int batteryUsage = 70;

            string noNameRobot = "RobotT1000";

            manager.Work(name, job, batteryUsage);

            Assert.AreEqual(maximumBattery - batteryUsage, robot.Battery);

            manager.Charge(name);

            Assert.AreEqual(maximumBattery, robot.Battery);

            Assert.Throws<InvalidOperationException>(() => manager.Charge(noNameRobot)
            , $"Robot with the name {noNameRobot} doesn't exist!");
        }
    }
}
