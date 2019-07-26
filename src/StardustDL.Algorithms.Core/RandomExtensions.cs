using System;
using System.Collections.Generic;
using System.Linq;

namespace StardustDL.Algorithms
{

    public static class RandomExtensions
    {
        public static void NextInts(this Random rnd, int[] array)
        {
            for (int i = 0; i < array.Length; i++) array[i] = rnd.Next();
        }

        public static bool NextBoolean(this Random rnd)
        {
            return rnd.Next(2) == 1;
        }

        public static T Choice<T>(this Random rnd, IList<T> value)
        {
            return value[rnd.Next(value.Count)];
        }

        public static void Shuffle<T>(this Random rnd, IList<T> value)
        {
            for (int i = value.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                Utility.Swap(value, i, j);
            }
        }
    }
}
