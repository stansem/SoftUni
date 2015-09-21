using System;
using System.Collections.Generic;
using System.Linq;

class SortArr
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        Array.Sort(arr);

        foreach(int i in arr)
        {
            Console.Write(i + " ");
        }
    }
}

