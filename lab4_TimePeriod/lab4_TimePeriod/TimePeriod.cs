using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_TimePeriod
{
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        private long PeriodOfTime { get; }
        public TimePeriod(byte hours, byte minutes, long seconds)
        {
            if (hours < 0 || minutes < 0 || seconds < 0)
                throw new ArgumentException("Punkt w czasie nie może mieć wartości ujemnej.");

            PeriodOfTime = (hours * 3600) + (minutes * 60) + seconds;
        }
        public TimePeriod(byte hours, byte minutes)
        {
            if (hours < 0 || minutes < 0)
                throw new ArgumentException("Punkt w czasie nie może mieć wartości ujemnej.");

            PeriodOfTime = (hours * 3600) + (minutes * 60);
        }

        public TimePeriod(long seconds)
        {
            if (seconds < 0)
                throw new ArgumentException("Punkt w czasie nie może mieć wartości ujemnej.");

            PeriodOfTime = seconds;
        }
        public TimePeriod(string other)
        {
            string[] times = other.Split(':');
            if (times[0].All(char.IsDigit) && times[1].All(char.IsDigit) && times[2].All(char.IsDigit))
            {
                long hours = long.Parse(times[0]);
                long minutes = long.Parse(times[1]);
                long seconds = long.Parse(times[2]);

                if (minutes >= 60 || seconds >= 60)
                    throw new ArgumentException("Któryś z argumentów ma za dużą wartość.");

                PeriodOfTime = (hours * 3600) + (minutes * 60) + seconds;
            }
            else
                throw new ArgumentException("Nieprawidłowy ciąg znaków.");
        }
        public override string ToString()
        {
            string hoursText, minutesText, secondsText;

            long hours = (PeriodOfTime / 3600);
            long minutes = (PeriodOfTime - (hours * 3600)) / 60;
            long seconds = (PeriodOfTime - ((hours * 3600) + (minutes * 60)));

            if (hours < 10) hoursText = "0" + hours.ToString() + ":";
            else hoursText = hours.ToString() + ":";

            if (minutes < 10) minutesText = "0" + minutes.ToString() + ":";
            else minutesText = minutes.ToString() + ":";

            if (seconds < 10) secondsText = "0" + seconds.ToString();
            else secondsText = seconds.ToString();

            return (hoursText + minutesText + secondsText);
        }
        public TimePeriod Plus(TimePeriod other)
        {
            return new TimePeriod(PeriodOfTime + other.PeriodOfTime);
        }

      
        public static TimePeriod Plus(TimePeriod periodOne, TimePeriod periodTwo)
        {
            return new TimePeriod(periodOne.PeriodOfTime + periodTwo.PeriodOfTime);
        }
        public static bool operator ==(TimePeriod periodOne, TimePeriod periodTwo) => periodOne.Equals(periodTwo);

        public static bool operator !=(TimePeriod periodOne, TimePeriod periodTwo) => !periodOne.Equals(periodTwo);

        public static bool operator <(TimePeriod periodOne, TimePeriod periodTwo) => periodOne.CompareTo(periodTwo) < 0;

        public static bool operator >(TimePeriod periodOne, TimePeriod periodTwo) => periodOne.CompareTo(periodTwo) > 0;

        public static bool operator <=(TimePeriod periodOne, TimePeriod periodTwo) => periodOne.CompareTo(periodTwo) <= 0;

        public static bool operator >=(TimePeriod periodOne, TimePeriod periodTwo) => periodOne.CompareTo(periodTwo) >= 0;

        public static TimePeriod operator +(TimePeriod periodOne, TimePeriod periodTwo)
        {
            return new TimePeriod(periodOne.PeriodOfTime + periodTwo.PeriodOfTime);
        }

        public int CompareTo(TimePeriod other)
        {
            return PeriodOfTime.CompareTo(other.PeriodOfTime);
        }

        public bool Equals(TimePeriod other)
        {
            if (PeriodOfTime == other.PeriodOfTime)
                return true;
            else
                return false;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }
}
