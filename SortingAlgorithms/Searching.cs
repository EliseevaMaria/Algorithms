using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class Searching
    {
        public static int BinarySearch(int[] array, int value)
        {
            int low = 0;
            int high = array.Length;

            while (low < high)
            {
                int middle = (low + high) / 2;
                if (array[middle] == value)
                    return middle;
                else if (array[middle] < value)
                    low = middle + 1;
                else
                    high = middle;
            }

            return -1;
        }

        public static int BinarySearchRecursive(int[] array, int value)
        {
            return internalBinarySearch(0, array.Length);
            int internalBinarySearch(int low, int high)
            {
                if (low >= high) 
                    return -1;

                int middle = (low + high) / 2;
                if (array[middle] == value)
                    return middle;
                if (array[middle] < value)
                    return internalBinarySearch(middle + 1, high);
                return internalBinarySearch(low, middle);
            }
        }
    }
}
