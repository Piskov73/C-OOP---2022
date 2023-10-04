using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        public Smartphone phone;
        public Shop shop;
        [SetUp]
        public void SetUp() 
        {
            Smartphone phone = new Smartphone("Nokia", 100);
            Shop shop = new Shop(1);
        }

        [Test]
        public void Test_ShopConstructor()
        {
            shop=new Shop(1);
            Assert.AreEqual(1, shop.Capacity);
        }
        [Test]
        public void Test_ArgumentExceptionConstructor()
        {
            Assert.Throws<ArgumentException>(() =>  new Shop(-1));
        }
        [Test]
        public void Test_ShopCount()
        {
            shop = new Shop(1);
            phone = new Smartphone("Nokia", 100);
            shop.Add(phone);
            Assert.AreEqual(1, shop.Count);
        }
        [Test]
        public void Test_ShopAddMethod()
        {
            shop = new Shop(1);
            phone = new Smartphone("Nokia", 100);
            shop.Add(phone);
            Assert.AreEqual(1, shop.Count);
        }
        [Test]
        public void Test_InvalidOperationExceptionShopAddMethod()
        {
            shop = new Shop(2);
            phone = new Smartphone("Nokia", 100);
            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(phone));
        }
        [Test]
        public void Test_ShopAddMethodOverflowCapacity()
        {
            shop = new Shop(1);
            phone = new Smartphone("Nokia", 100);
            shop.Add(phone);
            Smartphone phone2 = new Smartphone("Samsung", 100);

            Assert.Throws<InvalidOperationException>(() => shop.Add(phone2));
        }
        [Test]
        public void Test_ShopRemoveMethod()
        {
            shop = new Shop(1);
            phone = new Smartphone("Nokia", 100);
            shop.Add(phone);
            shop.Remove("Nokia");

            Assert.AreEqual(0, shop.Count);
        }
        [Test]
        public void Test_InvalidOperationExceptionShopRemoveMethod()
        {
            shop = new Shop(1);
            phone = new Smartphone("Nokia", 100);
            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => shop.Remove("Samsung"));
        }
        [Test]
        public void Test_ShopTestPhoneMethod()
        {
            shop = new Shop(1);
            phone = new Smartphone("Nokia", 100);
            shop.Add(phone);
            shop.TestPhone("Nokia", 50);

            Assert.AreEqual(50, phone.CurrentBateryCharge);
        }
        [Test]
        public void Test_ShopTestPhoneMissing()
        {
            shop = new Shop(1);
            phone = new Smartphone("Nokia", 100);
            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Samsung",150));
        }

        [Test]
        public void Test_ShopTestPhoneLowBatery()
        {
            shop = new Shop(1);
            phone = new Smartphone("Nokia", 100);
            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Nokia", 150));
        }

        [Test]
        public void Test_ShopChargePhone()
        {
            shop = new Shop(1);
            phone = new Smartphone("Nokia", 100);
            shop.Add(phone);
            shop.TestPhone("Nokia", 50);
            shop.ChargePhone("Nokia");
            Assert.AreEqual(phone.CurrentBateryCharge,phone.MaximumBatteryCharge);
        }

        [Test]
        public void Test_ShopChargePhoneMissing()
        {
            shop = new Shop(1);
            phone = new Smartphone("Nokia", 100);
            shop.Add(phone);
            shop.TestPhone("Nokia", 50);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("GtA"));
        }


    }
}
