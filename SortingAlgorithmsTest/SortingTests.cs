using NUnit.Framework;
using SortingAlgorithms;
using System;

namespace AlgorithmsTest
{
    [TestFixture]
    public class SortingTests
    {
        private int[][] Samples()
        {
            return new int[9][]
            {
                new[] { 1 },
                new[] { 2, 1 },
                new[] { 2, 1, 3 },
                new[] { 2, -1, 3, 3 },
                new[] { 4, -5, 3, 3 },
                new[] { 0, -5, 3, 4 },
                new[] { 0, -5, 6, 0 },
                new[] { 1, 1, 5, -6 },
                new[] { 1, 6, 4, 2, 8, 4, 7, 3, 5 },
            };
        }

        private void RunSortTest(Action<int[]> sort)
        {
            foreach (var sample in Samples())
            {
                sort(sample);
                CollectionAssert.IsOrdered(sample);
                PrintOutResult(sample);
            }
        }

        private void PrintOutResult(int[] sample)
        {
            TestContext.WriteLine("--------TRACE-----------");
            foreach (var el in sample)
            {
                TestContext.Write(el + " ");
            }
            TestContext.WriteLine("\n--------------------------\n");
        }

        [Test]
        public void BubbleSort_ValidInput_SortedInput()
        {
            RunSortTest(Sorting.BubbleSort);
        }

        [Test]
        public void SelectionSort_ValidInput_SortedInput()
        {
            RunSortTest(Sorting.SelectionSort);
        }

        [Test]
        public void InsertionSort_ValidInput_SortedInput()
        {
            RunSortTest(Sorting.InsertionSort);
        }

        [Test]
        public void ShellSort_ValidInput_SortedInput()
        {
            RunSortTest(Sorting.ShellSort);
        }

        [Test]
        public void MergeSort_ValidInput_SortedInput()
        {
            RunSortTest(Sorting.MergeSort);
        }

        [Test]
        public void QuickSort_ValidInput_SortedInput()
        {
            RunSortTest(Sorting.QuickSort);
        }
    }
}
