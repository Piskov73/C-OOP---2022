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
            robot = new Robot("RobotTest", 100);
            manager = new RobotManager(5);
        }
        [Test]
        public void Test_ConstructorRobot()
        {
            Assert.NotNull(robot);
            Assert.AreEqual("RobotTest", robot.Name);
            Assert.AreEqual(100, robot.Battery);
            Assert.AreEqual(100, robot.MaximumBattery);

        }
        [Test]
        public void Test_RobotManagerConstructor()
        {
            Assert.NotNull(manager);
        }
        [Test]
        public void Test_RobotManagerCapacity()
        {
            Assert.AreEqual(5, manager.Capacity);

            Assert.Throws<ArgumentException>(() => new RobotManager(-55));
        }
        [Test]
        public void Test_RobotManagerCount()
        {
            manager.Add(robot);
            Assert.AreEqual(1, manager.Count);
        }
        [Test]
        public void Test_RobotManagerAdd()
        {
            string nameRobot2 = "Test Robot 2";
            Robot robot2 = new Robot(nameRobot2, 50);
            manager = new RobotManager(2);
            manager.Add(robot2);
            manager.Add(robot);

            Assert.AreEqual(2, manager.Count);

            Assert.Throws<InvalidOperationException>(() => manager.Add(new Robot(nameRobot2, 50)), $"There is already a robot with name {nameRobot2}!");

            Assert.Throws<InvalidOperationException>(() => manager.Add(new Robot("Test Robot3", 50)), "Not enough capacity!");
        }
        [Test]
        public void Test_RobotManagerRemove()
        {
            string nameRobot2 = "Test Robot 2";
            Robot robot2 = new Robot(nameRobot2, 50);
            manager = new RobotManager(2);
            manager.Add(robot2);
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => manager.Remove("TestRobot$"), $"Robot with the name TestRobot$ doesn't exist!");

            manager.Remove(nameRobot2);

            Assert.AreEqual(1, manager.Count);
        }
        [Test]
        public void Test_RobotManagerWork()
        {
            string nameRobot2 = "Test Robot 2";
            Robot robot2 = new Robot(nameRobot2, 50);
            manager = new RobotManager(2);
            manager.Add(robot2);
            manager.Add(robot);

            manager.Work(nameRobot2, "Job", 30);

            Assert.AreEqual(20, robot2.Battery);

            Assert.Throws<InvalidOperationException>(()
                => manager.Work(nameRobot2, "Job", 30), $"{nameRobot2} doesn't have enough battery!");

            Assert.Throws<InvalidOperationException>(()
                =>manager.Work("Robot","Job",10), $"Robot with the name Robot doesn't exist!");
        }

        [Test]
        public void Test_RobotManagerCharge()
        {
            string nameRobot2 = "Test Robot 2";
            Robot robot2 = new Robot(nameRobot2, 50);
            manager = new RobotManager(2);
            manager.Add(robot2);
            manager.Add(robot);

            manager.Work(nameRobot2, "Job", 30);

            Assert.AreEqual(20, robot2.Battery);

            manager.Charge(nameRobot2);

            Assert.AreEqual(50, robot2.Battery);

            Assert.Throws<InvalidOperationException>(() => manager.Work("Robt", "Job", 30), $"Robot with the name Robt doesn't exist!");
        }
    }
}
