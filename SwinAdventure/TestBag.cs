using System;
using System.Collections.Generic;
using NUnit.Framework;
using SwinAdventure;

namespace NUnitTests
{
    [TestFixture]

    public class TestBag
    {
        private Bag b1;
        private Bag b2;
        private Item gem;
        private Item shield;

        [SetUp]
        public void Setup()
        {
            b1 = new Bag(new string[] { "bag", "backpack" }, "backpack", "This is a backpack.");
            gem = new Item(new string[] { "gem", "magical" }, "gem", "A cute, magical gem.");
            b1.Inventory.Put(gem);
        }

        [Test]
        public void TestBagLocatesItself()
        {
            Assert.AreEqual(b1, b1.Locate("bag"));
            Assert.AreEqual(b1, b1.Locate("backpack"));
        }

        [Test]
        public void TestBagLocatesItem()
        {
            Assert.AreEqual(gem, b1.Locate("gem"));
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            Assert.AreEqual(null, b1.Locate("pikachu"));
        }

        [Test]
        public void TestBagFullDescription()
        {
            Assert.AreEqual("In the backpack you can see:\n\ta gem (gem)\n", b1.FullDescription);
        }

        [Test]
        public void TestBagInBag()
        {
            b2 = new Bag(new string[] { "chestbag", "bag" }, "chestbag", "This is a chestbag");
            shield = new Item(new string[] { "shield", "spade" }, "shovel", "This is a powerful shield.");
            b2.Inventory.Put(shield);
            b1.Inventory.Put(b2);

            Assert.AreEqual(gem, b1.Locate("gem"));
            Assert.AreEqual(b2, b1.Locate("chestbag"));
            Assert.AreEqual(null, b1.Locate("shield"));
        }
    }
}