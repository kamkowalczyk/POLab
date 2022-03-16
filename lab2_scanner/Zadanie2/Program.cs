using System;

namespace Zadanie2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MultifunctionalDevice fax = new MultifunctionalDevice();

            string tekst = Console.ReadLine();

            fax.faxes.Add(tekst);

            fax.GetFax();
        }
    }
}
