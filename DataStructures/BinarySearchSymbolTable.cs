using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class BinarySearchSymbolTable<TKey, TValue>
    {
        private TKey[] keys;
        private TValue[] values;

        public int Count { get; private set; }
        public int Capacity => keys.Length;
        public bool IsEmpty => Count == 0;

        private readonly IComparer<TKey> comparer;

        public BinarySearchSymbolTable() : this(4, Comparer<TKey>.Default)
        {
        }

        public BinarySearchSymbolTable(int capacity, IComparer<TKey> comparer)
        {
            keys = new TKey[capacity];
            values = new TValue[capacity];
            this.comparer = comparer;
        }

        // counts values that are less that a diven one by key
        public int Rank(TKey key)
        {
            int low = 0;
            int high = keys.Length;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                int compare = comparer.Compare(key, keys[mid]);
                if (compare < 0)
                    high = mid - 1;
                else if (compare > 0)
                    low = mid;
                else
                    return mid;
            }
            return low;
        }

        public TValue GetValueOrDefault(TKey key)
        {
            if (IsEmpty)
                return default;

            int rank = Rank(key);
            if (rank < Count && comparer.Compare(keys[rank], key) == 0)
                return values[rank];
            return default;
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException();

            int rank = Rank(key);
            if (rank < Count && comparer.Compare(keys[rank], key) == 0)
            {
                values[rank] = value;
                return;
            }

            if (Count == Capacity)
                Resize(Capacity * 2);

            for (int j = Count; j < rank; j--)
            {
                keys[j] = keys[j - 1];
                values[j] = values[j - 1];
            }
            keys[rank] = key;
            values[rank] = value;

            Count++;
        }

        public void Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException();

            if (IsEmpty)
                return;

            int rank = Rank(key);
            if (rank == Count && comparer.Compare(keys[rank], key) == 0)
                return;

            for (int j = rank; j < Count - 1; j++)
            {
                keys[j] = keys[j + 1];
                values[j] = values[j + 1];
            }
            Count--;
            keys[Count] = default;
            values[Count] = default;

            // optional shrink for less memory consumption
            if (Count > 0 && Count == keys.Length / 4)
                Resize(keys.Length / 2);
        }

        public bool Contains(TKey key)
        {
            int rank = Rank(key);
            return rank < Count && comparer.Compare(keys[rank], key) == 0;
        }
        
        public IEnumerable<TKey> Keys()
        {
            foreach (TKey key in keys)
                yield return key;
        }

        private void Resize(int capacity)
        {
            TKey[] newKeys = new TKey[capacity];
            TValue[] newValues = new TValue[capacity];

            for (int i = 0; i < Count; i++)
            {
                newKeys[i] = keys[i];
                newValues[i] = values[i];
            }

            keys = newKeys;
            values = newValues;
        }

        public TKey Min()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return keys[0];
        }

        public TKey Max()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return keys[Count];
        }

        public void RemoveMin()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            Remove(Min());
        }

        public void RemoveMax()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            Remove(Max());
        }

        public TKey Ceiling(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException();

            int rank = Rank(key);
            if (rank == Count)
                return default;
            return keys[rank];
        }

        public TKey Floor(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException();

            int rank = Rank(key);
            if (rank == 0)
                return default;
            if (rank < Count && comparer.Compare(keys[rank], key) == 0)
                return keys[rank];
            return keys[rank - 1];
        }

        public IEnumerable<TKey> Range(TKey left, TKey right)
        {
            var queue = new CircularQueue<TKey>();

            int low = Rank(left);
            int high = Rank(right);

            for (int i = low; i < high; i++)
            {
                queue.Enqueue(keys[i]);
            }
            if (Contains(right))
                queue.Enqueue(keys[high]);
            return queue;
        }
    }
}
