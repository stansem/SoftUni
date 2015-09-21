using System;
using System.Collections.Generic;

class BiDictionary<K1, K2, T>
{
    private Dictionary<K1, List<T>> dict1;
    private Dictionary<K2, List<T>> dict2;
    private Dictionary<Tuple<K1, K2>, List<T>> dict3;

    public BiDictionary()
    {
        dict1 = new Dictionary<K1, List<T>>();
        dict2 = new Dictionary<K2, List<T>>();
        dict3 = new Dictionary<Tuple<K1, K2>, List<T>>();
    }

    public void Add(K1 key1, K2 key2, T value)
    {
        if (!dict1.ContainsKey(key1))
        {
            dict1[key1] = new List<T>();
        }
        dict1[key1].Add(value);

        if (!dict2.ContainsKey(key2))
        {
            dict2[key2] = new List<T>();
        }
        dict2[key2].Add(value);

        Tuple<K1, K2> tuple = new Tuple<K1, K2>(key1, key2);
        if (!dict3.ContainsKey(tuple))
        {
            dict3[tuple] = new List<T>();
        }
        dict3[tuple].Add(value);
    }

    public IEnumerable<T> FindByKey1(K1 key)
    {
        if (!dict1.ContainsKey(key)) yield break;
        
        foreach(T value in dict1[key])
        {
            yield return value;
        }
    }

    public IEnumerable<T> FindByKey2(K2 key)
    {
        if (!dict2.ContainsKey(key)) yield break;

        foreach (T value in dict2[key])
        {
            yield return value;
        }
    }

    public IEnumerable<T> Find(K1 key1, K2 key2)
    {
        Tuple<K1, K2> tuple = new Tuple<K1, K2>(key1, key2);

        if (!dict3.ContainsKey(tuple)) yield break;

        foreach (T value in dict3[tuple])
        {
            yield return value;
        }
    }

    public bool Remove(K1 key1, K2 key2)
    {
        Tuple<K1, K2> tuple = new Tuple<K1, K2>(key1, key2);
        if(dict3.ContainsKey(tuple))
        {
            dict1.Remove(key1);
            dict2.Remove(key2);
            dict3.Remove(tuple);

            return true;
        }

        return false;
    }
}
