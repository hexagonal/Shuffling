using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Shuffling
{
    public static class Shuffleable
    {
        /// <summary>Shuffle a list (or array).</summary>
        /// <param name="items">The list (or array).</param>
        public static void Shuffle<T>(this IList<T> items)
        {
            Shuffle(items, new Random());
        }

        /// <summary>Shuffle a list (or array).</summary>
        /// <param name="items">The list (or array).</param>
        /// <param name="random">A random number generator (only used for testing).</param>
        public static void Shuffle<T>(this IList<T> items, Random random)
        {
            if (items == null) { throw new ArgumentNullException(nameof(items)); }

            // last is the index of the last item
            int last = items.Count - 1;

            // Move through all the indexes except for the last one
            for (int i = 0; i < last; i++)
            {
                // Choose j: a random index between i and last
                int j = random.Next(i, last);

                // Swap items[i] and items[j]
                T temp = items[j];
                items[j] = items[i];
                items[i] = temp;
            }
        }

        /// <summary>Get a shuffled copy of a list.</summary>
        /// <param name="items">A list. It is not modified.</param>
        /// <returns>A shuffled list.</returns>
        public static List<T> ImmutableShuffle<T>(this List<T> items)
        {
            return items.ImmutableShuffle(new Random());
        }

        /// <summary>Get a shuffled copy of a list.</summary>
        /// <param name="items">A list. It is not modified.</param>
        /// <param name="random">A random number generator (only used for testing).</param>
        /// <returns>A shuffled list.</returns>
        public static List<T> ImmutableShuffle<T>(this List<T> items, Random random)
        {
            if (items == null) { throw new ArgumentNullException(nameof(items)); }

            var copy = items.ToList();
            copy.Shuffle(random);
            return copy;
        }

        /// <summary>Get a shuffled copy of an array.</summary>
        /// <param name="items">An array. It is not modified.</param>
        /// <returns>A shuffled array.</returns>
        public static T[] ImmutableShuffle<T>(this T[] items)
        {
            return items.ImmutableShuffle(new Random());
        }

        /// <summary>Get a shuffled copy of an array.</summary>
        /// <param name="items">An array. It is not modified.</param>
        /// <param name="random">A random number generator (only used for testing).</param>
        /// <returns>A shuffled array.</returns>
        public static T[] ImmutableShuffle<T>(this T[] items, Random random)
        {
            if (items == null) { throw new ArgumentNullException(nameof(items)); }

            var copy = items.ToArray();
            copy.Shuffle(random);
            return copy;
        }

        /// <summary>Get a shuffled copy of an immutable list.</summary>
        /// <param name="items">An immutable list. It is not modified.</param>
        /// <returns>A shuffled immutable list.</returns>
        public static ImmutableList<T> ImmutableShuffle<T>(this ImmutableList<T> items)
        {
            return items.ImmutableShuffle(new Random());
        }

        /// <summary>Get a shuffled copy of an immutable list.</summary>
        /// <param name="items">An immutable list. It is not modified.</param>
        /// <param name="random">A random number generator (only used for testing).</param>
        /// <returns>A shuffled immutable list.</returns>
        public static ImmutableList<T> ImmutableShuffle<T>(this ImmutableList<T> items, Random random)
        {
            if (items == null) { throw new ArgumentNullException(nameof(items)); }

            var copy = items.ToArray();
            copy.Shuffle(random);
            return copy.ToImmutableList();
        }

        /// <summary>Get a shuffled copy of an immutable array.</summary>
        /// <param name="items">An immutable array. It is not modified.</param>
        /// <returns>A shuffled immutable array.</returns>
        public static ImmutableArray<T> ImmutableShuffle<T>(this ImmutableArray<T> items)
        {
            return items.ImmutableShuffle(new Random());
        }

        /// <summary>Get a shuffled copy of an immutable array.</summary>
        /// <param name="items">An immutable array. It is not modified.</param>
        /// <param name="random">A random number generator (only used for testing).</param>
        /// <returns>A shuffled immutable array.</returns>
        public static ImmutableArray<T> ImmutableShuffle<T>(this ImmutableArray<T> items, Random random)
        {
            if (items == null) { throw new ArgumentNullException(nameof(items)); }

            var copy = items.ToArray();
            copy.Shuffle(random);
            return copy.ToImmutableArray();
        }
    }
}
