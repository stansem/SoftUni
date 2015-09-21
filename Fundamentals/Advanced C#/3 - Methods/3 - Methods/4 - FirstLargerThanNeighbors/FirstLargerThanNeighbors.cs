using System;
using System.Collections.Generic;
using System.Linq;

class FirstLargerThanNeighbors
{
    static void Main()
    {
        int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };
        int[] numbers1 = { -3, 4, -5, 6, 0, 1 };
        int[] numbers2 = { 1, 2, 2, 3, 4, 4, 5 };
        int[] numbers3 = { 1 };
        int[] numbers4 = { };
        int[] numbers5 = { 2, 2, 2, 2 };
        int[] numbers6 = { 7, 6, 100, 900 };
        Console.WriteLine(GetIndexOfFirstLargerThanNeighbors(numbers));
        Console.WriteLine(GetIndexOfFirstLargerThanNeighbors(numbers1));
        Console.WriteLine(GetIndexOfFirstLargerThanNeighbors(numbers2));
        Console.WriteLine(GetIndexOfFirstLargerThanNeighbors(numbers3));
        Console.WriteLine(GetIndexOfFirstLargerThanNeighbors(numbers4));
        Console.WriteLine(GetIndexOfFirstLargerThanNeighbors(numbers5));
        Console.WriteLine(GetIndexOfFirstLargerThanNeighbors(numbers6));
    }

    static int GetIndexOfFirstLargerThanNeighbors(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (IsLargerThanNeighbors(arr, i)) return i;
        }
        return -1;
    }

    static bool IsLargerThanNeighbors(int[] arr, int i)
    {
        int len = arr.Length;
        if (len <= 1) return false;
        if (i == 0) return arr[i] > arr[i + 1];
        if (i == len - 1) return arr[i] > arr[i - 1];
        return arr[i] > arr[i + 1] && arr[i] > arr[i - 1];
    }
}

