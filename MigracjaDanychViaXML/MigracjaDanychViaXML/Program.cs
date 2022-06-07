using System;

namespace MigracjaDanychViaXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\Kamil\\OneDrive\\Pulpit\\Zajęcia_rok2.1\\POLab\\MigracjaDanychViaXML\\MigracjaDanychViaXML\\issues.xml";
            ExportImport ei = new ExportImport(path);
            Console.WriteLine("Save complete");
            Console.ReadKey();
        }
    }
}
