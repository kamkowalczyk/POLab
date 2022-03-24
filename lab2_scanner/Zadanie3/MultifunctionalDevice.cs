using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class MultifunctionalDevice : BaseDevice, IFax
    {
        public int PrintCounter { get; set; }
        public int ScanCounter { get; set; }
        public int FaxCounter { get; set; }
        public new int Counter { get; set; }


        public new void PowerOff()
        {
            if (state == IDevice.State.on)
            {
                state = IDevice.State.off;
            }
        }

        public new void PowerOn()
        {
            if (state == IDevice.State.off)
            {
                state = IDevice.State.on;
                Counter++;
            }
        }


        public void Print(in IDocument document)
        {
            if (state == IDevice.State.off) return;

            var date = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            var name = document.GetFileName();

            PrintCounter++;
            Console.WriteLine($"{date} Print: {name}");
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            if (state == IDevice.State.off) { document = null; return; }

            var date = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            document = formatType switch
            {
                IDocument.FormatType.PDF => new PDFDocument($"PDFScan{ScanCounter}.pdf"),
                IDocument.FormatType.JPG => new ImageDocument($"ImageScan{ScanCounter}.jpg"),
                IDocument.FormatType.TXT => new TextDocument($"TextScan{ScanCounter}.txt"),
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(formatType)),
            };

            ScanCounter++;
            Console.WriteLine($"{date} Scan: {document.GetFileName()}");
        }

        public void ScanAndPrint()
        {
            if (state == IDevice.State.off) return;

            IDocument document;
            Scan(out document);
            Print(in document);
        }

        public void SendFax(out IDocument document)
        {
            if (state == IDevice.State.off) { document = null; return; }

            Scan(out document);

            var date = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");

            FaxCounter++;
            Console.WriteLine($"{date} Fax sent: {document.GetFileName()}");
        }

        public void ReceiveFax(in IDocument document)
        {
            if (state == IDevice.State.off) return;

            var date = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");

            FaxCounter++;
            Print(in document);
            Console.WriteLine($"{date} Fax received: {document.GetFileName()}");
        }
    }
}
