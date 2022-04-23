using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Zadanie4.IDevice;

namespace Zadanie4
{
    public class Copier : IPrinter, IScanner
    {
    
        private int ScanLimit = 0;

       
        private int PrintLimit = 0;

     
        public int CopierCounter { get { return ((IDevice)this).Counter; } }

       
        private static State State = State.off;

       
        public State GetCopierState()
        {
            return State;
        }

        
        public void CopierStandbyOn()
        {
            ((IScanner)this).StandbyOn();
            ((IPrinter)this).StandbyOn();
        }

       
        public void CopierStandbyOff()
        {
            ((IScanner)this).StandbyOff();
            ((IPrinter)this).StandbyOff();
        }
       
        void IDevice.SetState(State state)
        {
            var printerState = ((IPrinter)this).GetState();
            var scannerState = ((IScanner)this).GetState();
            if (printerState == scannerState)
                State = printerState;
            else if (printerState != State.off && scannerState == State.off)
                State = printerState;
            else if (printerState == State.off && scannerState != State.off)
                State = scannerState;
            else
                State = State.on;
        }

      
        public void CopierScan(IDocument document)
        {
            if (((IScanner)this).GetState() == State.off)
                return;
            if (((IScanner)this).GetState() == State.standby)
                ((IScanner)this).StandbyOff();
            if (ScanLimit % 2 == 0)
            {
                ((IScanner)this).StandbyOn();
                Thread.Sleep(1000);
                ((IScanner)this).StandbyOff();
                ScanLimit = 0;
            }
            ((IPrinter)this).StandbyOn();
            ((IScanner)this).Scan(out document);
            ScanLimit++;
        }

      
        public void CopierScan(out IDocument document, IDocument.FormatType formatType)
        {
            document = null;
            if (((IScanner)this).GetState() == State.off)
                return;
            if (((IScanner)this).GetState() == State.standby)
                ((IScanner)this).StandbyOff();
            if (ScanLimit > 0 && ScanLimit % 2 == 0)
            {
                ((IScanner)this).StandbyOn();
                Thread.Sleep(1000);
                ((IScanner)this).StandbyOff();
                ScanLimit = 0;
            }
            ((IPrinter)this).StandbyOn();
            ((IScanner)this).Scan(out document, formatType);
            ScanLimit++;
        }

       
        public void CopierPrint(in IDocument document)
        {
            if (((IPrinter)this).GetState() == State.off)
                return;
            if (((IPrinter)this).GetState() == State.standby)
                ((IPrinter)this).StandbyOff();
            if (PrintLimit > 0 && PrintLimit % 3 == 0)
            {
                ((IPrinter)this).StandbyOn();
                Thread.Sleep(1000);
                ((IPrinter)this).StandbyOff();
                PrintLimit = 0;
            }
            ((IScanner)this).StandbyOn();
            ((IPrinter)this).Print(in document);
           PrintLimit++;
        }

      
        public void ScanAndPrint()
        {
            if (GetCopierState() == State.off)
                return;
            else if (GetCopierState() == State.standby)
                CopierStandbyOn();
            IDocument doc = null;
            CopierScan(out doc, IDocument.FormatType.JPG);
            if (doc == null)
                return;
            CopierPrint(in doc);
        }



    }
}

