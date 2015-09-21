using System;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
    private List<T> Heap;

    public BinaryHeap()
    {
        Heap = new List<T>();
    }

    public BinaryHeap(T[] elements)
    {
        Heap = new List<T>(elements);

        for(int i = Heap.Count / 2; i >= 0; i--)
        {
            HeapifyDown(i);
        }
    }

    public int Count
    {
        get
        {
            return Heap.Count;
        }
    }

    public T ExtractMax()
    {
        T max = Heap[0];
        T end = Heap[Count - 1];

        Heap[0] = end;
        Heap.RemoveAt(Count - 1);

        if(Count > 0)
        {
            HeapifyDown(0);
        }

        return max;
    }

    public T PeekMax()
    {
        return Heap[0];
    }

    public void Insert(T node)
    {
        Heap.Add(node);
        HeapifyUp(Count - 1);
    }

    private void HeapifyDown(int i)
    {
        int left = 2 * i + 1;
        int right = 2 * i + 2;
        int max = i;

        if(left < Count && Heap[left].CompareTo(Heap[max]) > 0)
        {
            max = left;
        }

        if (right < Count && Heap[right].CompareTo(Heap[max]) > 0)
        {
            max = right;
        }

        if(max != i)
        {
            T val = Heap[max];
            Heap[max] = Heap[i];
            Heap[i] = val;

            HeapifyDown(max);
        }
    }

    private void HeapifyUp(int i)
    {
        int parent = (i - 1) / 2;

        while(parent >= 0 && Heap[i].CompareTo(Heap[parent]) > 0)
        {
            T val = Heap[i];
            Heap[i] = Heap[parent];
            Heap[parent] = val;

            i = parent;
            parent = (i - 1) / 2;
        }
    }
}
