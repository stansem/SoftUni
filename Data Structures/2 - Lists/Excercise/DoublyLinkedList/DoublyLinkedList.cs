using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    public class ListNode<T>
    {
        public T Value { get; set; }
        public ListNode<T> Prev { get; set; }
        public ListNode<T> Next { get; set; }

        public ListNode(T value)
        {
            Value = value;
        }
    }

    private ListNode<T> head;
    private ListNode<T> tail;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        ListNode <T> node = new ListNode<T>(element);

        if(head == null)
        {
            tail = node;
        }
        else
        {
            node.Next = head;
            head.Prev = node;
        }

        head = node;

        Count++;
    }


    public void AddLast(T element)
    {
        ListNode<T> node = new ListNode<T>(element);

        if (tail == null)
        {
            head = node;
        }
        else
        {
            node.Prev = tail;
            tail.Next = node;
        }

        tail = node;

        Count++;
    }

    public T RemoveFirst()
    {
        if(Count == 0)
        {
            throw new InvalidOperationException("List is empty");
        }

        T removedValue = head.Value;

        if(Count == 1)
        {
            head = tail = null;
        }
        else
        {
            head = head.Next;
            head.Prev = null;
        }

        Count--;
        return removedValue;
    }

    public T RemoveLast()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("List is empty");
        }

        T removedValue = tail.Value;

        if (Count == 1)
        {
            head = tail = null;
        }
        else
        {
            tail = tail.Prev;
            tail.Next = null;
        }

        Count--;
        return removedValue;
    }

    public void ForEach(Action<T> action)
    {
        ListNode<T> currentNode = head;

        while(currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.Next;
        }
    }

    
    public IEnumerator<T> GetEnumerator()
    {
        ListNode<T> currentNode = head;

        while(currentNode != null)
        {
            yield return currentNode.Value; 
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        T[] arr = new T[Count];

        int i = 0;
        ListNode<T> currentNode = head;

        while(currentNode != null)
        {
            arr[i] = currentNode.Value;
            currentNode = currentNode.Next;
            i++;
        }

        return arr;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        //list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(18);
        list.AddFirst(11);
        list.AddLast(10);
        list.AddLast(55);
        list.AddFirst(6);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
        
        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");


        foreach(int i in list)
        {
            Console.WriteLine(i);
        }
    }
}
