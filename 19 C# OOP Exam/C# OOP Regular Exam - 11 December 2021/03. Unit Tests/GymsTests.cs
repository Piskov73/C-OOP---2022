using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        private Athlete athlete;
        private Gym gym;
        [SetUp]
        public void SetUp()
        {
            athlete = new Athlete("TestName");
            gym = new Gym("TestGym", 2);
        }
        [Test]
        public void Test_AthleteConstructor()
        {
            Assert.NotNull(athlete);
            Assert.AreEqual("TestName", athlete.FullName);
            Assert.False(athlete.IsInjured);
        }
        [Test]
        public void Test_GymConstructor()
        {
            Assert.NotNull(gym);
            Assert.AreEqual("TestGym", gym.Name);
            Assert.AreEqual(2, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
            
        }
        [Test]
        public void Test_GymName()
        {
            Assert.AreEqual("TestGym", gym.Name);

            string name = null;

            Assert.Throws<ArgumentNullException>(() => new Gym(name, 1), "Invalid gym name.");
        }

        [Test]
        public void Test_GymCapacity()
        {
            Assert.AreEqual(2,gym.Capacity);

            Assert.Throws<ArgumentException>(() => new Gym("Test", -5));
        }
        [Test]
        public void Test_GymCount()
        {
            Assert.AreEqual(0, gym.Count);

            gym.AddAthlete(athlete);

            Assert.AreEqual(1, gym.Count);

        }
        [Test]
        public void Test_GymAddAthlete()
        {
          gym.AddAthlete(athlete);
            gym.AddAthlete(new Athlete("Name2"));
            Assert.Throws<InvalidOperationException>(() =>gym.AddAthlete(athlete), "The gym is full.");
        }

        [Test]
        public void Test_GymRemoveAthlete()
        {
            gym.AddAthlete(athlete);
            gym.AddAthlete(new Athlete("Name2"));
            Assert.AreEqual(2,gym.Count);

            gym.RemoveAthlete("Name2");

            Assert.AreEqual(1, gym.Count);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Test"), "The athlete Test doesn't exist.");

        }
        [Test]
        public void Test_GymInjureAthlete()
        {
            gym.AddAthlete(athlete);

            var athlete2 = new Athlete("Name2");

            gym.AddAthlete(athlete2);

            gym.InjureAthlete("Name2");

            Assert.True(athlete2.IsInjured);

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("NameTest2"), $"The athlete NameTest2 doesn't exist.");
        }
        [Test]
        public void Test_Gym()
        {
            gym.AddAthlete(athlete);

            var athlete2 = new Athlete("Name2");

            gym.AddAthlete(athlete2);

            gym.InjureAthlete("Name2");

            string expecte= $"Active athletes at {gym.Name}: {athlete.FullName}";

            string actual = gym.Report();

            Assert.AreEqual(expecte, actual);
        }
    }
}
