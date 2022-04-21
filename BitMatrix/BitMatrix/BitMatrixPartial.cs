using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitMatrix
{
    internal class BitMatrixPartial
    {
        public override String ToString()
        {
            return ToString("X ", "  ", Environment.NewLine);
        }

    
        public String ToString(String setString, String unsetString, string newLine)
        {
            return buildToString(setString, unsetString, Environment.NewLine);
        }
        private String buildToString(String setString, String unsetString, String lineSeparator)
        {
            var result = new StringBuilder(height * (width + 1));
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    result.Append(this[x, y] ? setString : unsetString);
                }
                result.Append(lineSeparator);
            }
            return result.ToString();
        }
    }
}
