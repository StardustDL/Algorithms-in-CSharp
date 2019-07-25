using System;
using System.Collections.Generic;

namespace StardustDL.Algorithms
{
    public static class ComparerExtensions
    {
        private class ComparerBaseEqualityComparer<T> : IEqualityComparer<T>
        {
            private readonly IComparer<T> comparer;
            private readonly Func<T, int> getHashCode;

            public ComparerBaseEqualityComparer(IComparer<T> comparer, Func<T, int> getHashCode)
            {
                this.comparer = comparer;
                this.getHashCode = getHashCode;
            }

            public bool Equals(T x, T y)
            {
                return comparer.Equal(x, y);
            }

            public int GetHashCode(T obj)
            {
                return getHashCode(obj);
            }
        }

        private class InnerReverseComparer<T> : IComparer<T>
        {
            private readonly IComparer<T> comparer;

            public InnerReverseComparer(IComparer<T> comparer)
            {
                this.comparer = comparer;
            }

            public int Compare(T x, T y)
            {
                return -comparer.Compare(x, y);
            }
        }

        public static IComparer<T> ToInverse<T>(this IComparer<T> comparer)
        {
            return new InnerReverseComparer<T>(comparer);
        }

        public static IEqualityComparer<T> ToEqualityComparer<T>(this IComparer<T> comparer, Func<T, int> toHashCode)
        {
            return new ComparerBaseEqualityComparer<T>(comparer, toHashCode);
        }

        public static bool Larger<T>(this IComparer<T> comparer, in T x, in T y)
        {
            return comparer.Compare(x, y) > 0;
        }

        public static bool LargerEqual<T>(this IComparer<T> comparer, in T x, in T y)
        {
            return comparer.Compare(x, y) >= 0;
        }

        public static bool Smaller<T>(this IComparer<T> comparer, in T x, in T y)
        {
            return comparer.Compare(x, y) < 0;
        }

        public static bool SmallerEqual<T>(this IComparer<T> comparer, in T x, in T y)
        {
            return comparer.Compare(x, y) <= 0;
        }

        public static T Min<T>(this IComparer<T> comparer, in T value1, in T value2)
        {
            return comparer.Compare(value1, value2) <= 0 ? value1 : value2;
        }

        public static T Max<T>(this IComparer<T> comparer, in T value1, in T value2)
        {
            return comparer.Compare(value1, value2) <= 0 ? value2 : value1;
        }

        public static bool Equal<T>(this IComparer<T> comparer, in T value1, in T value2)
        {
            return comparer.Compare(value1, value2) == 0;
        }
    }
}
