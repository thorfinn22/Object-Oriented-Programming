using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;


        public Player(string name, string desc, Location location) : base(new string[] { "me", "inventory" }, name, desc)
        {

            _inventory = new Inventory();
            _location = new Location(new string[] { "guild" }, "guild", "a strong guild");
        }


        public GameObject Locate(string id) 
        {
            if (this.AreYou(id))
            {
                return this;
            }
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            else if (_location.Locate(id) != null)
            {
                return _location.Locate(id);
            }
            return null;
        }

        public override string FullDescription 
        {
            get
            {
                return "You are " + this.name + "\n" + "You are in the " + _location.name + ".\n" + _location.FullDescription + "\n" + _inventory.ItemList;
            }
        }

        public Inventory Inventory 
        {
            get
            {
                return _inventory;
            }
        }
        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
    }
}




