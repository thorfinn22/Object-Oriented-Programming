using System;
using System.Collections.Generic;


namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory;

        public Bag(string[] idents, string name, string desc) : base(idents, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get { return "In the " + this.name + " you can see:\n" + _inventory.ItemList; }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}