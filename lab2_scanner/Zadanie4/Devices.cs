using System;


namespace Zadanie4
{
    public interface IDevice
    {
 
        enum State { off, on, standby };

     
        void PowerOn()
        {
            _Counter++;
            SetState(State.on);
        }

   
        void StandbyOn()
        {
            SetState(State.standby);
        }

      
        void StandbyOff()
        {
            _Counter++;
            SetState(State.on);
        }

      
        void PowerOff()
        {
            SetState(State.off);
        }

     
        abstract protected void SetState(State state);

        private static State _State = State.off;

        
        State GetState()
        {
            return _State;
        }

        
        int Counter { get { return _Counter; } }

       
        private static int _Counter = 0;
    }

    /// <summary>
    /// Interfejs drukarki
    /// </summary>
    public interface IPrinter : IDevice
    {
        private static State PrinterState = State.off;

        new public void SetState(State state)
        {
            PrinterState = state;
        }
        int _PrintCounter { get { return PrintCounter; } }


        private static int PrintCounter = 0;

        new State GetState()
        {
            return PrinterState;
        }
        void Print(in IDocument document)
        {
          

            var date = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            var name = document.GetFileName();

            PrintCounter++;
            Console.WriteLine($"{date} Print: {name}");
        }

     

       
        new public void PowerOn()
        {
            SetState(State.on);
            ((IDevice)this).PowerOn();
        }

     
        new void StandbyOn()
        {
            SetState(State.standby);
            ((IDevice)this).StandbyOn();
        }

      
        new void StandbyOff()
        {
            SetState(State.on);
            ((IDevice)this).StandbyOff();
        }

       
        new void PowerOff()
        {
            SetState(State.off);
            ((IDevice)this).PowerOff();
        }

       
      
    }


    public interface IScanner : IDevice
    {
        int _ScanCounter { get { return ScanCounter; } }


        private static int ScanCounter = 0;
        new public void SetState(State state)
        {
            ScannerState = state;
        }
        void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            document = null;
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

      
        void Scan(out IDocument document)
        {
            document = null;
            if (ScannerState == State.off)
                return;
            ScanCounter++;
            Console.WriteLine($"{DateTime.Now} Scan: {ScanCounter++}");
        }

      
     

      
        new public void PowerOn()
        {
            SetState(State.on);
            ((IDevice)this).PowerOn();
        }

      
        new void StandbyOn()
        {
            ScannerState = State.standby;
            ((IDevice)this).StandbyOn();
        }

      
        new void StandbyOff()
        {
            ScannerState = State.on;
            ((IDevice)this).StandbyOff();
        }

    
        new void PowerOff()
        {
            ScannerState = State.off;
            ((IDevice)this).PowerOff();
        }

        private static State ScannerState = State.off;

       
        

        new State GetState()
        {
            return ScannerState;
        }
    }


}
