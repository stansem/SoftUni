using System;
using System.Collections.Generic;

namespace RideTheHorse
{
    class Cell
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Val { get; set; }
    }

    class RideTheHorse
    {
        private static int[,] arr;
        private static Queue<Cell> q;

        static void Main()
        {
            Cell c = Input();
            FillBoard(c);
            Output();
        }

        private static Cell Input()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int startRow = int.Parse(Console.ReadLine());
            int startCol = int.Parse(Console.ReadLine());

            arr = new int[rows, cols];
            q = new Queue<Cell>();

            Cell p = new Cell() { Row = startRow, Col = startCol, Val = 1 };
            return p;
        }

        private static void FillBoard(Cell startCell)
        {
            q.Enqueue(startCell);
            arr[startCell.Row, startCell.Col] = 1;

            while(q.Count > 0)
            {
                Cell p = q.Dequeue();

                VisitCell(p, -1, -2);
                VisitCell(p, -1, 2);
                VisitCell(p, 1, -2);
                VisitCell(p, 1, 2);
                VisitCell(p, -2, -1);
                VisitCell(p, -2, 1);
                VisitCell(p, 2, -1);
                VisitCell(p, 2, 1);
            }
        }

        private static void VisitCell(Cell c, int oR, int oC)
        {
            int newRow = c.Row + oR;
            int newCol = c.Col + oC;

            if(IsAvailable(newRow, newCol))
            {
                int newVal = c.Val + 1;
                arr[newRow, newCol] = newVal;

                Cell newCell = new Cell(){Row = newRow, Col = newCol, Val = newVal};
                q.Enqueue(newCell);
            }
        }

        private static bool IsAvailable(int row, int col)
        {
            return row >= 0 && row < arr.GetLength(0) 
                && col >= 0 && col < arr.GetLength(1)
                && arr[row, col] == 0;
        }

        private static void Output()
        {
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine(arr[i, (arr.GetLength(1) / 2)] + " ");
            }
        }
    }
}
