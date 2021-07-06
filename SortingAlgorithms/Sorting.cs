using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms
{
    public class Sorting
    {
        // O(N2)
        // stable
        public static void BubbleSort(int[] array)
        {
            for (int wall = array.Length - 1; wall > 0; wall--)
            {
                for (int i = 0; i < wall; i++)
                {
                    // if (array[i] >= array[i + 1]) => UNSTABLE since duplicate items order in unsaved
                    if (array[i] > array[i + 1])
                        Swap(array, i, i + 1);
                }
            }
        }

        private static void Swap(int[] array, int i, int j)
        {
            if (i == j)
                return;
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
