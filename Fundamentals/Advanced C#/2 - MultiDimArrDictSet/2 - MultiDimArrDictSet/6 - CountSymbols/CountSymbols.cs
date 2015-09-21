using System;
using System.Collections.Generic;

class CountSymbols
{
    static void Main()
    {
        string str = Console.ReadLine();
        SortedDictionary<char, int> dict = new SortedDictionary<char, int>();

        foreach(char c in str)
        {
            if(!dict.ContainsKey(c))
            {
                dict.Add(c, 0);
            }
            dict[c]++;
        }

        foreach(var kv in dict)
        {
            Console.WriteLine("{0} : {1}", kv.Key, kv.Value);
        }
    }
}

