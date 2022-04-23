using System;
using System.IO;
using TempElementsLib.src.Classes;

namespace TempElementsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
           Program.Zadanie1CheckUsing();

            Program.CheckWithTryAndCatch();
             TestTempTxtFile();
            TestTempDir();
            TestTempElementsList();
        }
   
        static void Zadanie1CheckUsing()
        {

            Program.DisplayBeginTestLine("Zad 1Check using");

            using (TempFile file = new TempFile())
            {
                Console.WriteLine("Sprawdz czy plik się utworzył");
                Console.ReadLine();
                Console.WriteLine("Sprawdz czy dane wpisały się do pliku");

                file.AddText("[1]");

                Console.ReadLine();
                Console.WriteLine("W tym momencie plik powinien się usunąć..");

            }

            Program.DisplayEndTestLine();

        }



        static void CheckWithTryAndCatch()
        {
            Program.DisplayBeginTestLine("Zadanie 1 Check try and catch");

            TempFile file = new TempFile();
            try
            {
                Console.WriteLine("Dodawanie tekstu do pliku, sprawdz czy tekst sie dodał");
                file.AddText("TEST");
                Console.ReadLine();
                Console.WriteLine("Usuwanie pliku, a nastepnie próba dodania tekstu do pliku");
                file.Dispose();

                file.AddText("Ten tekst nie zostanie dodany");

            }
            catch (ObjectDisposedException e)
            {
                Console.WriteLine($"{e} Plik został już usunięty, nie można wpisać danych do pliku.");
            }

            Program.DisplayEndTestLine();

        }

        static void DisplayBeginTestLine(string testName)
        {
            Console.WriteLine($"-- {testName} --");
        }

        static void DisplayEndTestLine()
        {
            Console.Write("-- ** --");
        }
        static void TestTempTxtFile()
        {
            Program.DisplayBeginTestLine("Zadanie 2 - TempTxtFile");

            using (TempTxtFile file = new TempTxtFile())
            {
                file.Write("Test");
                file.WriteLine("Test2");
                Console.WriteLine("Sprawdz czy dane wpisały się do pliku");

                Console.ReadLine();

                Console.WriteLine("W tym momencie plik powinien się usunąć..");

                Program.DisplayEndTestLine();
            }

        }
        static void TestTempDir()
        {
            Program.DisplayBeginTestLine("Zadadanie 3 - TempDir");
            using (TempDir dir = new TempDir())
            {
                Console.WriteLine("Sprawdź, czy katalog został utworzony.");
                Console.ReadLine();

                Console.WriteLine("Sprawdź, czy katalog został usunięty.");
                dir.Dispose();
            }
            Program.DisplayEndTestLine();
        }
        public static void TestTempElementsList()
        {
            Program.DisplayBeginTestLine("Zadadanie 4 - kolekcja elementów tymczasowych");
            TempElementsList list = new TempElementsList();

            Console.WriteLine("Dodawanie elementów: ");
            TempTxtFile tempTxtFile = list.AddElement<TempTxtFile>();
            tempTxtFile.AddText("TEST1");
            tempTxtFile.AddText("TEST2");

            TempTxtFile tempTxtFile2 = list.AddElement<TempTxtFile>();
            tempTxtFile2.AddText("TEST3");

            Console.WriteLine("Sprawdź, czy elementy zostały utworzone");
            Console.ReadLine();

            Console.WriteLine("Sprawdź, czy plik został przeniesiony");
            list.MoveElementTo(tempTxtFile, Path.GetTempPath() + "copied.txt");
            list.Dispose();
            Console.ReadLine();
        }
    }
}

