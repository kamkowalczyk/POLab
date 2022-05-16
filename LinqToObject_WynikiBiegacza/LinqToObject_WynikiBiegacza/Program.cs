using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObject_WynikiBiegacza
{
    class Program
    {

        static void Main(string[] args)
        {
            string testCase = Console.ReadLine();
            string data = Console.ReadLine();

            var x2 = extract(data);
            switch (testCase)
            {
                case "test1":
                    Console.WriteLine(data.Split(",").Count());
                    break;
                case "test2":
                    string wynik = string.Join(" ", x2.Select(x => x.Item2));
                    Console.WriteLine(wynik);
                    break;
                case "test3":
                    var x3 = x2.Min(q => q.Item2);
                    var x4 = x2.Where(x => x.Item2 == x3).Select(x => x.Item1);

                    var list = string.Join(" ", x4);
                    Console.WriteLine($"{x3} {list}");
                    break;
                case "test4":
                    var x5 = x2.Max(q => q.Item2);
                    var x6 = x2.Where(x => x.Item2 == x5).Select(x => x.Item1);

                    var lista = string.Join(" ", x6);
                    Console.WriteLine($"{x5} {lista}");
                    break;
                case "test5":
                    var x7 = x2.Select(q => q.Item2.Split(":"))
                        .Select(q => int.Parse(q[0]) * 60 + int.Parse(q[1]))
                        .Average(q => q);

                    var ceil = $"{(int)x7 / 60:D2}";
                    var ceil2 = $"{Math.Ceiling(x7 % 60).ToString():D2}";

                    Console.WriteLine($"{ceil}:{ceil2}");
                    break;
            }
        }

        private static List<Tuple<int, string>> extract(string data)
        {
            var x = data
                .Split(",")
                .Select(q => q.Split(":"))
                .Select(q =>
                    int.Parse(q[0]) * 60 + int.Parse(q[1]))
                .Reverse().ToList();

            var x2 = new List<Tuple<int, string>>();
            int licznik = x.Count;
            for (int i = 0; i < x.Count(); i++)
            {

                if (i != x.Count - 1)
                    x[i] -= x[i + 1];

                x2.Add(new Tuple<int, string>(licznik--, $"{x[i] / 60:d2}:{x[i] % 60:d2}"));
            }

            x2.Reverse();
            return x2;
        }
    }
}