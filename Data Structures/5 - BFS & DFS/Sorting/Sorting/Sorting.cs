using System;
using System.Collections.Generic;
using System.Linq;

class Sorting
{
    static int[] a = { 5, 4, 3, 2, 1 };
    static int k = 2;

    static void Main()
    {
        Console.WriteLine(CountReverses());
    }

    private static int CountReverses()
    {
        Queue<int[]> q = new Queue<int[]>();
        Dictionary<string, int> h = new Dictionary<string, int>();

        q.Enqueue(a);
        h.Add(string.Join("", a.Select(x => x.ToString())), 0);

        int cnt = 0;

        while (q.Count > 0)
        {
            int[] arr = q.Dequeue();
            string key = string.Join("", arr.Select(x => x.ToString()));
            int reverses = h[key];

            if (IsSorted(arr))
            {
                return reverses;
            }

            for (int i = 0; i <= a.Length - k; i++)
            {
                int[] reversed = ReverseSubArr(arr, i, k + i - 1);
                key = string.Join("", reversed.Select(x => x.ToString()));
                if (!h.ContainsKey(key))
                {
                    q.Enqueue(reversed);
                    h.Add(key, reverses + 1);
                }
            }

            cnt++;
        }

        return -1;
    }

    private static int[] ReverseSubArr(int[] arr, int start, int end)
    {
        int[] arr2 = new int[arr.Length];
        Array.Copy(arr, arr2, arr.Length);

        for(int i = start; i <= (end + start) / 2; i++)
        {
            int a = arr2[i];
            arr2[i] = arr2[end + start - i];
            arr2[end + start - i] = a;
        }

        return arr2;
    }

    private static bool IsSorted(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            if(arr[i] < arr[i - 1])
            {
                return false;
            }
        }
        
        return true;
    }
}