using NUnit.Framework;
using System.Xml.Linq;

namespace VendingRetail.Tests
{
    public class Tests
    {
        private CoffeeMat coffee;

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Test_ConstruktorCoffeeMat()
        {
            int waterCapaciti = 100;
            int butonCouht = 5;
            coffee = new CoffeeMat(waterCapaciti, butonCouht);
            Assert.IsNotNull(coffee);
            Assert.AreEqual(waterCapaciti, coffee.WaterCapacity);
            Assert.AreEqual(butonCouht, coffee.ButtonsCount);
            Assert.AreEqual(0, coffee.Income);

        }
        [Test]
        public void Test_FillWaterTank()
        {
            int waterCapaciti = 100;
            int butonCouht = 5;
            coffee = new CoffeeMat(waterCapaciti, butonCouht);
            string expect = $"Water tank is filled with {waterCapaciti}ml";
            Assert.AreEqual(expect, coffee.FillWaterTank());

            expect = "Water tank is already full!";
            Assert.AreEqual(expect, coffee.FillWaterTank());
        }

        [Test]
        public void Test_AddDrink()
        {
            int waterCapaciti = 100;
            int butonCouht = 2;
            coffee = new CoffeeMat(waterCapaciti, butonCouht);
            coffee.FillWaterTank();
            Assert.True(coffee.AddDrink("Koffee", 1.2));
            Assert.False(coffee.AddDrink("Koffee", 1.2));
            Assert.True(coffee.AddDrink("Tea", 1.2));
            Assert.False(coffee.AddDrink("Juice", 1.2));

        }
        [Test]
        public void Test_BuyDrink()
        {
            int waterCapaciti = 100;
            int butonCouht = 3;
            double priceToPay = 1.20;
            coffee = new CoffeeMat(waterCapaciti, butonCouht);
            coffee.FillWaterTank();
            coffee.AddDrink("Koffee", priceToPay);
            coffee.AddDrink("Tea", priceToPay);
            coffee.AddDrink("Juice", priceToPay);

           string actual= coffee.BuyDrink("Koffee");

            string expecte = $"Your bill is {priceToPay:f2}$";

            Assert.AreEqual(expecte, actual);
            Assert.AreEqual(priceToPay, coffee.Income);
            expecte = "CoffeeMat is out of water!";
            actual= coffee.BuyDrink("Koffee");

            Assert.AreEqual(expecte , actual);
            Assert.AreEqual(priceToPay, coffee.Income);
            coffee.FillWaterTank();

            actual = coffee.BuyDrink("Nesto");
            expecte = "Nesto is not available!";
            Assert.AreEqual(expecte, actual);
            Assert.AreEqual(priceToPay, coffee.Income);

        }
        [Test]
        public void Test_CollectIncome()
        {
            int waterCapaciti = 1000;
            int butonCouht = 4;
            double priceToPay = 1.20;
            coffee = new CoffeeMat(waterCapaciti, butonCouht);
            coffee.FillWaterTank();
            coffee.AddDrink("Koffee", priceToPay);
            coffee.AddDrink("Tea", priceToPay);
            coffee.AddDrink("Juice", priceToPay);

            coffee.BuyDrink("Koffee");
            coffee.BuyDrink("Koffee");
            coffee.BuyDrink("Tea");
            coffee.BuyDrink("Tea");
            coffee.BuyDrink("Juice");
            coffee.BuyDrink("Juice");

            double expekt =  priceToPay+priceToPay+priceToPay+priceToPay+priceToPay+priceToPay;
            double actual = coffee.CollectIncome();
            Assert.AreEqual(expekt, actual);
            Assert.AreEqual(0, coffee.Income);

        }



    }
}