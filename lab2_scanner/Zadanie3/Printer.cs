using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class Printer : BaseDevice, IPrinter
    {
        public int PrintCounter { get; set; }
        public new int Counter { get; set; }
        public void Print(in IDocument document)
        {
            if (state == IDevice.State.off) return;

            var date = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            var name = document.GetFileName();

            PrintCounter++;
            Console.WriteLine($"{date} Print: {name}");
        }
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
    }
}
