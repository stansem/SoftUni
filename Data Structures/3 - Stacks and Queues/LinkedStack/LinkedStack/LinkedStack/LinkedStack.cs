using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class LinkedStack<T>
{
    class StackNode<T>
    {
        public T Value { get; set; }
        public StackNode<T> NextNode { get; set; }

        public StackNode(T value)
        {
            Value = value;
            NextNode = null;
        }
    }

    public int Count { get; private set; }
    private StackNode<T> top;

    public void Push(T value)
    {
        StackNode<T> newElement = new StackNode<T>(value);

        newElement.NextNode = top;
        top = newElement;

        Count++;
    }

    public T Pop()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Stack empty!");
        }

        T value = top.Value;
        top = top.NextNode;
        Count--;
        return value;
    }

    public T Peek()
    {
        if(Count == 0)
        {
            throw new InvalidOperationException("Stack empty!");
        }
        return top.Value;
    }

    public T[] ToArray()
    {
        T[] arr = new T[Count];
        StackNode<T> currentNode = top;

        int i = 0;
        while(currentNode != null)
        {
            arr[i] = currentNode.Value;
            currentNode = currentNode.NextNode;
            i++;
        }

        return arr;
    }
}

class LinkedStackTest
{
    static void Main()
    {
        LinkedStack<string> stack = new LinkedStack<string>();
        stack.Push("Stambeto");
        stack.Push("Gosho");
        stack.Push("Rumbaka");
        stack.Push("Ivu");
        stack.Push("Koko");
        stack.Push("Kris");

        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Peek());
        Console.WriteLine(stack.Pop());

        Console.WriteLine(stack.Count);

        string[] arr = stack.ToArray();
        foreach(string s in arr)
        {
            Console.WriteLine(s);
        }
    }
}

