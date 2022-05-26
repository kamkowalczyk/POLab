using System;

namespace MonitorowanieZawodnikow
{
    public class Location
    {
        public DateTime time;
        public (int x, int y) position;
        public Location(DateTime time, (int x, int y) position)
        {
            this.time = time;
            this.position = position;
        }
    }
}
