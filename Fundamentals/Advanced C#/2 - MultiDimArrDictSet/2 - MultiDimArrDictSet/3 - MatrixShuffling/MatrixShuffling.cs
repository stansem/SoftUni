using System;
using System.Collections.Generic;
using System.Linq;

class MatrixShuffling
{
    static string[,] a;
    static int m, n;

    static void Main()
    {
        m = int.Parse(Console.ReadLine());
        n = int.Parse(Console.ReadLine());
        a = new string[m, n];

        InputMatrix();

        string line;
        while((line = Console.ReadLine()) != "END")
        {
            string command = line.Split(' ')[0];
            int[] coords = line.Substring(command.Length + 1).Split(' ').Select(x => int.Parse(x)).ToArray();

            if (command == "swap" && Swap(coords))
            {
                PrintMatrix();
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }

    static void InputMatrix()
    {
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                a[i, j] = Console.ReadLine();
            }
        }
    }

    static bool Swap(int[] coords)
    {
        if(coords.Length == 4)
        {
            int x1 = coords[0], y1 = coords[1], x2 = coords[2], y2 = coords[3];

            if(x1 < m && x2 < m && y1 < n && y2 < n && x1 >= 0 && x2 >= 0 && y1 >= 0 && y2 >= 0)
            {
                string swap = a[x1, y1];
                a[x1, y1] = a[x2, y2];
                a[x2, y2] = swap;

                return true;
            }
        }
        return false;
    }

    static void PrintMatrix()
    {
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(a[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
