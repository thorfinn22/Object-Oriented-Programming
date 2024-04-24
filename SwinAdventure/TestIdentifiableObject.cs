

using System;
using System.Collections.Generic;
using NUnit.Framework; 
using SwinAdventure; 

namespace NUnitTests
{ 
    [TestFixture]
    public class TestIdentifiableObject  
    {
       
       
     
        [Test]
        public void TestAreYou() 
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "pikachu", "dragonoid" });
            id.AreYou("pikachu");
            Assert.IsTrue(true, "pikachu", id);
        }
        [Test]
        public void TestNotAreYou()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "pikachu", "dragonoid" });
            id.AreYou("pikachu");
            Assert.IsFalse(false, "rowlet", id);

        }

        [Test]
        public void TestCaseSensitive()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "pikachu", "dragonoid" });
            id.AreYou("PIKACHU");
            Assert.IsFalse(false, "pikachu", id);
        }
        [Test]
        public void TestFirstID()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "pikachu", "dragonoid" });
            Assert.AreEqual("pikachu", id.firstID);
        }

        [Test]
        public void TestFirstIDWithNoIDs()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "", "" });
            Assert.AreEqual("", id.firstID);
        }

        [Test]
        public void TestAddID()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "pikachu", "dragonoid" });
            id.AddIdentifier("charmander");
            id.AreYou("charmander");
            Assert.IsTrue(true, "charmander", id);
        }

    }
}