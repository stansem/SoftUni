using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
{
    public LinkedList<KeyValue<TKey, TValue>>[] Array;
    public int Count { get; private set; }

    public int Capacity
    {
        get
        {
            return this.Array.Length;
        }
    }

    public HashTable(int capacity = 16)
    {
        Array = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        Count = 0;
    }

    public void Add(TKey key, TValue value)
    {
        GrowIfNeeded();

        int index = GetIndex(key);

        if (Array[index] == null)
        {
            Array[index] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (var element in Array[index])
        {
            if (element.Key.Equals(key))
            {
                throw new ArgumentException("Key already exists!");
            }
        }

        KeyValue<TKey, TValue> kv = new KeyValue<TKey, TValue>(key, value);
        Array[index].AddLast(kv);
        Count++;
    }

    private int GetIndex(TKey key)
    {
        return Math.Abs(key.GetHashCode()) % Capacity;
    }

    private void GrowIfNeeded()
    {
        if((Count + 1) * 100 / Capacity >= 75)
        {
            LinkedList<KeyValue<TKey, TValue>>[] oldArray = Array;
            Array = new LinkedList<KeyValue<TKey, TValue>>[Capacity * 2];
            Count = 0;

            foreach(var list in oldArray)
            {
                if(list != null)
                {
                    foreach(var kv in list)
                    {
                        Add(kv.Key, kv.Value);
                    }
                }
            }
        }
    }

    public bool AddOrReplace(TKey key, TValue value)
    {
        int index = GetIndex(key);

        if (Array[index] == null)
        {
            Array[index] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (var element in Array[index])
        {
            if (element.Key.Equals(key))
            {
                element.Value = value;
                return false;
            }
        }

        GrowIfNeeded();

        KeyValue<TKey, TValue> kv = new KeyValue<TKey, TValue>(key, value);
        Array[index].AddLast(kv);
        Count++;
        return true;
    }

    public TValue Get(TKey key)
    {
        KeyValue<TKey, TValue> kv = Find(key);
        if(kv == null)
        {
            throw new KeyNotFoundException("Key not found!");
        }

        return kv.Value;
    }

    public TValue this[TKey key]
    {
        get
        {
            return Get(key);
        }
        set
        {
            AddOrReplace(key, value);
        }
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        value = default(TValue);
        KeyValue<TKey, TValue> kv = Find(key);
        if (kv != null)
        {
            value = kv.Value;
            return true;
        }

        return false;
    }

    public KeyValue<TKey, TValue> Find(TKey key)
    {
        int index = GetIndex(key);
        
        if(Array[index] != null)
        {
            foreach(KeyValue<TKey, TValue> kv in Array[index])
            {
                if(kv.Key.Equals(key))
                {
                    return kv;
                }
            }
        }

        return null;
    }

    public bool ContainsKey(TKey key)
    {
        return Find(key) != null;
    }

    public bool Remove(TKey key)
    {
        int index = GetIndex(key);

        var list = Array[index];
        if (list != null)
        {
            foreach (KeyValue<TKey, TValue> kv in list)
            {
                if (kv.Key.Equals(key))
                {
                    list.Remove(kv);
                    Count--;
                    return true;
                }
            }
        }

        return false;
    }

    public void Clear()
    {
        Array = new LinkedList<KeyValue<TKey, TValue>>[Capacity];
        Count = 0;
    }

    public IEnumerable<TKey> Keys
    {
        get
        {
            return this.Select(element => element.Key);
        }
    }

    public IEnumerable<TValue> Values
    {
        get
        {
            return this.Select(element => element.Value);
        }
    }

    public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
    {
        foreach(LinkedList<KeyValue<TKey, TValue>> list in Array)
        {
            if(list != null)
            {
                foreach (KeyValue<TKey, TValue> kv in list)
                {
                    yield return kv;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
