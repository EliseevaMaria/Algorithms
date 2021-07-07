using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedNode<T> Head { get; private set; }
        public SinglyLinkedNode<T> Tail { get; private set; }

        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        public void AddFirst(T value)
        {
            AddFirst(new SinglyLinkedNode<T>(value));
        }

        private void AddFirst(SinglyLinkedNode<T> node)
        {
            node.Next = Head;
            Head = node;
            Count++;

            if (Count == 1)
                Tail = Head;
        }

        public void AddLast(T value)
        {
            AddLast(new SinglyLinkedNode<T>(value));
        }

        private void AddLast(SinglyLinkedNode<T> node)
        {
            if (IsEmpty)
                Head = node;
            else
                Tail.Next = node;
            
            Tail = node;
            Count++;
        }

        public void RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            Head = Head.Next;
            Count--;

            if (Count == 0)
                Tail = null;
        }

        public void RemoveLast()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            if (Count == 1)
                Head = Tail = null;
            else
            {
                SinglyLinkedNode<T> current = Head;
                while (current.Next != Tail)
                    current = current.Next;

                current.Next = null;
                Tail = current;
            }

            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            SinglyLinkedNode<T> current = Head;
            while (current.Next != Tail)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
