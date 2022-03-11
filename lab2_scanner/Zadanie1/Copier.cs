using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class Copier : IDevice
    {
        public int Counter {get; set;}

        public int PrintCounter { get; set; }
        public int ScanCounter { get; set; }

        public IDevice.State GetState()
        {
            throw new NotImplementedException();
        }

        public void PowerOff()
        {
            throw new NotImplementedException();
        }

        public void PowerOn()
        {
            throw new NotImplementedException();
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            Counter++;
            ScanCounter++;
            document = null;
        }

        public void Print(in IDocument document)
        {
          Counter++;
            ScanCounter++;
        }

        public void ScanAndPrint()
        {
            Counter++;
            ScanCounter++;
            PrintCounter++;
        }

        public void Scan(out IDocument document)
        {
            throw new NotImplementedException();
        }
    }
}
