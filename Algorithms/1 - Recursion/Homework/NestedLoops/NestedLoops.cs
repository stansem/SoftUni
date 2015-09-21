using System;
using System.Collections.Generic;
using System.Linq;

class NestedLoops
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        NestLoops(n, new int[n]);
    }

    static void NestLoops(int n, int[] arr, int cnt = 0)
    {
        if (cnt == n)
        {
            PrintArr(arr);
            return;
        }

        for(int i = 1; i <= n; i++)
        {
            arr[cnt] = i;
            NestLoops(n, arr, cnt + 1);
        }
    }

    static void PrintArr(int[] arr)
    {
        foreach(int i in arr)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}

