using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T>
    where T : IComparable<T>
{
    private List<T> elements = new List<T>();

    private OrderedMultiDictionary<T, LinkedListNode<T>> sortedElements =
        new OrderedMultiDictionary<T, LinkedListNode<T>>(
            true,
            (p1, p2) => p1.CompareTo(p2),
            (p1, p2) => p1.Value.CompareTo(p2.Value));

    public void Add(T newElement)
    {
        elements.Add(newElement);
    }

    public int Count
    {
        get
        {
            return elements.Count;
        }
    }

    public IEnumerable<T> First(int count)
    {
        if(Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }
        else
        {
            for(int i = 0; i < count; i++)
            {
                yield return elements[i];
            }
        }
    }

    public IEnumerable<T> Last(int count)
    {
        if (Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                yield return elements[Count - i - 1];
            }
        }
    }

    public IEnumerable<T> Min(int count)
    {
        if(Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }
        else
        {
           return elements.OrderBy(e => e).Take(count);
        }
    }

    public IEnumerable<T> Max(int count)
    {
        if (Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }
        else
        {
            return elements.OrderByDescending(e => e).Take(count);
        }
    }

    public int RemoveAll(T element)
    {
        return elements.RemoveAll(e => e.CompareTo(element) == 0);
    }

    public void Clear()
    {
        elements.Clear();
    }
}
