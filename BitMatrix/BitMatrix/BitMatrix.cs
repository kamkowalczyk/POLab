using System;
using System.Collections;

namespace BitMatrix
{

    // prostokątna macierz bitów o wymiarach m x n
    public partial class BitMatrix
    {
        private BitArray data;
        public int NumberOfRows { get; }
        public int NumberOfColumns { get; }
        public bool IsReadOnly => false;

        // tworzy prostokątną macierz bitową wypełnioną `defaultValue`
        public BitMatrix(int numberOfRows, int numberOfColumns, int defaultValue = 0)
        {
            if (numberOfRows < 1 || numberOfColumns < 1)
                throw new ArgumentOutOfRangeException("Incorrect size of matrix");
            data = new BitArray(numberOfRows * numberOfColumns, BitToBool(defaultValue));
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
        }

        public static int BoolToBit(bool boolValue) => boolValue ? 1 : 0;
        public static bool BitToBool(int bit) => bit != 0;

        public bool this[int i, int j]
        {
            get => data[(i * NumberOfColumns) + j];
            set => data[(i * NumberOfColumns) + j] = value;
        }

        public override string ToString()
        {
            string wynik = "";

            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    wynik += BoolToBit(data[(i * NumberOfColumns) + j]);
                }
                wynik += Environment.NewLine;
            }

            return wynik;
        }


        //public IEnumerator<bool> GetEnumerator()
        //{
        //    foreach (var wiersz in data)
        //        foreach (bool bit in wiersz)
        //            yield return bit;
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}
        public BitMatrix(int numberOfRows, int numberOfColumns, params int[] bits)
        {
            if (numberOfRows < 1 || numberOfColumns < 1)
                throw new ArgumentOutOfRangeException("Incorrect size of matrix");
            data = new BitArray(numberOfRows * numberOfColumns, BitToBool(0));
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;

            if (bits != null && bits.Length != 0)
            {
                for (int i = 0; i < bits.Length; i++)
                {
                    if (i < data.Length)
                    {
                        data[i] = BitToBool(bits[i]);
                    }
                }
            }
        }
        public BitMatrix(int[,] bits)
        {
            if (bits == null) throw new NullReferenceException();
            if (bits.Length == 0) throw new ArgumentOutOfRangeException();

            data = new BitArray(bits.GetLength(0) * bits.GetLength(1), BitToBool(0));
            NumberOfRows = bits.GetLength(0);
            NumberOfColumns = bits.GetLength(1);

            for (int i = 0; i < bits.GetLength(0); i++)
            {
                for (int j = 0; j < bits.GetLength(1); j++)
                {
                    data[(i * NumberOfColumns) + j] = BitToBool(bits[i, j]);
                }
            }
        }
        public BitMatrix(bool[,] bits)
        {
            if (bits == null) throw new NullReferenceException();
            if (bits.Length == 0) throw new ArgumentOutOfRangeException();

            data = new BitArray(bits.GetLength(0) * bits.GetLength(1), BitToBool(0));
            NumberOfRows = bits.GetLength(0);
            NumberOfColumns = bits.GetLength(1);

            for (int i = 0; i < bits.GetLength(0); i++)
            {
                for (int j = 0; j < bits.GetLength(1); j++)
                {
                    data[(i * NumberOfColumns) + j]= bits[i, j];
                }
            }
        }
    }
}