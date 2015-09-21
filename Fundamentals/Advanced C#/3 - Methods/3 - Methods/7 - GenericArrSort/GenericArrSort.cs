using System;
using System.Collections.Generic;

class GenericSortArr
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 11, 0, -1, 2, -99, -100 };
        string[] strings = { "aaa", "000", "ofpf", "bnmb", "zzz", "zza", "---", "zzy" };
        DateTime[] dates = { new DateTime(2013, 12, 12), new DateTime(2000, 1, 2), new DateTime(2019, 8, 6), new DateTime(1999, 7, 16), };

        numbers = SortArray(numbers);
        strings = SortArray(strings);
        dates = SortArray(dates);

        PrintArr(numbers);
        PrintArr(strings);
        PrintArr(dates);
    }

    static T[] SortArray<T>(T[] arr) where T : IComparable<T>
    {
        int len = arr.Length;

        for(int i = 0; i < len - 1; i++)
        {
            int min = i;

            for(int j = i + 1; j < len; j++)
            {
                if(arr[j].CompareTo(arr[min]) < 0)
                {
                    T swap = arr[j];
                    arr[j] = arr[min];
                    arr[min] = swap;
                }
            }
        }

        return arr;
    }

    static void PrintArr<T>(T[] arr)
    {
        Console.WriteLine(string.Join(", ", arr));
    }
}


