namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Fish fish;
        private Aquarium aquarium;
        [SetUp]
        public void SetUp()
        {
            fish = new Fish("Name");
            aquarium = new Aquarium("AquariumName", 2);
        }
        [Test]
        public void Test_FishConstuctor()
        {
            string name = "FishName";

            fish = new Fish(name);

            Assert.NotNull(fish);

            Assert.AreEqual(name, fish.Name);

            Assert.True(fish.Available);
        }
        [Test]
        public void Test_AquariumsConctructor()
        {
            Assert.NotNull(aquarium);
        }
        [Test]
        public void Test_AquariumsName()
        {
            string aquariumName = "AquariumName";

            int capacity = 2;

            aquarium = new Aquarium(aquariumName, capacity);

            Assert.AreEqual(aquariumName, aquarium.Name);

            aquariumName = null;

            Assert.Throws<ArgumentNullException>(() => new Aquarium(aquariumName, capacity), "Invalid aquarium name!");
        }
        [Test]
        public void Test_AquariumsCapacity()
        {
            string aquariumName = "AquariumName";

            int capacity = 2;

            aquarium = new Aquarium(aquariumName, capacity);

            Assert.AreEqual(capacity, aquarium.Capacity);

            Assert.Throws<ArgumentException>(() => new Aquarium(aquariumName, -5), "Invalid aquarium capacity!");
        }
        [Test]
        public void Test_AquariumsCount()
        {
            string aquariumName = "AquariumName";

            int capacity = 2;

            aquarium = new Aquarium(aquariumName, capacity);

            Assert.AreEqual(0, aquarium.Count);

            aquarium.Add(fish);

            Assert.AreEqual(1, aquarium.Count);
        }
        [Test]
        public void Test_AquariumsAdd()
        {
            string aquariumName = "AquariumName";

            int capacity = 2;

            aquarium = new Aquarium(aquariumName, capacity);


            aquarium.Add(fish);


            aquarium.Add(new Fish("NewFish"));

            Assert.AreEqual(2, aquarium.Count);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Fish")), "Aquarium is full!");

        }
        [Test]
        public void Test_AquariumsRemoveFish()
        {
            string aquariumName = "AquariumName";

            int capacity = 2;

            aquarium = new Aquarium(aquariumName, capacity);

            string name = "FishName";

            fish = new Fish(name);

            aquarium.Add(fish);

            Assert.AreEqual(1, aquarium.Count);

            aquarium.RemoveFish(name);

            Assert.AreEqual(0, aquarium.Count);

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(name)
            , $"Fish with the name {name} doesn't exist!");

        }
        [Test]
        public void Test_AquariumsSellFish()
        {
            string aquariumName = "AquariumName";

            int capacity = 2;

            aquarium = new Aquarium(aquariumName, capacity);

            string name = "FishName";

            fish = new Fish(name);

            aquarium.Add(fish);

            var requestedFish = aquarium.SellFish(name);

            Assert.AreEqual(name, requestedFish.Name);
            Assert.False(requestedFish.Available);

            name = "Fish";

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(name)
            , $"Fish with the name {name} doesn't exist!");
        }
        [Test]
        public void Test_AquariumsReport()
        {
            string aquariumName = "AquariumName";

            int capacity = 2;

            aquarium = new Aquarium(aquariumName, capacity);

            string name = "FishName";

            fish = new Fish(name);

            aquarium.Add(fish);

            string expected = $"Fish available at {aquariumName}: {name}";
            string actual = aquarium.Report();

            Assert.AreEqual(expected, actual);
        }
    }
}
