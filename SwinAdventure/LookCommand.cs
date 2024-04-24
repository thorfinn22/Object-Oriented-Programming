using System;
using System.Collections.Generic;


namespace SwinAdventure
{
    public class LookCommand : Command
    {

        public LookCommand() : base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {

            if (text.Length == 3 || text.Length == 5)
            {
                if (text[0].ToLower() != "look")
                {
                    return "Error in look input";
                }
                if (text[1].ToLower() != "at")
                {
                    return "What do you want to look at?";
                }
                if (text.Length == 5 && text[3].ToLower() != "in")
                {
                    return "What do you want to look in?";
                }
                if (text.Length == 3 && text[0].ToLower() == "look" && text[1].ToLower() == "at")
                {
                    return LookAtIn(text[2], p as IHaveInventory);
                }
                if (text.Length == 5 && text[0].ToLower() == "look" && text[1].ToLower() == "at" && text[3].ToLower() == "in")
                {
                    IHaveInventory container = FetchContainer(p, text[4]);
                    if (container == null)
                        return "I can't find the " + text[4];
                    else
                        return LookAtIn(text[2], container);
                }
            }
            else if (text.Length == 1 && text[0].ToLower() == "look")
            {
                return p.FullDescription;
            }
            else if (p.AreYou(text[0].ToLower()))
            {
                return LookAtIn(text[0], p as IHaveInventory);
            }
            else
            {
                return "I don't know how to look like that.";
            }
            return "Error: Unknown command";
        }

        private IHaveInventory FetchContainer(Player p, string containerid)
        {
            return p.Locate(containerid) as IHaveInventory;
        }

        private string LookAtIn(string thingID, IHaveInventory container)
        {
            if (container.Locate(thingID) != null)
            {
                return container.Locate(thingID).FullDescription;
            }
            else { return "I can not find the " + thingID + "."; }
        }

    }
}


