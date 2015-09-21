using System;
using System.Collections.Generic;
using System.Linq;

class PythagoreanNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        int cnt = 0;

        for(int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(arr);

        int len = arr.Length;

        for(int a = 0; a < len; a++)
        {
            for(int b = a; b < len; b++)
            {
                for (int c = b; c < len; c++)
                {
                    if(arr[a] * arr[a] + arr[b] * arr[b] == arr[c] * arr[c])
                    {
                        Console.WriteLine(arr[a] + "*" + arr[a] + " + " + arr[b] + "*" + arr[b] + " = " + arr[c] + "*" + arr[c]);
                        cnt++;
                    }
                }

            }
        }

        if(cnt == 0)
        {
            Console.WriteLine("No");
        }
    }
}

