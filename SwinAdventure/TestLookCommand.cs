using System;
using System.Collections.Generic;
using NUnit.Framework;
using SwinAdventure;

namespace NUnitTests
{
    [TestFixture]

    public class TestLookCommand
    {
        Player p1;
        Item i1, i2;
        LookCommand look;
        Bag b1;
        Location location;

        [SetUp]
        public void Setup()
        {
            p1 = new Player("me", "inventory", location);

            i1 = new Item(new string[] { "sword", "gold sword" }, "sword", "a gold sword");

            i2 = new Item(new string[] { "gem", "magical gem" }, "gem", "a magical gem");

            b1 = new Bag(new string[] { "bag", "black bag" }, "a black bag", "cool bag");

            p1.Inventory.Put(i1);
            look = new LookCommand();
        }

        [Test]
        public void LookAtMe()
        {
            Assert.AreEqual(p1.FullDescription, look.Execute(p1, new string[] { "look", "at", "inventory" }));
        }

        [Test]
        public void LookAtGem()
        {
            p1.Inventory.Put(i2);
            Assert.AreEqual(i2.FullDescription, look.Execute(p1, new string[] { "look", "at", "gem" }));
        }

        [Test]
        public void LookAtUnk()
        {
            Assert.AreEqual("I can not find the gem.", look.Execute(p1, new string[] { "look", "at", "gem" }));
        }

        [Test]
        public void LookAtGemInMe()
        {
            p1.Inventory.Put(i2);
            Assert.AreEqual(i2.FullDescription, look.Execute(p1, new string[] { "look", "at", "gem", "in", "inventory" }));
        }

        [Test]
        public void LookAtGemInBag()
        {
            p1.Inventory.Put(i2);
            Assert.AreEqual(i2.FullDescription, look.Execute(p1, new string[] { "look", "at", "gem", "in", "inventory" }));
        }

        [Test]
        public void LookAtGemInNoBag()
        {
            p1.Inventory.Take("bag");
            Assert.AreEqual("I can't find the bag", look.Execute(p1, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void LookAtNoGemInBag()
        {
            Item gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
            p1.Inventory.Put(b1);
            Assert.AreEqual("I can not find the gem.", look.Execute(p1, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void InvalidLook()
        {
            Assert.AreEqual("I don't know how to look like that.", look.Execute(p1, new string[] { "look", "around" }));
        }
    }
}

