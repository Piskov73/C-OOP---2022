namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class AquariumsTests
    {
        private Fish fish;
        private Fish fish2;
        private Fish fish3;
        private Aquarium aquarium;
        [SetUp] 
        public void SetUp() 
        {
            fish = new Fish("Name");
            fish2 = new Fish("Name2");
            fish3 = new Fish("Name3");
            aquarium = new Aquarium("AquariumName", 10);

        }
        [Test]
        public void Test_FishConstructor()
        {
            Assert.NotNull(fish);
            Assert.AreEqual("Name",fish.Name);
            Assert.True(fish.Available);
        }
        [Test]
        public void Test_AquariumConstructor()
        {
            Assert.NotNull(aquarium);
            Assert.AreEqual("AquariumName",aquarium.Name);
            Assert.AreEqual(10,aquarium.Capacity);
        }
        [Test]
        public void Test_AquariumName()
        {
            string name = "AquariumName2";
            int capacity = 5;
            aquarium=new Aquarium(name, capacity);
            Assert.AreEqual(name, aquarium.Name);

            name = "";

            Assert.Throws<ArgumentNullException>(()=>new Aquarium(name,capacity), "Invalid aquarium name!");

            name = null;

            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, capacity), "Invalid aquarium name!");
        }

        [Test]
        public void Test_AquariumCapacity()
        {
            string name = "AquariumName2";
            int capacity = 5;
            aquarium = new Aquarium(name, capacity);

            Assert.AreEqual(5, aquarium.Capacity);

            capacity = -5;

            Assert.Throws<ArgumentException>(() => new Aquarium(name, capacity), "Invalid aquarium capacity!");
        }
        [Test]
        public void Test_AquariumAdd()
        {
            string name = "AquariumName2";
            int capacity = 2;
            aquarium = new Aquarium(name, capacity);
            aquarium.Add(fish);
            aquarium.Add(fish2);

            Assert.AreEqual(2, aquarium.Count);

            Assert.Throws<InvalidOperationException>(()=>aquarium.Add(fish3), "Aquarium is full!");
        }
        [Test]
        public void Test_AquariumCount()
        {
            string name = "AquariumName2";
            int capacity = 10;
            aquarium = new Aquarium(name, capacity);
            aquarium.Add(fish);
            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.Add(fish2);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            Assert.AreEqual(6, aquarium.Count);

        }
        [Test]
        public void Test_AquariumRemoveFish()
        {
            string name = "AquariumName2";
            int capacity = 10;
            aquarium = new Aquarium(name, capacity);
            aquarium.Add(fish);
            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.Add(fish2);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            Assert.AreEqual(6, aquarium.Count);

            aquarium.RemoveFish(fish.Name);

            Assert.AreEqual(5, aquarium.Count);

            Assert.Throws<InvalidOperationException>(()=> aquarium.RemoveFish("Nemo"), "Fish with the name Nemo doesn't exist!");
        }
        [Test]
        public void Test_AquariumSellFish()
        {
            string name = "AquariumName2";
            int capacity = 10;
            aquarium = new Aquarium(name, capacity);
            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            var expecte=aquarium.SellFish(fish.Name);
            var actual = fish;
            Assert.AreEqual(expecte, actual);

            Assert.False(expecte.Available);
            Assert.False(actual.Available);

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Nemo"), $"Fish with the name Nemo doesn't exist!");
        }
        [Test]
        public void Test_AquariumReport() 
        {
            string name = "AquariumName2";
            int capacity = 10;
            aquarium = new Aquarium(name, capacity);
            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

           List<string> names=new List<string>() { fish.Name,fish2.Name,fish3.Name};
            string fishNames = string.Join(", ",names);
            string expecte = $"Fish available at {name}: {fishNames}";

            string actual = aquarium.Report();

            Assert.AreEqual(expecte, actual);

        }

    }
}
