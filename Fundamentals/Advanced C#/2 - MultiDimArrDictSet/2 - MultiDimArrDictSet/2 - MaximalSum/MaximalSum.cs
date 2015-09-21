using System;
using System.Collections.Generic;
using System.Linq;

class MaximalSum
{
    static int[,] a;
    static int m, n;

    static void Main()
    {
        string line = Console.ReadLine();
        m = int.Parse(line.Split(' ')[0]);
        n = int.Parse(line.Split(' ')[1]);
        a = new int[m, n];

        InputMatrix();
        FindMax(a, m, n);
    }

    static void InputMatrix()
    {
        for(int i = 0; i < m; i++)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            for(int j = 0; j < arr.Length; j++)
            {
                a[i, j] = arr[j];
            }
        }
    }

    static void FindMax(int[,] a, int m, int n)
    {
        int startI = 0, startJ = 0;
        int max = int.MinValue;

        for(int i = 0; i < m - 2; i++)
        {
            for(int j = 0; j < n - 2; j++)
            {
                int sum = a[i, j] + a[i, j + 1] + a[i, j + 2] +
                    a[i + 1, j] + a[i + 1, j + 1] + a[i + 1, j + 2] +
                    a[i + 2, j] + a[i + 2, j + 1] + a[i + 2, j + 2];
                if (sum > max)
                {
                    startI = i;
                    startJ = j;
                    max = sum;
                }
            }
        }

        Console.WriteLine("Sum = " + max);
        for(int i = startI; i < startI + 3; i++)
        {
            for (int j = startJ; j < startJ + 3; j++)
            {
                Console.Write(a[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
}
