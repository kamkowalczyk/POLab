using System;


namespace Zadanie4
{
    public interface IDevice
    {
        enum State {on, off, standby};

        void PowerOn() { SetState(State.on); } // uruchamia urządzenie, zmienia stan na `on`
        void PowerOff() { SetState(State.off); } // wyłącza urządzenie, zmienia stan na `off
        void StandbyOn() { SetState(State.standby); }
        void StandbyOff() {SetState(State.on); }
        abstract protected void SetState(State state);
        private static State state = State.off;

        State GetState() { return state;} // zwraca aktualny stan urządzenia

        int Counter {get;}  // zwraca liczbę charakteryzującą eksploatację urządzenia,
                            // np. liczbę uruchomień, liczbę wydrukow, liczbę skanów, ...
    }


    public interface IPrinter : IDevice
    {
        /// <summary>
        /// Dokument jest drukowany, jeśli urządzenie włączone. W przeciwnym przypadku nic się nie wykonuje
        /// </summary>
        /// <param name="document">obiekt typu IDocument, różny od `null`</param>
        int PrintCounter { get { return _PrintCounter; } }

        /// <summary>
        /// Liczba wydrukowanych dokumentów
        /// </summary>
        private static int _PrintCounter = 0;
        void Print(in IDocument document)
        {

            var date = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            var name = document.GetFileName();

            _PrintCounter++;
            Console.WriteLine($"{date} Print: {name}");
        }
        new public void PowerOn()
        {
            SetState(State.on);
            ((IDevice)this).PowerOn();
        }
        new void PowerOff()
        {
            SetState(State.off);
            ((IDevice)this).PowerOff();
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
    }

    public interface IScanner : IDevice
    {
        // dokument jest skanowany, jeśli urządzenie włączone
        // w przeciwnym przypadku nic się dzieje
        int ScanCounter { get { return _ScanCounter; } }

        /// <summary>
        /// Liczba zeskanowanych dokumentów
        /// </summary>
        private static int _ScanCounter = 0;
        void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            var date = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            document = formatType switch
            {
                IDocument.FormatType.PDF => new PDFDocument($"PDFScan{ScanCounter}.pdf"),
                IDocument.FormatType.JPG => new ImageDocument($"ImageScan{ScanCounter}.jpg"),
                IDocument.FormatType.TXT => new TextDocument($"TextScan{ScanCounter}.txt"),
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(formatType)),
            };

            _ScanCounter++;
            Console.WriteLine($"{date} Scan: {document.GetFileName()}");
        }
        new public void PowerOn()
        {
            SetState(State.on);
            ((IDevice)this).PowerOn();
        }
        new void PowerOff()
        {
            SetState(State.off);
            ((IDevice)this).PowerOff();
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
    }

}
