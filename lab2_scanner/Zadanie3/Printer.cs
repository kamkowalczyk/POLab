using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class Printer : IPrinter
    {
        protected IDevice.State state = IDevice.State.off;

        public int Counter { get; set; }

        public int PrintCounter { get; set; }

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

        public void Print(in IDocument document)
        {
            if (state != IDevice.State.off) return;
            PrintCounter++;
            Console.WriteLine(DateTime.Now.ToString() + " Print: " + document.GetFileName());
        }
    }
}
