using System;
using NUnit.Framework;
using SwinAdventure;

namespace NUnitTest
{
	[TestFixture]
	public class TestPath
	{
        private Location guild, forest;
        private Player player;
        private Path path1,path2;
        private MoveCommand Move;

		[SetUp]
        public void Setup()
		{
            guild = new Location(new string[] { "guild" }, "Guild", "a strong guild");
            forest = new Location(new string[] { "forest" }, "Deserted Forest", "a deserted dark forest");
            player = new Player("Harry", "ninja", guild);
            path1 = new Path(new string[] { "north" }, "Door", "a black door.", forest);

            Move = new MoveCommand();
            player.Location = guild;
           guild.AddPath(path1);
        }
	}
}

