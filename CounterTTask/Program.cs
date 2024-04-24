using System;

namespace CounterTTask 
{
    public class MainClass 

    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            for (int i = 0; i < 86400; i++)
            {
                clock.Tick();
                Console.WriteLine(clock.DisplayClock());
                
            }
            Console.ReadLine();
        }

        
    }
}