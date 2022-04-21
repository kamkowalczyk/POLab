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
            var xerosStatus = xerox.CopierGetState();
            xerox.CopierStandbyOn();
            scannerStatus = scanner.GetState();
            printerStatus = printer.GetState();
            xerosStatus = xerox.CopierGetState();
            var counter = xerox.Counter;

            IDocument doc1 = new PDFDocument("aaa.pdf");
            xerox.Print(in doc1);

          

            xerox.ScanAndPrint();
            System.Console.WriteLine(printer.PrintCounter);
            System.Console.WriteLine(scanner.ScanCounter);
        }
    }
}
