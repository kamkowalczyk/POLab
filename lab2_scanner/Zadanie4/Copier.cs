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
        public int PrintCounter { get; set; }
        public int ScanCounter { get; set; }
        public new int Counter { get; set; }

        private static State state = State.off;
        public State CopierGetState()
        {
            return state;
        }


        public void CopierStandbyOn()
        {
          
            ((IScanner)this).StandbyOn();
            ((IPrinter)this).StandbyOn();
            Counter++;
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
            {
                state = printerState;
            }
            else if (printerState != State.off && scannerState == State.off)
            {
                state = printerState;
            }
            else if (printerState == State.off && scannerState != State.off)
            {
                state = scannerState;
            }
            else
            {
                state = State.on;
            }
        }
        public void Print(in IDocument document)
        {
            if (state == IDevice.State.off) return;

            if (((IPrinter)this).GetState() == State.standby)
                ((IPrinter)this).StandbyOff();
            if (PrintCounter > 0 && PrintCounter % 3 == 0)
            {
                ((IPrinter)this).StandbyOn();
                Thread.Sleep(1000);
                ((IPrinter)this).StandbyOff();
                PrintCounter = 0;
            }
            ((IScanner)this).StandbyOn();
            ((IPrinter)this).Print(in document);
            PrintCounter++;
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType )
        {
            if (state == IDevice.State.off) { document = null; return; }

            if (((IScanner)this).GetState() == State.standby)
                ((IScanner)this).StandbyOff();
            if (ScanCounter > 0 && ScanCounter % 2 == 0)
            {
                ((IScanner)this).StandbyOn();
                Thread.Sleep(1000);
                ((IScanner)this).StandbyOff();
                ScanCounter = 0;
            }
            ((IPrinter)this).StandbyOn();
            ((IScanner)this).Scan(out document, formatType);
             ScanCounter++;
        }

        public void ScanAndPrint()
        {
            if (state == IDevice.State.off) return;
            else if (CopierGetState() == State.standby)
                CopierStandbyOn();
            IDocument doc = null;
            Scan(out doc, IDocument.FormatType.JPG);
            if (doc == null)
                return;
           Print(in doc);

        }
    }
}
