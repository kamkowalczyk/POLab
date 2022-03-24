using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_pudelko
{
    public static class PudelkoCompress
    {
        public static Pudelko Copress(this Pudelko box)
        {
            var volume = Math.Pow((double)box.Objetosc, (1 / 3));
            var param = Convert.ToDecimal(volume);
            return new Pudelko(param, param, param);
        }
    }
}
