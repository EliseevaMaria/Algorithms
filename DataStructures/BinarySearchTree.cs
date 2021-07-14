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

        public void Remove(T value)
        {
            if (root == null)
                throw new InvalidOperationException();

            root = Remove(root, value);
        }

        private TreeNode<T> Remove(TreeNode<T> root, T value)
        {
            if (root == null)
                return null;

            int compare = value.CompareTo(root.Value);
            if (compare < 0)
            {
                root.Left = Remove(root.Left, value);
            }
            else if (compare > 0)
            {
                root.Right = Remove(root.Right, value);
            }
            else
            {
                if (root.Left == null)
                {
                    return root.Right;
                }
                if (root.Right == null)
                {
                    return root.Left;
                }

                root.Value = root.Right.Min();
                root.Right = Remove(root.Right, root.Value);
            }
            return root;
        }
    }
}
