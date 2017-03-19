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
            if (items == null) { throw new ArgumentNullException("items"); }

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
            return items.ImmutableShuffle(new Random());
        }

        public static List<T> ImmutableShuffle<T>(this List<T> items, Random random)
        {
            if (items == null) { throw new ArgumentNullException("items"); }

            var copy = items.ToList();
            copy.Shuffle(random);
            return copy;
        }

        public static T[] ImmutableShuffle<T>(this T[] items)
        {
            return items.ImmutableShuffle(new Random());
        }

        public static T[] ImmutableShuffle<T>(this T[] items, Random random)
        {
            if (items == null) { throw new ArgumentNullException("items"); }

            var copy = items.ToArray();
            copy.Shuffle(random);
            return copy;
        }

        public static ImmutableList<T> ImmutableShuffle<T>(this ImmutableList<T> items)
        {
            return items.ImmutableShuffle(new Random());
        }

        public static ImmutableList<T> ImmutableShuffle<T>(this ImmutableList<T> items, Random random)
        {
            if (items == null) { throw new ArgumentNullException("items"); }

            var copy = items.ToArray();
            copy.Shuffle(random);
            return copy.ToImmutableList();
        }

        public static ImmutableArray<T> ImmutableShuffle<T>(this ImmutableArray<T> items)
        {
            return items.ImmutableShuffle(new Random());
        }

        public static ImmutableArray<T> ImmutableShuffle<T>(this ImmutableArray<T> items, Random random)
        {
            if (items == null) { throw new ArgumentNullException("items"); }

            var copy = items.ToArray();
            copy.Shuffle(random);
            return copy.ToImmutableArray();
        }
    }
}
