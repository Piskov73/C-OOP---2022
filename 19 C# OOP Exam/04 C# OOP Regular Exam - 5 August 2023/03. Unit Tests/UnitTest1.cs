using NUnit.Framework;
using System.Data;
using System.Xml.Linq;

namespace VendingRetail.Tests
{
    public class Tests
    {
        private CoffeeMat coffeeMat;
        [SetUp]
        public void Setup()
        {
            coffeeMat = new CoffeeMat(100, 2);
        }
        [Test]
        public void Test_CoffeeMatConstructor()
        {
            int waterCapacity = 100;
            int buttonsCount = 2;

            coffeeMat=new CoffeeMat(waterCapacity, buttonsCount);

            Assert.NotNull(coffeeMat);
            Assert.AreEqual(waterCapacity , coffeeMat.WaterCapacity);
            Assert.AreEqual(buttonsCount, coffeeMat.ButtonsCount);
            Assert.AreEqual(0, coffeeMat.Income);

        }
        [Test]
        public void Test_CoffeeMatAddDrink()
        {
            int waterCapacity = 1000;
            int buttonsCount = 2;

            coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);

            string drinkKoffe = "Koffe";
            string drinkTea = "Tea";
            string drinkJuice = "Juice";
            double price = 1.10;

            Assert.True(coffeeMat.AddDrink(drinkKoffe, price));
            Assert.False(coffeeMat.AddDrink(drinkKoffe, price));
            coffeeMat.AddDrink(drinkTea, price);
            Assert.False(coffeeMat.AddDrink(drinkJuice, price));

        }
        [Test]
        public void Test_CoffeeMatFillWaterTank()
        {
            int waterCapacity = 1000;
            int buttonsCount = 2;

            coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);

            string expected= $"Water tank is filled with {waterCapacity}ml";
            string actual = coffeeMat.FillWaterTank();

            Assert.AreEqual(expected, actual);

            expected= $"Water tank is already full!";
            actual= coffeeMat.FillWaterTank();

           Assert.AreEqual(expected , actual);
        }
        [Test]
        public void Test_CoffeeMatBuyDrink()
        {
            int waterCapacity = 100;
            int buttonsCount = 2;

            coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);
            coffeeMat.FillWaterTank();

            string drinkKoffe = "Koffe";
            string drinkTea = "Tea";
            string drinkJuice = "Juice";
            double price = 1.10;

            coffeeMat.AddDrink(drinkKoffe, price);
            coffeeMat.AddDrink(drinkTea, price);

            string expected= $"{drinkJuice} is not available!";
            string actual = coffeeMat.BuyDrink(drinkJuice);

            Assert.AreEqual(expected, actual);

            expected = $"Your bill is {price:f2}$";
            actual = coffeeMat.BuyDrink(drinkKoffe);

            Assert.AreEqual(expected, actual);

            expected= $"CoffeeMat is out of water!";
            actual = coffeeMat.BuyDrink(drinkTea);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_CoffeeMatCollectIncome()
        {
            int waterCapacity = 1000;
            int buttonsCount = 3;

            coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);
            coffeeMat.FillWaterTank();

            string drinkKoffe = "Koffe";
            string drinkTea = "Tea";
            string drinkJuice = "Juice";
            double price = 1.10;

            coffeeMat.AddDrink(drinkKoffe, price);
            coffeeMat.AddDrink(drinkTea, price);
            coffeeMat.AddDrink(drinkJuice, price);

            coffeeMat.BuyDrink(drinkKoffe);
            coffeeMat.BuyDrink(drinkTea);
            coffeeMat.BuyDrink(drinkJuice);
            coffeeMat.BuyDrink(drinkKoffe);

            double result = price * 4;

            Assert.AreEqual(result, coffeeMat.Income);

            Assert.AreEqual(result, coffeeMat.CollectIncome());

            Assert.AreEqual(0, coffeeMat.Income);
        }        
    }
}