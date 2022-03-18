﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;

namespace Zadanie3
{
    public class Scanner : IScanner
    {
        protected IDevice.State state = IDevice.State.off;

        public int Counter { get; set; }
        public int ScanCounter { get; set; }

        public IDevice.State GetState()
        {
            return state;
        }

        public void PowerOff()
        {
            if (state == IDevice.State.off) return;
            state = IDevice.State.off;
            Console.WriteLine("...Device is off!");
        }

        public void PowerOn()
        {
            if (state == IDevice.State.on) return;
            Counter++;
            state = IDevice.State.on;
            Console.WriteLine("Device is on...!");
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            document = new PDFDocument(filename: null);
            if (state == IDevice.State.off) return;
            ScanCounter++;
            if (formatType == IDocument.FormatType.PDF)
            {
                document = new PDFDocument(filename: "PDFScan" + ScanCounter + ".pdf");
                Console.WriteLine(DateTime.Now + " Scan: " + document.GetFileName());
            }
            else if (formatType == IDocument.FormatType.JPG)
            {
                document = new PDFDocument(filename: "JPGScan" + ScanCounter + ".jpg");
                Console.WriteLine(DateTime.Now + " Scan: " + document.GetFileName());
            }
            else if (formatType == IDocument.FormatType.TXT)
            {
                document = new PDFDocument(filename: "TXTScan" + ScanCounter + ".txt");
                Console.WriteLine(DateTime.Now + " Scan: " + document.GetFileName());
            }
        }
    }
}
