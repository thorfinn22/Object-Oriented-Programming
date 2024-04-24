using System;
using System.Collections.Generic;

namespace SwinAdventure
{
	public class Location : GameObject, IHaveInventory
    { 

        private Inventory _inventory;
        private List<Path> _path;
	
        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
            _path = new List<Path>();
        }

        public GameObject Locate(string id)
        {
            if(AreYou(id))
            { return this; }
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            return null;
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public override string FullDescription
        {
            get { return ("This is " + base.FullDescription + pathList + ".\nIn this place, you can see:"); }
        }

        public void AddPath(Path path)
        {
            _path.Add(path);
        }

        public Path ReturnPath(string id)
        {
            foreach (Path path in _path)
                if (path.AreYou(id))
                    return path;
            return null;
        }
        public string pathList
        {
            get
            {
                string list = string.Empty + "\r\n";
                if(_path.Count == 0)
                {
                    return "\nThere are no exits here. You are trapped. Type quit to leave";

                }
                else if (_path.Count == 1)
                {
                    return "\nThere is an exit " + _path[0].firstID + ".\r\n";
                }

                list = list + "There are exits to the ";

                for (int i = 0; i < _path.Count; i++)
                {

                    if (i == _path.Count - 1)
                    {
                        list = list + "and " + _path[i].firstID + ".\r\n";
                    }
                    else
                    {
                        list = list + _path[i].firstID + ", ";
                    }
                }
                return list;
            }
        }
    }
}

