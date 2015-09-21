using System;
using System.Collections.Generic;
using System.Linq;

class LongestIncreasingSequence
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        int len = arr.Length;
        int cnt = 0;
        int maxCnt = 0;
        int start = 0, end = 0;

        for (int i = 0; i < len;)
        {
            for(int j = i; j < len; j++)
            {
                if(j == i || arr[j] > arr[j - 1])
                {
                    Console.Write(arr[j] + " ");
                    cnt++;
                }
                else
                {
                    Console.WriteLine();
                    break;
                }
            }

            if (cnt > maxCnt)
            {
                start = i;
                end = i + cnt - 1;
                maxCnt = cnt;
            }

            i += cnt;
            cnt = 0;
        }
        Console.WriteLine();

        Console.Write("Longest: ");
        for(int i = start; i <= end; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }
}

