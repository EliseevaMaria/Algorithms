using System;

namespace DataStructures
{
    public class SinglyLinkedNode<T>
    {
        public T Value { get; set; }
        public SinglyLinkedNode<T> Next { get; set; }

        public SinglyLinkedNode(T value)
        {
            this.Value = value;
        }
    }
}
