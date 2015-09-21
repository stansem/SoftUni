using System;
using System.Collections.Generic;

class StringMatrixRotation
{
    static char[,] matrix;

    static void Main()
    {
        Input();
        PrintMatrix();
    }

    static void Input()
    {
        string rotation = Console.ReadLine();
        int start = rotation.IndexOf("(") + 1;
        int end = rotation.IndexOf(")");
        int rotations = int.Parse(rotation.Substring(start, end - start)) / 90;

        List<string> lines = new List<string>();
        int cnt = 0, maxLen = 0;
        string line;
        while ((line = Console.ReadLine()) != "END")
        {
            lines.Add(line);
            if (line.Length > maxLen)
            {
                maxLen = line.Length;
            }
            cnt++;
        }

        matrix = new char[cnt, maxLen];
        for(int i = 0; i < cnt; i++)
        {
            for(int j = 0; j < maxLen; j++)
            {
                char symbol = ' ';
                if(lines[i].Length > j)
                {
                    symbol = lines[i][j];
                }

                matrix[i, j] = symbol;
            }
        }

        for(int i = 0; i < rotations; i++)
        {
            Rotate90();
        }

    }

    static void Rotate90()
    {
        int m = matrix.GetLength(0);
        int n = matrix.GetLength(1);

        char[,] newMartix = new char[n, m];

        for(int i = 0; i < n; i++)
        {
            for(int j = m - 1; j >= 0; j--)
            {
                newMartix[i, m - j - 1] = matrix[j, i];
            }
        }

        matrix = newMartix;
    }

    static void PrintMatrix()
    {

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}