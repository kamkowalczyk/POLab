using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class Scanner : IScanner
    {
        public int Counter { get; set; }
        public IDevice.State state = IDevice.State.off;

        public IDevice.State GetState()
        {
            return state;
        }


        public void PowerOff()
        {
            if (state == IDevice.State.on)
            {
                state = IDevice.State.off;
            }
        }

        public void PowerOn()
        {
            Counter++;
            if (state == IDevice.State.off)
            {
                state = IDevice.State.on;
            }
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            if (state == IDevice.State.off) { document = null; return; }

            var date = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            document = formatType switch
            {
                IDocument.FormatType.PDF => new PDFDocument($"PDFScan{Counter}.pdf"),
                IDocument.FormatType.JPG => new ImageDocument($"ImageScan{Counter}.jpg"),
                IDocument.FormatType.TXT => new TextDocument($"TextScan{Counter}.txt"),
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(formatType)),
            };

            Counter++;
            Console.WriteLine($"{date} Scan: {document.GetFileName()}");
        }
    }
}
