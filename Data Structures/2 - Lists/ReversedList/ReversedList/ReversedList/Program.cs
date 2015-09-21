using System;
using System.Collections;
using System.Collections.Generic;

class ReversedList<T> : IEnumerable<T>
{
    private T[] array;
    public int Count { get; private set; }
    public int Capacity { get; private set; }

    public ReversedList()
    {
        Count = 0;
        Capacity = 16;
        array = new T[Capacity];
    }

    public void Add(T item)
    {
        if (Count == Capacity)
        {
            Capacity *= 2;
            T[] newArray = new T[Capacity];
            Array.Copy(array, newArray, Count);
            array = newArray;
        }

        array[Count] = item;
        Count++;
    }

    public T Remove(int index)
    {
        index = Count - index - 1;

        T value = array[index];

        for (int i = index; i < Count - 1; i++)
        {
            array[index] = array[index + 1];
        }
        Count--;

        return value;
    }

    public T this[int index]
    {
        get
        {
            return array[Count - index - 1];
        }
        set
        {
            array[Count - index - 1] = value;
        }
    }


    public IEnumerator<T> GetEnumerator()
    {
        for(int i = Count - 1; i >= 0; i--)
        {
            yield return array[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}


class ReversedListTest
{
    static void Main(string[] args)
    {
        ReversedList<int> list = new ReversedList<int>();
        list.Add(1);
        list.Add(55);
        list.Add(22);
        list.Add(108);

        foreach(int s in list)
        {
            Console.WriteLine(s);
        }

        Console.WriteLine(list.Count);
        Console.WriteLine(list.Capacity);
    }
}
