using System;
using System.Collections.Generic;
using System.Linq;

class LargerThanNeighbors
{
    static void Main()
    {
        int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };
        
        for(int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(IsLargerThanNeighbors(numbers, i));
        }
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
