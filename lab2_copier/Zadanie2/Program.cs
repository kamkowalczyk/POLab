using System;


namespace Zadanie2
{
    class Program
    {
        static void Main()
        {
            var xerox = new Copier();
            xerox.PowerOn();
            IDocument doc1 = new PDFDocument("aaa.pdf");
            xerox.Print(in doc1);

            IDocument doc2;
            xerox.Scan(out doc2);

            xerox.ScanAndPrint();
            System.Console.WriteLine(xerox.Counter);
            System.Console.WriteLine(xerox.PrintCounter);
            System.Console.WriteLine(xerox.ScanCounter);
            MultifunctionalDevice fax = new MultifunctionalDevice();
            fax.PowerOn();
            fax.Scan(out doc2);
            System.Console.WriteLine(fax.ScanCounter);

        }
    }
}
