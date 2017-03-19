using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Shuffling
{
    public static class Shuffleable
    {

        public static void Shuffle<T>(this IList<T> items)
        {
            Shuffle(items, new Random());
        }

        public static void Shuffle<T>(this IList<T> items, Random random)
        {
            int last = items.Count - 1;
            for (int i = 0; i < last; i++)
            {
                int j = random.Next(i, last);

                T temp = items[j];
                items[j] = items[i];
                items[i] = temp;
            }
        }

        public static List<T> ImmutableShuffle<T>(this List<T> items)
        {
            var copy = items.ToList();
            copy.Shuffle();
            return copy;
        }

        public static ImmutableList<T> ImmutableShuffle<T>(this ImmutableList<T> items)
        {
            var copy = items.ToArray();
            copy.Shuffle();
            return copy.ToImmutableList();
        }

        public static ImmutableArray<T> ImmutableShuffle<T>(this ImmutableArray<T> items)
        {
            var copy = items.ToArray();
            copy.Shuffle();
            return copy.ToImmutableArray();
        }
    }
}
