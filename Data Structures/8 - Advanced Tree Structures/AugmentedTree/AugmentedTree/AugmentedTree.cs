using System;
using System.Collections.Generic;

class AugmentedTree<T> where T : IComparable<T>
{
    internal class Node<T> where T : IComparable<T>
    {
        public T StartInterval { get; set; }
        public T EndInterval { get; set; }
        public T TreeMaxValue { get; set; }

        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Parent { get; set; }
    }

    private Node<T> Root { get; set; }
    public int Count { get; set; }

    public AugmentedTree()
    {
        Root = null;
        Count = 0;
    }

    public void Insert(T start, T end)
    {
        Root = Insert(start, end, Root, null);
        Count++;
    }

    private Node<T> Insert(T start, T end, Node<T> root, Node<T> parent)
    {
        if(root == null)
        {
            root = new Node<T> { StartInterval = start, EndInterval = end, TreeMaxValue = end, Parent = parent };
        }
        else
        {
            if(start.CompareTo(root.StartInterval) < 0)
            {
                root.Left = Insert(start, end, root.Left, root);
                if (root.TreeMaxValue.CompareTo(root.Left.TreeMaxValue) < 0)
                {
                    root.TreeMaxValue = root.Left.TreeMaxValue;
                }
            }
            else
            {
                root.Right = Insert(start, end, root.Right, root);
                if (root.TreeMaxValue.CompareTo(root.Right.TreeMaxValue) < 0)
                {
                    root.TreeMaxValue = root.Right.TreeMaxValue;
                }
            }
        }

        return root;
    }

    public bool Search(T start, T end)
    {
        Node<T> search = null;
        Search(start, end, Root, ref search);

        return search != null;
    }

    private void Search(T start, T end, Node<T> root, ref Node<T> found)
    {
        if(root == null)
        {
            found = null;
            return;
        }

        if(start.CompareTo(root.StartInterval) >= 0 && end.CompareTo(root.EndInterval) <= 0)
        {
            found = root;
            return;
        }

        if (root.Right != null && end.CompareTo(root.Right.TreeMaxValue) <= 0)
        {
            Search(start, end, root.Right, ref found);
        }
        
        if(root.Left != null && end.CompareTo(root.Left.TreeMaxValue) <= 0)
        {
            Search(start, end, root.Left, ref found);
        }
    }
}
