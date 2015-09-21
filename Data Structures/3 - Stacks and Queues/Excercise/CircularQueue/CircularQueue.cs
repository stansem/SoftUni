using System;

public class CircularQueue<T>
{
    public int Count { get; private set; }
    public int Capacity { get; private set; }

    private int startIndex;
    private int endIndex;
    private T[] elements;

    public CircularQueue(int capacity = 16)
    {
        Capacity = capacity;
        startIndex = 0;
        endIndex = 0;
        elements = new T[Capacity];
        Count = 0;
    }

    public void Enqueue(T element)
    {
        if(Count >= Capacity)
        {
            Grow();
        }

        elements[endIndex] = element;
        endIndex = (endIndex + 1) % Capacity;
        Count++;
    }
    
    private void Grow()
    {
        Capacity *= 2;
        T[] newArr = new T[Capacity];
        CopyElementsTo(newArr);

        elements = newArr;
        startIndex = 0;
        endIndex = Count;
    }

    private void CopyElementsTo(T[] newArr)
    {
        for (int i = startIndex, cnt = 0; cnt < Count; i++, cnt++)
        {
            newArr[cnt] = elements[i % Count];
        }
    }

    public T Dequeue()
    {
        if(Count == 0)
        {
            throw new InvalidOperationException("No elements in the queue!");
        }

        T element = elements[startIndex];
        startIndex = (startIndex + 1) % Capacity;
        Count--;

        return element;
    }

    public T[] ToArray()
    {   
        T[] arr = new T[Count];
        CopyElementsTo(arr);
        return arr;
    }
}


class Example
{
    static void Main()
    {
        var queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(4);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine("Capacity = {0}", queue.Capacity);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        Console.WriteLine("First = {0}", queue.Dequeue());

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine("Capacity = {0}", queue.Capacity);

        
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        int first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
