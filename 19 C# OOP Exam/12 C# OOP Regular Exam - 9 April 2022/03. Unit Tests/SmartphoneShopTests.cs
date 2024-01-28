using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartphone;
        private Shop shop;
        [SetUp]
        public void SetUp()
        {

        }
        [Test]
        public void Test_SmartphoneConstructor()
        {
            string modelName = "Nokia";
            int maximumBatteryCharge = 100;

            smartphone = new Smartphone(modelName, maximumBatteryCharge);

            Assert.NotNull(smartphone);
            Assert.AreEqual(modelName, smartphone.ModelName);
            Assert.AreEqual(maximumBatteryCharge, smartphone.MaximumBatteryCharge);
            Assert.AreEqual(maximumBatteryCharge, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void Test_ShopConstuctor()
        {
            int capasity = 2;
            shop = new Shop(capasity);
            Assert.NotNull(shop);
            Assert.AreEqual(0, shop.Count);
        }
        [Test]
        public void Test_ShopCapasity()
        {
            int capasity = 2;
            shop = new Shop(capasity);

            Assert.AreEqual(capasity, shop.Capacity);

            capasity = -5;

            Assert.Throws<ArgumentException>(() => new Shop(capasity), "Invalid capacity.");
        }
        [Test]
        public void Test_ShopAddSmartphone()
        {
            string modelName = "Nokia";
            int maximumBatteryCharge = 100;

            smartphone = new Smartphone(modelName, maximumBatteryCharge);

            int capasity = 2;

            shop = new Shop(capasity);

            shop.Add(smartphone);

            Assert.That(shop.Count, Is.EqualTo(1));

            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone), $"The phone model {modelName} already exist.");

            shop.Add(new Smartphone("Sony", 4500));

            Assert.AreEqual(2, shop.Count);

            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("Samsung", 4000)), "The shop is full.");

        }
        [Test]
        public void Test_ShopRemove()
        {
            string modelName = "Nokia";
            int maximumBatteryCharge = 100;

            smartphone = new Smartphone(modelName, maximumBatteryCharge);

            int capasity = 2;

            shop = new Shop(capasity);

            shop.Add(smartphone);

            shop.Add(new Smartphone("Samsung", 4000));

            Assert.AreEqual(2, shop.Count);

            shop.Remove(modelName);

            Assert.AreEqual(1, shop.Count);

            Assert.Throws<InvalidOperationException>(() => shop.Remove(modelName), $"The phone model {modelName} doesn't exist.");

        }
        [Test]
        public void Test_ShopTestPhone()
        {
            string modelName = "Nokia";
            int maximumBatteryCharge = 1000;

            smartphone = new Smartphone(modelName, maximumBatteryCharge);

            int capasity = 2;

            shop = new Shop(capasity);

            shop.Add(smartphone);

            shop.Add(new Smartphone("Samsung", 4000));

            shop.TestPhone(modelName, 600);

            Assert.AreEqual(400, smartphone.CurrentBateryCharge);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(modelName, 600)
            , $"The phone model {modelName} is low on batery.");

            modelName = "Apeel";

            Assert.Throws<InvalidOperationException>(()=>shop.TestPhone(modelName, maximumBatteryCharge));  
        }
        [Test]
        public void Test_ShopChargePhone()
        {
            string modelName = "Nokia";
            int maximumBatteryCharge = 1000;

            smartphone = new Smartphone(modelName, maximumBatteryCharge);

            int capasity = 2;

            shop = new Shop(capasity);

            shop.Add(smartphone);

            shop.Add(new Smartphone("Samsung", 4000));

            shop.TestPhone(modelName, 600);

            Assert.AreEqual(400,smartphone.CurrentBateryCharge);

            string notFondPhone = "Note";

            Assert.Throws<InvalidOperationException>(()=>shop.ChargePhone(notFondPhone)
            , $"The phone model {notFondPhone} doesn't exist.");

            shop.ChargePhone(modelName);

            Assert.AreEqual(maximumBatteryCharge, smartphone.CurrentBateryCharge);
        }
    }
}