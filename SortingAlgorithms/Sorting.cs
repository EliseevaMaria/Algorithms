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
            for (int wallIndex = array.Length - 1; wallIndex > 0; wallIndex--)
            {
                for (int i = 0; i < wallIndex; i++)
                {
                    // if (array[i] >= array[i + 1]) => UNSTABLE since duplicate items order in unsaved
                    if (array[i] > array[i + 1])
                        Swap(array, i, i + 1);
                }
            }
        }

        // O(N2)
        // unstable
        public static void SelectionSort(int[] array)
        {
            for (int wallIndex = array.Length - 1; wallIndex > 0; wallIndex--)
            {
                int largestAt = 0;
                for (int i = 1; i <= wallIndex; i++)
                {
                    if (array[i] > array[largestAt])
                        largestAt = i;
                }
                Swap(array, largestAt, wallIndex);
            }
        }

        // O(N2)
        // stable
        public static void InsertionSort(int[] array)
        {
            for (int wallIndex = 1; wallIndex < array.Length; wallIndex++)
            {
                int unsorted = array[wallIndex];
                int i;
                for (i = wallIndex; i > 0 && array[i - 1] > unsorted; i--)
                {
                    array[i] = array[i - 1];
                }
                array[i] = unsorted;
            }
        }

        // O(x) depends on the gap calculation, worst case scenario is O(N3), best is around O(N^(6/5))
        // unstable
        public static void ShellSort(int[] array)
        {
            int gap = 1;
            while (gap < array.Length / 3)
            {
                gap = 3 * gap + 1;
            }

            while (gap >= 1)
            {
                for (int i = gap; i < array.Length; i++)
                {
                    for (int j = i; j >= gap && array[j] < array[j - gap]; j -= gap)
                    {
                        Swap(array, j, j - gap);
                    }
                }

                gap /= 3;
            }
        }

        // O(NlogN)
        // stable in a classic implementation
        public static void MergeSort(int[] array)
        {
            int[] aux = new int[array.Length];
            sort(0, array.Length - 1);

            void sort(int low, int high)
            {
                if (high <= low)
                    return;
                
                int mid = (high + low) / 2;
                sort(low, mid);
                sort(mid + 1, high);
                merge(low, mid, high);
            }

            void merge(int low, int mid, int high)
            {
                // improved: if first right number is bigger than last left, both arrays are sorted
                if (array[mid] <= array[mid + 1])
                    return;

                int left = low;
                int right = mid + 1;

                Array.Copy(array, low, aux, low, high - low + 1);

                for (int k = low; k <= high; k++)
                {
                    if (left > mid)
                        array[k] = aux[right++];
                    else if (right > high)
                        array[k] = aux[left++];
                    else if (aux[right] < aux[left])
                        array[k] = aux[right++];
                    else
                        array[k] = aux[left++];
                }
            }
        }

        public static void QuickSort(int[] array)
        {
            sort(0, array.Length - 1);

            void sort(int low, int high)
            {
                if (high <= low)
                    return;

                int j = partition(low, high);
                sort(low, j - 1);
                sort(j + 1, high);

                int partition(int low, int high)
                {
                    int i = low;
                    int j = high + 1;

                    int pivot = array[low];
                    while (true)
                    {
                        while (array[++i] < pivot)
                        {
                            if (i == high)
                                break;
                        }
                        while (pivot < array[--j])
                        {
                            if (j == low)
                                break;
                        }

                        if (i >= j)
                            break;

                        Swap(array, i, j);
                    }
                    Swap(array, low, j);
                    return j;
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
