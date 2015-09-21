using System;
using System.Collections.Generic;
using System.Linq;

class PathsInMatrix
{
    static char[,] matrix =
    {
        {'s', ' ', ' ', '*'},
        {'*', '*', ' ', ' '},
        {'*', ' ', ' ', ' '},
        {'*', ' ', ' ', 'e'},
    };

    static int pathsFound = 0;
    static List<char> path = new List<char>();

    static void Main(string[] args)
    {
        FindPaths(0, 0, 'S');
        Console.WriteLine("Total paths found: " + pathsFound);
    }

    static void FindPaths(int row, int col, char dir)
    {
        if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
        {
            return;
        }

        if (matrix[row, col] == 'x' || matrix[row, col] == '*')
        {
            return;
        }

        path.Add(dir);

        if (matrix[row, col] == 'e')
        {
            PrintPath();
            pathsFound++;
            path.RemoveAt(path.Count - 1);
            return;
        }

        matrix[row, col] = 'x';

        FindPaths(row + 1, col, 'D');
        FindPaths(row, col - 1, 'L');
        FindPaths(row - 1, col, 'U');
        FindPaths(row, col + 1, 'R');

        matrix[row, col] = ' ';

        path.RemoveAt(path.Count - 1);
    }

    static void PrintPath()
    {
        foreach(char c in path)
        {
            Console.Write(c);
        }
        Console.WriteLine();
    }
}

