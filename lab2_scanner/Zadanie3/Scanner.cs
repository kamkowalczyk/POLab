using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class Scanner :BaseDevice, IScanner
    { 
        public int ScanCounter { get; set; }

        public new int Counter { get; set; }

        public new void PowerOn()
        {
            if (state == IDevice.State.off)
            {
                state = IDevice.State.on;
                Counter++;
            }
        }

        public new void PowerOff()
        {
            if (state == IDevice.State.on)
            {
                state = IDevice.State.off;
            }

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
    }
}
