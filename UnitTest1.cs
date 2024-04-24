using NUnit.Framework;
using CounterTest;
using CounterTTask;

namespace CounterTest
{

    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestInitialValue()
        {
            Clock clock = new Clock();
            Assert.AreEqual("00:00:00", clock.DisplayClock());
        }


        [Test]
        public void TestIncrement () 
        {
            Clock clock = new Clock();
            clock.Tick();
            Assert.AreEqual("00:00:01", clock.DisplayClock());
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
        public void TestReset()
        {
            Clock clock = new Clock();
            clock.Tick();
            Assert.AreEqual("00:00:00", clock.Reset());
        }

    }
}
