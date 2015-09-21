using System;
using System.Collections.Generic;
using System.Linq;

class SelectSort
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int len = arr.Length;
        int min = 0;
        int swap;

        for(int i = 0; i < len - 1; i++)
        {
            min = i;
            for(int j = i + 1; j < len; j++)
            {
                if(arr[j] < arr[min])
                {
                    min = j;
                }
            }

            swap = arr[i];
            arr[i] = arr[min];
            arr[min] = swap;
        }

        foreach(int i in arr)
        {
            Console.Write(i + " ");
        }
    }
}

