using System;
using System.Collections.Generic;
using NUnit.Framework;
using SwinAdventure;

namespace NUnitTests
{
    [TestFixture]

    public class TestInventory
    {
        private Item Item;
        private Inventory Inventory;


        [SetUp]
        public void SetUp()
        {
            Item = new Item(new string[] { "sword" }, "gold", "This is a gold sword for you");

            Inventory = new Inventory();
            Inventory.Put(Item);
        }

        [Test]
        public void TestFindItem()
        {
            bool real = Inventory.HasItem(Item.firstID);

            Assert.IsTrue(real, "Item in inventory spotted");
        }

        [Test]
        public void TestNoItemFind()
        {
            bool real = Inventory.HasItem("knife");
            Assert.IsFalse(real, "Item not found in inventory");
        }

        [Test]
        public void TestFetchItem()
        {
            Item fetcheItem = Inventory.Fetch(Item.firstID);

            Assert.AreEqual(fetcheItem, Item);
        }

        [Test]
        public void TestTakeItem()
        {
            Item tookItem = Inventory.Take(Item.firstID);
            bool real = Inventory.HasItem(Item.firstID);
            Assert.IsFalse(real, "To confirm item is taken");
        }
        [Test]
        public void TestItemList()
        {
            Assert.AreEqual("\ta gold (sword)\n", Inventory.ItemList);
        }
    }

}

