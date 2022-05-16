using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObject_PlytaCD
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            string writing = Console.ReadLine();
            string[] splittedTimeOfTracks = writing.Trim().Split(",", StringSplitOptions.RemoveEmptyEntries);
            int numberOfTracks = splittedTimeOfTracks.Length;

            var query1 = splittedTimeOfTracks
                .Select(track => track.Split(":"))
                .Select(track => int.Parse(track[0]) * 60 + int.Parse(track[1]))
                .Average(track => track);

            string averageTime = (int)query1 / 60 + ":" + $"{Math.Ceiling(query1 % 60).ToString("00")}";

            var query2 = splittedTimeOfTracks
                .Select(track => track.Split(":"))
                .Select(track => int.Parse(track[0]) * 60 + int.Parse(track[1]))
                .Sum(track => track);

            string sumOfTime = string.Empty;

            if (query2 / 60 >= 60)
            {
                var hours = (int)query2 / 60 / 60;
                sumOfTime = $"{hours}:{(query2 / 60 % 60).ToString("00")}";
            }
            else
                sumOfTime = $"{(query2 / 60)}";

            sumOfTime += $":{(query2 % 60).ToString("00")}";


            Console.WriteLine($"{numberOfTracks} {averageTime} {sumOfTime}");
        }
    }
}