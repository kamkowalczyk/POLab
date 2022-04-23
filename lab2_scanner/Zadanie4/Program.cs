using System;

namespace Zadanie4
{
     class Program
    {
        static void Main()
        {
            var xerox = new Copier();
            IScanner scanner = xerox;
            IPrinter printer = xerox;
            scanner.PowerOn();
            printer.PowerOn();
            scanner.StandbyOn();
            var scannerStatus = scanner.GetState();
            var printerStatus = printer.GetState();
            var xerosStatus = xerox.GetCopierState();
            xerox.CopierStandbyOn();
            scannerStatus = scanner.GetState();
            printerStatus = printer.GetState();
            xerosStatus = xerox.GetCopierState();
            var counter = xerox.CopierCounter;

            IDocument doc1 = new PDFDocument("aaa.pdf");
            xerox.CopierPrint(in doc1);

          

            xerox.ScanAndPrint();
            System.Console.WriteLine(printer._PrintCounter);
            System.Console.WriteLine(scanner._ScanCounter);
        }
    }
}
