using System;
using System.Collections.Generic;
using System.Linq;

namespace StardustDL.Algorithms
{

    public static class RandomExtensions
    {
        public static int Next(this Random rnd)
        {
            return rnd.Next();
        }

        public static bool NextBoolean(this Random rnd)
        {
            return rnd.Next(2) == 1;
        }

        public static int Next(this Random rnd, int maxValue)
        {
            return rnd.Next(maxValue);
        }

        public static int Next(this Random rnd, int minValue, int maxValue)
        {
            return rnd.Next(minValue, maxValue);
        }

        public static void NextBytes(this Random rnd, byte[] buffer)
        {
            rnd.NextBytes(buffer);
        }

        public static double NextDouble(this Random rnd)
        {
            return rnd.NextDouble();
        }

        public static (int, int) NextPoint(this Random rnd)
        {
            return (rnd.Next(), rnd.Next());
        }

        public static (int, int) NextPoint(this Random rnd, int maxValue1, int maxValue2)
        {
            return (rnd.Next(maxValue1), rnd.Next(maxValue2));
        }

        public static (int, int) NextPoint(this Random rnd, int minValue1, int maxValue1, int minValue2, int maxValue2)
        {
            return (rnd.Next(minValue1, maxValue1), rnd.Next(minValue2, maxValue2));
        }

        public static void NextArray(this Random rnd, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next();
            }
        }
        public static void NextArray(this Random rnd, int[] array, int maxValue)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(maxValue);
            }
        }
        public static void NextArray(this Random rnd, int[] array, int minValue, int maxValue)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(minValue, maxValue);
            }
        }

        public static T Choice<T>(this Random rnd, IEnumerable<T> value)
        {
            return value.Take(rnd.Next(value.Count())).First();
        }

        public static T Choice<T>(this Random rnd, ReadOnlySpan<T> value)
        {
            return value[rnd.Next(value.Length)];
        }

        public static T Choice<T>(this Random rnd, T[] value)
        {
            return value[rnd.Next(value.Length)];
        }

        public static T Choice<T>(this Random rnd, IList<T> value)
        {
            return value[rnd.Next(value.Count)];
        }

        public static IEnumerable<T> Shuffle<T>(this Random rnd, IEnumerable<T> value, Func<int> random)
        {
            return value.OrderBy(x => random());
        }

        public static void Shuffle<T>(this Random rnd, Span<T> value, Func<int, int>? randomWithMaximum = null)
        {
            randomWithMaximum = randomWithMaximum ?? (x => rnd.Next(x));
            for (int i = value.Length - 1; i > 0; i--)
            {
                int j = randomWithMaximum(i + 1);
                Utility.Swap(ref value[i], ref value[j]);
            }
        }

        public static void Shuffle<T>(this Random rnd, T[] value, Func<int, int>? randomWithMaximum = null)
        {
            Func<int, int> _randomWithMaximum = randomWithMaximum ?? (x => rnd.Next(x));
            for (int i = value.Length - 1; i > 0; i--)
            {
                int j = _randomWithMaximum(i + 1);
                Utility.Swap(ref value[i], ref value[j]);
            }
        }

        public static void Shuffle<T>(this Random rnd, IList<T> value, Func<int, int>? randomWithMaximum = null)
        {
            Func<int, int> _randomWithMaximum = randomWithMaximum ?? (x => rnd.Next(x));
            for (int i = value.Count - 1; i > 0; i--)
            {
                int j = _randomWithMaximum(i + 1);
                Utility.Swap(value, i, j);
            }
        }
    }
}
