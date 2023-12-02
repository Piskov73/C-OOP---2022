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
            present = new Present("Test Present", 100);
            bag = new Bag();

        }
        [Test]
        public void Tes_ConstructorPresent()
        {
            Assert.NotNull(present);
            Assert.AreEqual("Test Present",present.Name);
            Assert.AreEqual(100,present.Magic);
        }
        [Test]
        public void Test_BagCreate()
        {
            Assert.NotNull (bag);
            string actual = bag.Create(present);
            string expecte = $"Successfully added present {present.Name}.";
            Assert.AreEqual(expecte, actual);

            Assert.Throws<InvalidOperationException>(()=>bag.Create(present), "This present already exists!");

            present = null;
            Assert.Throws<ArgumentNullException>(() => bag.Create(present), "Present is null");
        }
        [Test]
        public void Test_BagRemove()
        {
            bag.Create(present);
            int actual = bag.GetPresents().Count;
            Assert.AreEqual(1, actual);
            bag.Remove(present);
            actual=bag.GetPresents().Count;
            Assert.AreEqual(0, actual);
        }
        [Test]
        public void Test_BagGetPresentWithLeastMagic()
        {
            Present present1 = new Present("Test2", 50);
            bag.Create(present1);
            bag.Create(present);

            var expectePresent=bag.GetPresentWithLeastMagic();
            Assert.AreEqual(expectePresent, present1);  
        }
        [Test]
        public void Test_BagGetPresent()
        {
            Present present1 = new Present("Test2", 50);
            bag.Create(present1);
            bag.Create(present);

            var expectePresent = bag.GetPresent("Test2");

            Assert.AreEqual(expectePresent, present1);

            Assert.Null(bag.GetPresent("NotName"));
        }
        [Test]
        public void Test_BagGetPresents()
        {
            Present present1 = new Present("Test2", 50);
            bag.Create(present1);
            bag.Create(present);
            int actual = bag.GetPresents().Count;
            Assert.AreEqual(2, actual);
        }
    }
}
