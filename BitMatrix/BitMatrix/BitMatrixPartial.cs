using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitMatrix
{
    public partial class BitMatrix :  ICloneable
    {
        public object Clone()
        {
            var clone = new BitMatrix(NumberOfRows, NumberOfColumns);

            for (int i = 0; i < data.Count; i++)
            {
                clone.data[i] = data[i];
            }

            return clone;
        }

     
    }
}

