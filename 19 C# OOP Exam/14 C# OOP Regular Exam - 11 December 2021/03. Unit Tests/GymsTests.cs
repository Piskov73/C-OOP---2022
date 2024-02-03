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
            this.athlete = new Athlete("AthleteName");
            this.gym = new Gym("GymName", 2);
        }
        [Test]
        public void Test_Athlete()
        {
            string fullName = "AthleteName";
            athlete = new Athlete(fullName);

            Assert.NotNull(athlete);

            Assert.AreEqual(fullName, athlete.FullName);

            Assert.False(athlete.IsInjured);
        }
        [Test]
        public void Test_GymConstrucktor()
        {
            string name = "GymName";
            int size = 2;

            gym=new Gym(name, size);

            Assert.NotNull(gym);
        }
        [Test]
        public void Test_GymName()
        {
            string name = "GymName";
            int size = 2;

            gym = new Gym(name, size);

            Assert.AreEqual(name, gym.Name);

            name = null;

            Assert.Throws<ArgumentNullException>(() => new Gym(name, size), "Invalid gym name.");
        }
        [Test]
        public void Test_GymCapacity()
        {
            string name = "GymName";
            int size = 2;

            gym = new Gym(name, size);

            Assert.AreEqual(size, gym.Capacity);

            size = -1;

            Assert.Throws<ArgumentException>(() => new Gym(name, size), "Invalid gym capacity.");
        }
        [Test]
        public void Test_GymCount()
        {
            string name = "GymName";
            int size = 2;

            gym = new Gym(name, size);

            Assert.AreEqual(0, gym.Count);
        }
        [Test]
        public void Test_GymAddAthlete()
        {
            string name = "GymName";
            int size = 2;

            gym = new Gym(name, size);

            string fullName = "AthleteName";

            athlete = new Athlete(fullName);

            gym.AddAthlete(athlete);

            Assert.AreEqual(1, gym.Count);

            gym.AddAthlete(new Athlete("Ivancho"));

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("Pencho")),"The gym is full.");
        }
        [Test]
        public void Test_GymRemoveAthlete()
        {
            string name = "GymName";
            int size = 2;

            gym = new Gym(name, size);

            string fullName = "AthleteName";

            athlete = new Athlete(fullName);

            gym.AddAthlete(athlete);

            gym.AddAthlete(new Athlete("Ivancho"));

            Assert.AreEqual(2, gym.Count);

            gym.RemoveAthlete(fullName);

            Assert.AreEqual(1, gym.Count);

            Assert.Throws<InvalidOperationException>(()=>gym.RemoveAthlete(name), $"The athlete {fullName} doesn't exist.");
        }
        [Test]
        public void Test_GymInjureAthlete()
        {
            string name = "GymName";
            int size = 2;

            gym = new Gym(name, size);

            string fullName = "AthleteName";

            athlete = new Athlete(fullName);

            gym.AddAthlete(athlete);

            gym.AddAthlete(new Athlete("Ivancho"));

            var result = gym.InjureAthlete(fullName);

            Assert.NotNull(result);

            Assert.True(result.IsInjured);

            string notAthlete = "Gosko";
            Assert.Throws<InvalidOperationException>(() =>gym.InjureAthlete(notAthlete), $"The athlete {notAthlete} doesn't exist.");
        }
        [Test]
        public void Test_GymReport()
        {
            string name = "GymName";
            int size = 2;

            gym = new Gym(name, size);

            string fullName = "AthleteName";

            athlete = new Athlete(fullName);

            gym.AddAthlete(athlete);

            gym.AddAthlete(new Athlete("Ivancho"));

            var result = gym.InjureAthlete("Ivancho");

            string expected = $"Active athletes at {name}: {fullName}";
            string actual = gym.Report();

            Assert.AreEqual(expected, actual);

        }
        
    }
}
