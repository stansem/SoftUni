using System;
using System.Collections.Generic;

class FillTheMatrix
{
    static void Main()
    {
        FillA(4);
        Console.WriteLine();
        FillB(5);
    }

    static void FillA(int n)
    {
        int[,] a = new int[n, n];

        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < n; j++)
            {
                a[i, j] = (i + 1) + j * n;
            }
        }

        PrintMatrix(a, n);
    }

    static void FillB(int n)
    {
        int[,] a = new int[n, n];
        int cnt = 0;
        int pos = 1;
        int i = 0, j = 0;

        while(cnt < n * n)
        {
            a[i, j] = cnt + 1;

            if (pos == 1 && i == n - 1)
            {
                j++;
                pos = 2;
            }
            else if(pos == 2 && i == 0)
            {
                j++;
                pos = 1;
            }
            else
            {
                switch (pos)
                {
                    case 1: i++; break;
                    case 2: i--; break;
                }
            }

            cnt++;
        }

        PrintMatrix(a, n);
    }

    static void PrintMatrix(int[,] a, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0, 3}", a[i, j]);
            }
            Console.WriteLine();
        }
    }
}

