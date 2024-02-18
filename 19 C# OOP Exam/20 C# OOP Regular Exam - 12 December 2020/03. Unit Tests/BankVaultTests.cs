using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private BankVault bankVault;
        [SetUp]
        public void Setup()
        {
            item = new Item("Owner", "ItemID");
            bankVault = new BankVault();
        }

        [Test]
        public void Test_ItemConstructor()
        {
            string owne = "Owner";
            string itemId = "ItemID";

            item= new Item(owne, itemId);

            Assert.NotNull(item);

            Assert.AreEqual(itemId, item.ItemId);
            Assert.AreEqual(owne, item.Owner);
        }
        [Test]
        public void Test_BankVaultConstruktor()
        {
            bankVault = new BankVault();
            Assert.NotNull(bankVault);
            Assert.NotNull(bankVault.VaultCells);
        }
        [Test]
        public void Test_BankVaultAddItem()
        {
            string owne = "Owner";
            string itemId = "ItemID";

            item = new Item(owne, itemId);
            bankVault = new BankVault();
            string cell = "A1";
            string expected= $"Item:{itemId} saved successfully!";
            string actual = bankVault.AddItem(cell, item);

            Assert.AreEqual(expected, actual);

            Assert.Throws<ArgumentException>(()=>bankVault.AddItem("N", item), "Cell doesn't exists!");

            Assert.Throws<ArgumentException>(() => bankVault.AddItem(cell, item), "Cell is already taken!");

            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("A2", item), "Item is already in cell!");
        }
        [Test]
        public void Test_BankVaultRemoveItem()
        {
            string owne = "Owner";
            string itemId = "ItemID";

            item = new Item(owne, itemId);
            bankVault = new BankVault();
            string cell = "A1";

            bankVault.AddItem(cell, item);

            Item item2 = new Item("owne", "11");

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("T67", item), "Cell doesn't exists!");

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem(cell, item2), $"Item in that cell doesn't exists!");

            string expected= $"Remove item:{itemId} successfully!";
            string actual= bankVault.RemoveItem(cell, item);

            Assert.AreEqual(expected, actual);
        }
    }
}