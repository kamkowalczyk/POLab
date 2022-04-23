using System;

namespace lab4_TimePeriod
{
    class Program
    {
        static void Main(string[] args)
        {
            var expected = new TimePeriod(2, 2, 2);

            TimePeriod timeOne = new TimePeriod(1, 1, 1);
            TimePeriod timeTwo = new TimePeriod(1, 1, 1);


            var actual = timeOne.Plus(timeTwo);
            Console.WriteLine(actual);
        }
    }
}
