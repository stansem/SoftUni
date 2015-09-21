using System;
using System.Collections.Generic;

class SequenceInMatrix
{
    static void Main()
    {
        const int m = 4;
        const int n = 4;

        string[,] matrix = new string[m, n]
        {
            { "ha", "ha", "hp", "he" },
            { "ha", "hk", "he", "he" },
            { "hp", "ho", "ha", "hl" },
            { "hi", "hi", "hi", "ha" }
        };

        int maxLen = 0, startI = 0, startJ = 0, endI = 0, endJ = 0;
        for(int i = 0; i < m; i++)
        {
            for(int j = 0; j < n; j++)
            {
                string startWord = matrix[i, j];
                int len = 0;

                //check down
                int i1;
                for(i1 = i; i1 < m; i1++)
                {
                    if (matrix[i1, j] != startWord) break;
                    len++;
                }

                if(len > maxLen)
                {
                    maxLen = len;
                    startI = i;
                    endI = i1 - 1;
                    startJ = j;
                    endJ = j;
                }

                //check right
                len = 0;
                int j1;
                for (j1 = j; j1 < n; j1++)
                {
                    if (matrix[i, j1] != startWord) break;
                    len++;
                }

                if (len > maxLen)
                {
                    maxLen = len;
                    startI = i;
                    endI = i;
                    startJ = j;
                    endJ = j1 - 1;
                }

                //check diagonal
                len = 0;
                int j2, i2;
                for (j2 = j, i2 = i; j2 < n && i2 < m; j2++, i2++)
                {
                    if (matrix[i2, j2] != startWord) break;
                    len++;
                }

                if (len > maxLen)
                {
                    maxLen = len;
                    startI = i;
                    endI = i2 - 1;
                    startJ = j;
                    endJ = j2 - 1;
                }
            }
        }

        bool isDiagonal = endI > startI && endJ > startJ;
        List<string> l = new List<string>();
        for(int i = startI; i <= endI; i++)
        {
            for(int j = startJ; j <= endJ; j++)
            {
                if (!isDiagonal || i == j) l.Add(matrix[i, j]);
            }
        }

        Console.WriteLine(string.Join(", ", l));
    }
}

