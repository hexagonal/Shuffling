using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shuffling.Tests
{
    [TestClass]
    public class ShufflingTests
    {
        private class RandomAlwaysMax : Random
        {
            public override int Next(int minValue, int maxValue)
            {
                return maxValue;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShuffleNull()
        {
            Shuffleable.Shuffle<int>(null);
        }

        [TestMethod]
        public void ShuffleEmptyList()
        {
            var input = new List<int>();
            var output = input.ToList();

            input.Shuffle();

            CollectionAssert.AreEqual(input, output);
        }

        [TestMethod]
        public void ShuffleListWithOneItem()
        {
            var input = new List<int> { 42 };
            var output = input.ToList();

            input.Shuffle();

            CollectionAssert.AreEqual(input, output);
        }

        [TestMethod]
        public void ShuffleListWithThreeItems()
        {
            var random = new RandomAlwaysMax();
            var input = new List<int> { 1, 2, 3 };
            // 123 start
            // 321 (swap input[1] with last)
            // 312 (swap input[2] with last)
            var output = new List<int> { 3, 1, 2 };

            input.Shuffle(random);
            CollectionAssert.AreEqual(input, output);
        }
    }
}
