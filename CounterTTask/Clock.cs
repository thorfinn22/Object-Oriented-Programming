using System;
namespace CounterTTask
{
    public class Clock
    {
        private Counter _hour;
        private Counter _min;
        private Counter _sec;
      


         public Clock()
         {
            _hour = new Counter("hours");
            _min = new Counter("minutes");
            _sec = new Counter("seconds");

         }
        public void Tick()
        {
            _sec.Increment();
            if (_sec.Ticks >= 60)
            {
                _sec.Reset();
                _min.Increment();


                if (_min.Ticks >= 60)
                {
                    _min.Reset();
                    _hour.Increment();


                    if (_hour.Ticks >= 24)
                    {
                        _hour.Reset();
                    }
                }
            }

        }

        public string DisplayClock()
        {
            return (_hour.Ticks.ToString("00") + ":" + _min.Ticks.ToString("00") + ":" + _sec.Ticks.ToString("00") );

        }
        public string Reset()
        {
            _hour.Reset();
            _min.Reset();
            _sec.Reset();
            return DisplayClock();

        }
    }
    
    

}