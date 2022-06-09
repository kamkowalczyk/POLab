using System;
using System.Collections.Generic;
using Well_formed_type___Polyline;
using static Well_formed_type___Polyline.Polyline;

namespace CheckPolyline
{
    class Program
    {
        static void Main(string[] args)
        {
            var polylines = new List<Polyline>
            {
                new(),
                new Polyline(new P(1,1)),
                new Polyline( new P(1,1), new P(2,1), new P(3,2)),
                new Polyline(new P(1,2)),
                new Polyline (new P(1,3))

            };

            foreach (var polyline in polylines)
            {
                Console.WriteLine(polyline.ToString());
            }

            var polyLineComparer = new Comparison<Polyline>((pline1, pline2) =>
            {
                if (pline1.Count > pline2.Count) return 1;
                if (pline1.Count < pline2.Count) return -1;

                if (pline1.Length > pline2.Length) return 1;
                if (pline1.Length < pline2.Length) return -1;

                return 0;
            });

            // Sort polyLines
            polylines.Sort(polyLineComparer);
        }
    }
}
