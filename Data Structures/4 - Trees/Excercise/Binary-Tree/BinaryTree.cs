using System;

public class BinaryTree<T>
{
    public T Value { get; set; }
    BinaryTree<T> LeftChild { get; set; }
    BinaryTree<T> RightChild { get; set; }

    public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
    {
        Value = value;

        LeftChild = leftChild;
        RightChild = rightChild;
    }

    public void PrintIndentedPreOrder(int indent = 0)
    {
        Console.WriteLine(new string(' ', 2 * indent) + Value);

        if (LeftChild != null)
        {
            LeftChild.PrintIndentedPreOrder(indent + 1);
        }

        if (RightChild != null)
        {
            RightChild.PrintIndentedPreOrder(indent + 1);
        }
    }

    public void EachInOrder(Action<T> action)
    {
        if (LeftChild != null)
        {
            LeftChild.EachInOrder(action);
        }

        action(Value);

        if (RightChild != null)
        {
            RightChild.EachInOrder(action);
        }
    }

    public void EachPostOrder(Action<T> action)
    {
        if (LeftChild != null)
        {
            LeftChild.EachPostOrder(action);
        }

        if (RightChild != null)
        {
            RightChild.EachPostOrder(action);
        }

        action(Value);
    }

    public int Count(BinaryTree<T> root)
    {
        if (root == null) return 0;

        return 1 + Count(root.LeftChild) + Count(root.RightChild); 
    }

    public bool CheckCount()
    {
        if (LeftChild != null)
        {
            LeftChild.CheckCount();
        }

        if (RightChild != null)
        {
            RightChild.CheckCount();
        }

        return Math.Abs(Count(LeftChild) - Count(RightChild)) <= 1;
    }
}
