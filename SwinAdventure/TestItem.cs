using System;
using System.Collections.Generic;
using NUnit.Framework;
using SwinAdventure;

namespace NUnitTests
{
    [TestFixture]

    public class TestItem
    {
        Item item = new Item(new string[] { "sword" }, "gold", "This is a gold sword for you");

        [Test]
        public void TestItemIsIdentifiable()
        {
            bool real = item.AreYou("sword");
            Assert.IsTrue(real, "Item is identified correctly");
        }

        [Test]
        public void TestShortDescription()
        {
            string exp = item.ShortDescription;
            string real = "a gold (sword)";
           
            Assert.AreEqual(exp, real, "Short description correctly displayed");
        }

        [Test]
        public void TestFullDescription()
        {
            string real = "This is a gold sword for you";
            string exp = item.FullDescription;

            Assert.AreEqual(exp, real, "Full description correctly displayed");
        }
    }
}
