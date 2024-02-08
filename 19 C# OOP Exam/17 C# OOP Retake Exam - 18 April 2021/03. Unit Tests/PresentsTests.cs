namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        private Bag bag;
        [SetUp]
        public void SetUp()
        {
            present = new Present("Name", 20);
            bag = new Bag();
        }
        [Test]
        public void Test_Present()
        {
            Assert.NotNull(present);

            Assert.AreEqual("Name", present.Name);
            Assert.AreEqual(20, present.Magic);
        }
        [Test]
        public void Test_BagConstructor()
        {
            Assert.NotNull(bag);
        }
        [Test]
        public void Test_BagCreate()
        {
            string name = "Name";
            double magic = 100;

            present=new Present(name, magic);

            string expected= $"Successfully added present {name}.";
            string actual = bag.Create(present);

            Assert.AreEqual(expected, actual);

            Assert.Throws<InvalidOperationException>(()=>bag.Create(present), "This present already exists!");

            present = null;
            Assert.Throws<ArgumentNullException>(() => bag.Create(present), "Present is null");
        }
        [Test]
        public void Test_BagRemove()
        {
            string name = "Name";
            double magic = 100;

            present = new Present(name, magic);

            bag.Create(present);

            Assert.True(bag.Remove(present));
            Assert.False(bag.Remove(present));
        }
        [Test]
        public void Test_BagGetPresentWithLeastMagic()
        {
            string name = "Name";
            double magic = 100;

            present = new Present(name, magic);

            bag.Create(present);
            bag.Create(new Present("KOCHO", 200));

            var pre=bag.GetPresentWithLeastMagic();

            Assert.AreEqual(pre, present);
            Assert.AreEqual(magic, pre.Magic);
            Assert.AreEqual(name, pre.Name);
        }
        [Test]
        public void Test_BagGetPresent()
        {
            string name = "Name";
            double magic = 100;

            present = new Present(name, magic);

            bag.Create(present);
            bag.Create(new Present("KOCHO", 200));

            Assert.NotNull(bag.GetPresent(name));
            Assert.Null(bag.GetPresent("Vancho"));

        }
        [Test]
        public void Test_BagGetPresents()
        {
            string name = "Name";
            double magic = 100;

            present = new Present(name, magic);

            bag.Create(present);
            bag.Create(new Present("KOCHO", 200));

            var getPresents = bag.GetPresents();

            Assert.AreEqual(2,getPresents.Count);
        }
    }
}
