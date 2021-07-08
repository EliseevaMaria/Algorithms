using Algorithms;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsTest
{
    [TestFixture]
    public class SearchingTest
    {
        [Test]
        public void BinarySearch_SortedInput_CorrectInput()
        {
            int[] input = { 1, 3, 4, 7, 8, 16, 22 };

            Assert.AreEqual(-1, Searching.BinarySearch(input, 0));
            Assert.AreEqual(1, Searching.BinarySearch(input, 3));
            Assert.AreEqual(5, Searching.BinarySearch(input, 16));
            Assert.AreEqual(6, Searching.BinarySearch(input, 22));

            Assert.AreEqual(-1, Searching.BinarySearchRecursive(input, 0));
            Assert.AreEqual(1, Searching.BinarySearchRecursive(input, 3));
            Assert.AreEqual(5, Searching.BinarySearchRecursive(input, 16));
            Assert.AreEqual(6, Searching.BinarySearchRecursive(input, 22));
        }
    }
}
