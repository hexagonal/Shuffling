using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Shuffling.Tests
{
    [TestClass]
    public class ShufflingTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShuffleNullList()
        {
            Shuffleable.Shuffle(null as List<int>);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ImmutableShuffleNullArray()
        {
            Shuffleable.ImmutableShuffle(null as int[]);
        }

        [TestMethod]
        public void ShuffleEmptyList()
        {
            var input = new List<int>();
            var expected = input.ToList();

            input.Shuffle();
            var output = input;

            CollectionAssert.AreEqual(output, expected);
        }

        [TestMethod]
        public void ImmutableShuffleEmptyList()
        {
            var input = new List<int>();
            var expected = input.ToList();

            var output = input.ImmutableShuffle();
            Assert.AreNotEqual(input, output);

            CollectionAssert.AreEqual(output, expected);
        }

        [TestMethod]
        public void ShuffleListWithOneItem()
        {
            var input = new List<int> { 42 };
            var expected = input.ToList();

            input.Shuffle();
            var output = input;

            CollectionAssert.AreEqual(output, expected);
        }

        [TestMethod]
        public void ImmutableShuffleImmutableListWithOneItem()
        {
            var input = ImmutableList.Create(42);
            var expected = input.ToImmutableList();

            var output = input.ImmutableShuffle();
            Assert.AreNotEqual(input, output);

            CollectionAssert.AreEqual(output, expected);
        }

        [TestMethod]
        public void ShuffleListWithThreeItems()
        {
            var input = new List<int> { 1, 2, 3 };

            input.Shuffle(new RandomAlwaysMax());
            var output = input;

            // 123 start
            // 321 (swap input[0] with input[2])
            // 312 (swap input[1] with input[2])
            // skip swapping input[2] with itself
            var expected = new List<int> { 3, 1, 2 };
            CollectionAssert.AreEqual(output, expected);
        }

        [TestMethod]
        public void ImmutableShuffleImmutableArrayWithThreeItems()
        {
            var input = ImmutableArray.Create(1, 2, 3);

            var output = input.ImmutableShuffle(new RandomAlwaysMax());
            Assert.AreNotEqual(input, output);

            var expected  = ImmutableArray.Create(3,1,2);
            CollectionAssert.AreEqual(output, expected);
        }

        private class RandomAlwaysMax : Random
        {
            public override int Next(int minValue, int maxValue)
            {
                return maxValue;
            }
        }
    }
}
