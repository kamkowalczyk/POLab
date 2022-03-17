using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;

namespace Zadanie3
{
    public class Scanner : IScanner
    {
        public int Counter => throw new NotImplementedException();

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
            throw new NotImplementedException();
        }
    }
}
