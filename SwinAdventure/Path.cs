using System;
using System.Collections.Generic;


namespace SwinAdventure
{
    public class Path : GameObject
    {
        private Location _initial = null;
        private Location _final = null;

        public Path(string[] ids, string name, string desc, Location initial, Location final) : base(ids, name, desc)
        {
            _initial = initial;
            _final = final;
        }

        public Location Initial
        {

            get
            {
                return _initial;
            }
            set
            {
                _initial = value;
            }

        }
        public Location Final
        {
            get
            {
                return _final;
            }
            set
            {
                _final = value;
            }
        }
        public override string ShortDescription
        {
            get
            {
                return name;
            }
        }
        public override string FullDescription
        {
            get
            {
                return "You head " + base.firstID + ".\nYou travel through " + base.FullDescription + "\nYou arrived in " + Final.name;
            }
        }
    }
}
