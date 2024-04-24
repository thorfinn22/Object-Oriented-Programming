using System;
using System.Collections.Generic;
using NUnit.Framework;
using SwinAdventure;

namespace NUnitTest
{
	[TestFixture]
	public class TestLocation 
	{
		private Item item;
		private Player player;
		private Location location;
		private LookCommand look;

		[SetUp]
		public void Setup()
		{
			item = new Item(new string[] { "sword" }, "gold", "a gold sword for you");
			player = new Player("me", "inventory", location);
			location = new Location(new string[] { "Mountain" }, "The Mountain", "A mysterious place");
			look = new LookCommand();
			location.Inventory.Put(item);
			
		}
		[Test]
		public void TestLocationIdentifiesIteself()
		{
			Assert.AreEqual(location.Locate("mountain"), location);
		}

		[Test]
		public void TestLocationLocatesItems()
        {
            
            
                Assert.AreEqual(item, location.Locate("sword"));
            

        }

        [Test]
		public void TestPlayerLOcatesItemsInLocation()
		{
			player.Inventory.Put(item);
			Assert.AreEqual(item, player.Locate("sword"));
		}
	}
}

