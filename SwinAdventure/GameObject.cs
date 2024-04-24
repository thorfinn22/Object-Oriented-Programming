using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class GameObject : IdentifiableObject
    {
        private string _name;
        private string _description;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }
        public string name 
        {
            get
            {
                return _name;
            }
        }

        public virtual string ShortDescription 
        {
            get
            {
                return "a " + _name + " (" + base.firstID + ")";
            }
        }

        virtual public string FullDescription
        {
            get
            {
                return _description;
            }
        }
    }
}

