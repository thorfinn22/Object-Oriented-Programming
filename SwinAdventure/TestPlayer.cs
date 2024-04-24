using System;
using System.Collections.Generic;
using NUnit.Framework;
using SwinAdventure;

namespace NUnitTests
{
    [TestFixture]

    public class TestPlayer
    {
        private Item Item;
        private Player player;
        Location location;

        [SetUp]
        public void SetUp()
        {
            Item = new Item(new string[] { "sword" }, "gold", "This is a gold sword for you");
            
            player = new Player("Harry", "You are carrying:\n\ta gold (sword)\n", location);
            player.Inventory.Put(Item);
        }


        [Test]
        public void TestPlayerIsIdentifiable()
        {
            bool playerme = player.AreYou("me");
            Assert.IsTrue(playerme, "Player identified through me");

            bool playerinven = player.AreYou("inventory");

            Assert.IsTrue(playerinven, "Player identified through inventory");
        }

        [Test]
        public void TestPlayerLocatesItem()
        {
            GameObject exp = Item;
            GameObject real = player.Locate(Item.firstID);
            Assert.AreEqual(real, exp, "Player able to locate item victoriously");
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            GameObject exp = player;
            GameObject real = player.Locate("me");
            Assert.AreEqual(real, exp, "Player able to locate itself victoriously");

        }

        [Test] 
        public void TestPlayerLocatesNothing()
        {
            
            GameObject real = player.Locate("pokemon");
            GameObject exp = null;
            Assert.AreEqual(real, exp, "Player able to locate nothing");
        }


        [Test]
        public void TestPlayerFullDescription()
        {  
            string exp = "You are Harry\nYou are in the guild.\nThis is a strong guild.\nIn this place, you can see:\n\ta gold (sword)\n";
            string real = player.FullDescription;
            Assert.AreEqual(exp, real, "Full description correctly displayed");
        }
    }
}

