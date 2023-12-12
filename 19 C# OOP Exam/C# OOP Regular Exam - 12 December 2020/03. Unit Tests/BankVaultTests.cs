using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private Item item2;
        private Item item3;
        private BankVault bank;
        [SetUp]
        public void Setup()
        {
            this.item = new Item("Owner", "ItemID");
            this.item2 = new Item("Owner2", "ItemID2");
            this.item3 = new Item("Owner3", "ItemID3");
            this.bank = new BankVault();
        }

        [Test]
        public void Test_Item()
        {
            string owner = "Owner";
            string itemID = "ItemID";

            item=new Item(owner, itemID);

            Assert.NotNull(item);

            Assert.AreEqual(owner, item.Owner);
            Assert.AreEqual(itemID, item.ItemId);
        }
        [Test]
        public void Test_BankVaultAddItem()
        {
            string owner = "Owner";
            string itemID = "ItemID";
            item = new Item(owner, itemID);

            string owner2 = "Owner2";
            string itemID2 = "ItemID2";
            item2 = new Item(owner2,itemID2);

            Assert.NotNull(bank);

            bank.AddItem("A1", item);
            bank.AddItem("A2", item2);

            Assert.NotNull(bank.VaultCells["A1"]);
            Assert.NotNull(bank.VaultCells["A2"]);

            Assert.Throws<ArgumentException>(() => bank.AddItem("H3", item3), "Cell doesn't exists!");
            Assert.Throws<ArgumentException>(() => bank.AddItem("A1", item3), "Cell is already taken!");

            item3 = new Item("Owner", itemID);
            Assert.Throws<InvalidOperationException>(() => bank.AddItem("A3", item3), "Item is already in cell!");


         
        }
        [Test]
        public void Test_BankVaultRemoveItem()
        {
            string owner = "Owner";
            string itemID = "ItemID";
            item = new Item(owner, itemID);

            string owner2 = "Owner2";
            string itemID2 = "ItemID2";
            item2 = new Item(owner2, itemID2);

            Assert.NotNull(bank);

            bank.AddItem("A1", item);
            bank.AddItem("A2", item2);

            string expecte= $"Remove item:{itemID2} successfully!";
            string actual = bank.RemoveItem("A2", item2);
            Assert.AreEqual(expecte, actual);

            Assert.Throws<ArgumentException>(() => bank.RemoveItem("D$", item), "Cell doesn't exists!");

            Assert.Throws<ArgumentException>(() => bank.RemoveItem("A1", item3), "Cell doesn't exists!");

        }
    }
}
