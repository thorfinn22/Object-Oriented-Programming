using System;
using NUnit.Framework;
using CounterTest;
using CounterTTask;

namespace CounterTest
{
	[TestFixture]
	public class ClockTest
	{
		[Test]
		public void TestInitialise() 
		{
			Clock clock = new Clock();
            Assert.AreEqual("00:00:00", clock.DisplayClock());

        }

		[Test]
		public void TestTick()
        {
            Clock clock = new Clock();
            for (int i = 0; i < 10; i++)
            {
                clock.Tick();

            }
            Assert.AreEqual("00:00:10", clock.DisplayClock());

        } 
        [Test]
		public void TestTickSeconds() 
		{
			Clock clock = new Clock();

            for (int i = 0; i < 5; i++)
            {
                clock.Tick();

            }
            Assert.AreEqual("00:00:05", clock.DisplayClock());

        }
        [Test]
        public void TestTickMinutes()
        {
            Clock clock = new Clock();

            for (int i = 0; i < 60; i++)
            {
                clock.Tick();

            }
            Assert.AreEqual("00:01:00", clock.DisplayClock());

        }
        [Test]
        public void TestTickHours() 
        {
            Clock clock = new Clock();

            for (int i = 0; i < 3600; i++)
            {
                clock.Tick();

            }
            Assert.AreEqual("01:00:00", clock.DisplayClock());

        }


        [Test]
		public void TestReset()
		{
			Clock clock = new Clock();
			clock.Tick();
			clock.Reset();
            Assert.AreEqual("00:00:00", clock.DisplayClock());
        }
	}
}

