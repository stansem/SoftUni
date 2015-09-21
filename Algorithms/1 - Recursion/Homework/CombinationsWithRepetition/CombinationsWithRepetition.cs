using System;
using System.Collections.Generic;
using System.Linq;

class CombinationsWithRepetition
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        Comb(n, k, new int[k]);
    }

    static void Comb(int n, int k, int[] arr, int startIndex = 1, int cnt = 0)
    {
        if (cnt == k)
        {
            PrintArr(arr);
            return;
        }

        for (int i = startIndex; i <= n; i++)
        {
            arr[cnt] = i;
            Comb(n, k, arr, i, cnt + 1);
        }
    }

    static void PrintArr(int[] arr)
    {
        foreach (int i in arr)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}

