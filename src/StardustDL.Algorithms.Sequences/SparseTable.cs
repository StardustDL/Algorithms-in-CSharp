using System;
using System.Collections.Generic;

namespace StardustDL.Algorithms.Sequences
{
    public class SparseTable<T>
    {
        private readonly T[,] prepare;
        private readonly IComparer<T> comparer;

        public SparseTable(in T[] values, IComparer<T>? comparer = null)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
            Length = values.Length;
            if (Length == 0)
            {
                prepare = new T[0, 0];
            }
            else
            {
                int maxD = (int)Math.Floor(Math.Log(Length, 2));
                prepare = new T[maxD + 1, Length];
                for (int i = 0; i < Length; i++)
                {
                    prepare[0, i] = values[i];
                }

                for (int d = 1; d <= maxD; d++)
                {
                    for (int i = 0; i + (1 << (d - 1)) < Length; i++)
                    {
                        prepare[d, i] =
                            this.comparer.Min(prepare[d - 1, i], prepare[d - 1, i + (1 << (d - 1))]);
                    }
                }
            }
        }

        public int Length { get; private set; } = 0;

        public T this[Range range]
        {
            get
            {
                (int offset, int length) = range.GetOffsetAndLength(Length);
                if (length == 0)
                {
                    throw new ArgumentException("The range contains no element.", nameof(range));
                }

                int D = (int)Math.Floor(Math.Log(length, 2));
                return comparer.Min(prepare[D, offset], prepare[D, offset + length - (1 << D)]);
            }
        }
    }
}
