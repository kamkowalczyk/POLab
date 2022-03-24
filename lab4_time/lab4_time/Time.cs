using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_time
{
   public struct Time
    {
        private readonly byte _hours;
        private readonly byte _minutes;
        private readonly byte _secounds;

        public byte Hours
        {
            get => _hours;
            init => _hours = value;
        }
        public byte Minutes
        {
            get => _minutes;
            init => _minutes = value;
        }
        public byte Secounds
        {
            get => _secounds;
            init => _secounds = value;
        }
    }
}
