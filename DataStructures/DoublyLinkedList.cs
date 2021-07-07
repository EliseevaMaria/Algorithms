using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class DoublyLinkedList<T>
    {
        public DoublyLinkedNode<T> Head { get; private set; }
        public DoublyLinkedNode<T> Tail { get; private set; }

        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        public void AddFirst(T value)
        {
            AddFirst(new DoublyLinkedNode<T>(value));
        }

        private void AddFirst(DoublyLinkedNode<T> node)
        {
            node.Next = Head;
            Head = node;
            Count++;

            if (Count == 1)
                Tail = Head;
            else
                Head.Next.Prev = Head;
        }

        public void AddLast(T value)
        {
            AddLast(new DoublyLinkedNode<T>(value));
        }

        private void AddLast(DoublyLinkedNode<T> node)
        {
            if (IsEmpty)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Prev = Tail;
            }

            Tail = node;
            Count++;
        }

        public void RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            Head = Head.Next;
            Count--;

            if (IsEmpty)
                Tail = null;
            else
                Head.Prev = null;
        }

        public void RemoveLast()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            Tail = Tail.Prev;
            Count--;

            if (IsEmpty)
                Head = null;
            else
                Tail.Next = null;
        }
    }
}
