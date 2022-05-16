using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObject_FrekwencjaZnakow
{
    internal class Program
    {
        public static void Main()
        {
            var petla = int.Parse(Console.ReadLine());
            for (int i = 0; i < petla; i++)
            {
                var input = Console.ReadLine(); 

                var queryFormat = Console.ReadLine(); 
                var querySplitted = queryFormat.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var kolejnosc = querySplitted[0] == nameof(Program.kolejnosc.first) ? 1 : 2;
                var n = querySplitted[1];
                var czestosc1 = querySplitted[2] == nameof(Program.czestosc.byfreq) ? 1 : 2;
                var czestoscSort = querySplitted[3] == nameof(Program.sortowanie.asc) ? 1 : 2;
                var czestosc2 = 0;
                var czestosc2Sort = 0;

                if (querySplitted.Length > 4)
                {
                    czestosc2 = querySplitted[4] == nameof(Program.czestosc.byfreq) ? 1 : 2;
                    czestosc2Sort = querySplitted[5] == nameof(Program.sortowanie.asc) ? 1 : 2;
                }

                var query1 = input
                    .Where(q => char.IsLetter(q))
                    .Select(q => char.ToLower(q))
                    .ToList().GroupBy(c => c)
                    .Select(group => new
                    {
                        litera = group.Key,
                        licznik = group.Count()
                    }).OrderBy(q => q.litera);

                var wynik = query1;


                if (czestosc1 == 1)
                {
                    switch (czestoscSort)
                    {
                        case 1:
                            wynik = wynik.OrderBy(q => q.licznik);
                            break;
                        case 2:
                            wynik = wynik.OrderByDescending(q => q.licznik);
                            break;
                    }
                }

                if (czestosc1 == 2)
                {
                    switch (czestoscSort)
                    {
                        case 1:
                            wynik = wynik.OrderBy(q => q.litera);
                            break;
                        case 2:
                            wynik = wynik.OrderByDescending(q => q.litera);
                            break;
                    }
                }

                if (czestosc2 == 1)
                {
                    switch (czestosc2Sort)
                    {
                        case 1:
                            wynik = wynik.ThenBy(q => q.licznik);
                            break;
                        case 2:
                            wynik = wynik.ThenByDescending(q => q.licznik);
                            break;
                    }
                }

                if (czestosc2 == 2)
                {
                    switch (czestosc2Sort)
                    {
                        case 1:
                            wynik = wynik.ThenBy(q => q.litera);
                            break;
                        case 2:
                            wynik = wynik.ThenByDescending(q => q.litera);
                            break;
                    }
                }

                if (kolejnosc == 1)
                {
                    foreach (var q in wynik.Take(int.Parse(n)))
                        Console.WriteLine(q.litera + " " + q.licznik);
                }

                if (kolejnosc == 2)
                {
                    foreach (var q in wynik.TakeLast(int.Parse(n)))
                        Console.WriteLine(q.litera + " " + q.licznik);
                }
                Console.WriteLine();
            }

        }

        public enum kolejnosc
        {
            first = 1, last = 2
        }

        public enum czestosc
        {
            byfreq = 1, byletter = 2
        }

        public enum sortowanie
        {
            asc = 1, desc = 2
        }
    }
}