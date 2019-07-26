using System;
using System.Collections.Generic;

namespace StardustDL.Algorithms
{
    public static class Utility
    {
        public static void Swap<T>(ref T a, ref T b)// where T:class
        {
            T t = a; a = b; b = t;
            //b = System.Threading.Interlocked.Exchange(ref a, b);
        }

        public static void Swap<T>(IList<T> list, int a, int b)
        {
            T t = list[a]; list[a] = list[b]; list[b] = t;
        }

        public static void Swap<TKey, TValue>(IDictionary<TKey, TValue> dict, TKey a, TKey b) where TKey : notnull
        {
            TValue t = dict[a]; dict[a] = dict[b]; dict[b] = t;
        }
    }
}
