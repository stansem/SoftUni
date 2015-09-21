using System;
using System.Collections.Generic;
using System.Linq;

class Area : IComparable<Area>
{
    public int Row { get; set; }
    public int Col { get; set; }
    public int Size { get; set; }

    public int CompareTo(Area other)
    {
        int cmp = -1 * Size.CompareTo(other.Size);
        if (cmp == 0)
        {
            cmp = Row.CompareTo(other.Row);
            if(cmp == 0)
            {
                cmp = Col.CompareTo(other.Col);
            }
        }
        
        return cmp;
    }

}

class ConnectedAreas
{
    static char[,] matrix =
    {
        {' ', ' ', '*', ' ', ' '},
        {'*', '*', '*', ' ', ' '},
        {' ', ' ', '*', '*', '*'},
        {' ', ' ', '*', ' ', ' '},	
        {' ', ' ', '*', '*', '*'},	
        {' ', ' ', '*', ' ', ' '},

    };

    static SortedSet<Area> set = new SortedSet<Area>();

    static void FindFirstAvailable(ref int row, ref int col)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if(matrix[i, j] == ' ')
                {
                    row = i;
                    col = j;
                    return;
                }
            }
        }

        row = -1;
        col = -1;
    }

    static void PrintMatrix()
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "|");
            }
            Console.WriteLine();
        }
    }

    static void Traverse(int row, int col, Area area)
    {
        if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
        {
            return;
        }
        if (matrix[row, col] == 'x' || matrix[row, col] == '*')
        {
            return;
        }

        area.Size++;
        matrix[row, col] = 'x';

        Traverse(row + 1, col, area);
        Traverse(row, col - 1, area);
        Traverse(row - 1, col, area);
        Traverse(row, col + 1, area);
    }

    static void Main()
    {
        int row = -1, col = -1;

        FindFirstAvailable(ref row, ref col);
        while (row != -1 && col != -1)
        {
            Area area = new Area(){ Row = row, Col = col, Size = 0 };
            set.Add(area);
            Traverse(row, col, area);

            FindFirstAvailable(ref row, ref col);
        }

        Console.WriteLine("Total areas found: " + set.Count);
        int i = 1;
        
        foreach(Area a in set)
        {
            Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", i, a.Row, a.Col, a.Size);
            i++;
        }
    }
}
