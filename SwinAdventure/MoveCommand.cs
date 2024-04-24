using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length == 2 && (text[0] == "move") || (text[0] == "leave") || (text[0] == "go") || (text[0] == "head"))
            {
                return Move(p, p.Location.ReturnPath(text[1]));
            }
            else if (text.Length != 2)
            {
                return "Error in move command";
            }
            else
                return "Error in move input";
        }

        private string Move(Player p, Path path)
        {

            if (path == null)
                return "Path not found.";
            else
            {
                p.Location = path.Final;
                return path.FullDescription;
            }
        }
    }
}

