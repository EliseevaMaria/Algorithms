using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class CircularQueue<T> : IEnumerable<T>
    {
        private T[] queue;
        int head = 0;
        int tail = 0;

        public int Count => 
            head <= tail
            ? tail - head
            : tail - head + queue.Length;

        public bool IsEmpty => Count == 0;

        public int Capacity => queue.Length;

        public CircularQueue() : this(4)
        {
        }

        public CircularQueue(int capacity)
        {
            queue = new T[capacity];
        }

        public void Enqueue(T item)
        {
            if (Count == queue.Length - 1)
            {
                int countBefore = Count;
                T[] newQueue = new T[2 * Count];

                Array.Copy(queue, head, newQueue, 0, queue.Length - head);
                Array.Copy(queue, 0, newQueue, queue.Length - head, tail);

                queue = newQueue;

                head = 0;
                tail = countBefore;
            }

            queue[tail] = item;
            if (tail < queue.Length - 1)
                tail++;
            else
                tail = 0;
        }

        public void Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            queue[head++] = default;

            if (IsEmpty)
                head = tail = 0;
            else if (head == queue.Length)
                head = 0;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return queue[head];
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (head <= tail)
            {
                for (int i = head; i < tail; i++)
                    yield return queue[i];
            }
            else
            {
                for (int i = head; i < queue.Length; i++)
                    yield return queue[i];
                for (int i = 0; i < tail; i++)
                    yield return queue[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
