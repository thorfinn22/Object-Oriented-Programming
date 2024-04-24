using System;


namespace CounterTask
{
    class Program
    {



        public class MainClass
        {
            private static void Printcounters(Counter[] counters)
            {
                foreach (Counter c in counters)
                {
                    Console.WriteLine("{0} is {1}", c.Name, c.Ticks);
                }
            }



            public static void Main(string[] args)
            {
                Counter[] myCounters;
                myCounters = new Counter[3];


                myCounters[0] = new Counter("Counter 1 ");
                myCounters[1] = new Counter("Counter 2 ");
                myCounters[2] = myCounters[0];

                for (int i = 0; i < 9; i++)

                {
                    myCounters[0].Increment();
                }

                for (int i = 0; i < 14; i++)
                {
                    myCounters[1].Increment();

                }

                Printcounters(myCounters);
                myCounters[2].Reset();
                Printcounters(myCounters);

                Console.ReadLine();


            }

        }



    }
}