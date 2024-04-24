using System;

namespace SwinAdventure
{
    public class Program
    {
        static void Main(string[] args)
        {
            string name, description;
            Player player;
            Item sword, shield, kunai, armor;
            Bag bag;
            LookCommand look;
            MoveCommand move;
            Location guild, forest, abyss, temple;
            Path path1, path2, path3, path4;

            look = new LookCommand();
            move = new MoveCommand();

            Console.WriteLine("Enter player's name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter player's description:");
            description = Console.ReadLine();

            guild = new Location(new string[] { "guild" }, "Guild", "a strong guild");
            player = new Player(name, description, guild);
            player.Location = guild;

            forest = new Location(new string[] { "forest" }, "Deserted Forest", "a deserted dark forest");
            abyss = new Location(new string[] { "abyss" }, "Dark Abyss", "a shady abyss");
            temple = new Location(new string[] { "temple" }, "Small Temple", "a dark temple with an odd smell");

            path1 = new Path(new string[] { "north" }, "Door", "a black door.", forest);
            path2 = new Path(new string[] { "south" }, "Door", "a blue door.", guild);

            path3 = new Path(new string[] { "east" }, "Door", "a white door.", temple);
            path4 = new Path(new string[] { "west" }, "Door", "a gold door.", abyss);

            guild.AddPath(path1);
            guild.AddPath(path2);
            abyss.AddPath(path3);
            temple.AddPath(path4);

            bag = new Bag(new string[] { "bag" }, "Big Bag", "This is a big, black bag.");
            sword = new Item(new string[] { "sword" }, "Sword", "a gold sword");
            shield = new Item(new string[] { "shield" }, "Shield", "a sharp, platinum shield");
            kunai = new Item(new string[] { "kunai" }, "Kunai", "This is a kunai for safety.");
            armor = new Item(new string[] { "armor" }, "Armor", "an iron armor");

            guild.Inventory.Put(sword);
            forest.Inventory.Put(shield);
            player.Inventory.Put(sword);
            player.Inventory.Put(kunai);
            player.Inventory.Put(shield);
            bag.Inventory.Put(armor);
            player.Inventory.Put(bag);

            Console.WriteLine("Welcome to SwinAdventure!");
            Console.WriteLine("You are in the guild");

            CommandProcessor cp = new CommandProcessor();

            string cmnd = "";
            while (cmnd.ToLower() != "quit")
            {
                Console.Write("Command: ");
                cmnd = Console.ReadLine();
                Console.WriteLine(cp.Execute(player, cmnd.Split(' ')));
            }
        }
    }
}
