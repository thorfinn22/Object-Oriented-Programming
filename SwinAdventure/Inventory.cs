using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();


        public bool HasItem(string id)
        {
            return Fetch(id) != null;
        }

        public void Put(Item item)
        {
            _items.Add(item);
        }

        public Item Take(string id)
        {
            Item item = Fetch(id);
            if (item != null)
            {
                _items.Remove(item);
            }
            return item;
        }

        public Item Fetch(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string message = "";
                foreach (Item item in _items)
                {
                    message += "\t" + item.ShortDescription + "\n";
                }
                return message;
            }
        }
    }
}
