using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitMatrix
{
    public partial class BitMatrix : IEquatable<BitMatrix>
    {
        public override bool Equals(object? obj)
        {
            return Equals(obj as BitMatrix);
        }

        public bool Equals(BitMatrix other)
        {
            if (other == null) return false;
            if (this.NumberOfColumns != other.NumberOfColumns || this.NumberOfRows != other.NumberOfRows)
            {
                return false;
            }

            if (this.data.Count != other.data.Count)
            {
                return false;
            }

            for (int i = 0; i < this.data.Count; i++)
            {
                if (this.data[i] != other.data[i]) return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.data.GetHashCode();
        }

        public static bool operator ==(BitMatrix bitM1, BitMatrix bitM2)
        {
            if (((object)bitM1) == null || ((object)bitM2) == null)
                return Object.Equals(bitM1, bitM2);

            return bitM1.Equals(bitM2);
        }
        public static bool operator !=(BitMatrix bitM1, BitMatrix bitM2)
        {
            if (((object)bitM1) == null || ((object)bitM2) == null)
                return !Object.Equals(bitM1, bitM2);

            return !(bitM1.Equals(bitM2));
        }

    }
}

