using System;
using System.Collections;
using System.Collections.Generic;

namespace Well_formed_type___Polyline
{
    public sealed class Polyline : IEquatable<Polyline> 
    {
        public readonly struct P
        {
            public readonly int X;
            public readonly int Y;

            public P(int x = 0, int y = 0)
            {
                X = x; Y = y;
            }

            public override string ToString() => $"({X},{Y})";
        }
        public List<P> Points { get; }
        public int Count
        {
            get => Points.Count;
        }
        

        public Polyline()
        {
            Points = new List<P>()
            {
                new P(0, 0),
                new P(1, 1)
            };
        }

        public Polyline(params P[] pointsList)
        {
            if (pointsList == null) throw new ArgumentNullException();
            if (pointsList.Length == 0) throw new ArgumentException();

            foreach (var point in pointsList)
            {
                Points.Add(point);
            }
        }

        public override string ToString() => $"{string.Join("--", Points)}";

        public bool Equals(Polyline other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            if (this.Points.Count != other.Points.Count) return false;

            for (int i = 0; i < this.Points.Count - 1; i++)
            {
                if (this.Points[i].X != other.Points[i].X) return false;
                if (this.Points[i].Y != other.Points[i].Y) return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (obj is Polyline) return Equals((Polyline)obj);
            else return false;
        }

        public static bool Equals(Polyline obj1, Polyline obj2)
        {
            if (obj1 is null && obj2 is null) return true;
            if (obj1 is null || obj2 is null) return false;

            return obj1.Equals(obj2);
        }

        public override int GetHashCode() => (Points, this).GetHashCode();

        public static bool operator ==(Polyline p1, Polyline p2) => Equals(p1, p2);
        public static bool operator !=(Polyline p1, Polyline p2) => !(p1 == p2);

        public static Polyline operator +(Polyline p1, Polyline p2)
        {
            var pointsListTemp = new List<P>();
            pointsListTemp.AddRange(p1.Points);

            return new Polyline();
        }

        public float Length
        {
            get
            {
                float length = 0;
                for (int i = 0; i < Count; i++)
                {
                    if (i == Count - 1) break;

                    float distance = (float)Math.Sqrt(Math.Pow(Points[i].X - Points[i + 1].X, 2) + Math.Pow(Points[i].Y - Points[i + 1].Y, 2));
                    length += distance;
                }

                return length;
            }
        }
        public IEnumerator GetEnumerator()
        {
            return Points.GetEnumerator();
        }
        public P this[int index]
        {
            get => Points[index];
        }
        public static explicit operator P[](Polyline polyLine)
        {
            return polyLine.Points.ToArray();
        }
        public static Polyline Parse(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression)) throw new ArgumentNullException();

            var stringArray = expression.Replace("(", "").Replace(")", "").Split("--");
            if (stringArray.Length < 1) throw new ArgumentException();
            var list = new List<P>();
            foreach (var pointsStringArray in stringArray)
            {
                var pointsInString = pointsStringArray.Split(',');
                var point = new P(int.Parse(pointsInString[0]), int.Parse(pointsInString[1]));
                list.Add(point);
            }
            return new Polyline(list.ToArray());
        }


    }
}
