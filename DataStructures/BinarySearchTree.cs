using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public TreeNode<T> Get(T value)
        {
            return root?.Get(value);
        }

        public T Min()
        {
            if (root == null)
                throw new InvalidOperationException();
            return root.Min();
        }

        public T Max()
        {
            if (root == null)
                throw new InvalidOperationException();
            return root.Max();
        }

        public void Insert(T value)
        {
            if (root == null)
                root = new TreeNode<T>(value);
            else
                root.Insert(value);
        }

        public IEnumerable<T> TraverseInOrder()
        {
            if (root != null)
                return root.TraverseInOrder();

            return Enumerable.Empty<T>();
        }
    }
}
