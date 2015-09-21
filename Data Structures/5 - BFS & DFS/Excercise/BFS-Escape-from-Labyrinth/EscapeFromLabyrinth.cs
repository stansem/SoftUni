using System;
using System.Collections.Generic;

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }
    public char Dir { get; set; }
    public Point Previous { get; set; }

    public Point(int x, int y, char dir, Point prev = null)
    {
        X = x;
        Y = y;
        Dir = dir;
        Previous = prev;
    }
}

public class EscapeFromLabyrinth
{
    private static char[,] labyrinth;
    private static Queue<Point> q;

    public static void Main()
    {
        labyrinth = InputLabyrinth();
        string path = FindShortestPath();

        if(path == null)
        {
            Console.WriteLine("No exit!");
        }
        else if(path == "")
        {
            Console.WriteLine("Start is at the exit.");
        }
        else
        {
            Console.WriteLine("Shortest exit: " + path);
        }
    }

    private static Point FindStart()
    {
        for(int i = 0; i < labyrinth.GetLength(0); i++)
        {
            for (int j = 0; j < labyrinth.GetLength(1); j++)
            {
                if(labyrinth[i, j] == 's')
                {
                    return new Point(i, j, ' ', null);
                }
            }
        }

        return null;
    }

    private static char[,] InputLabyrinth()
    {
        int y = int.Parse(Console.ReadLine());
        int x = int.Parse(Console.ReadLine());

        char[,] labirynth = new char[x, y];

        for(int i = 0; i < x; i++)
        {
            string line = Console.ReadLine();
            for(int j = 0; j < y; j++)
            {
                labirynth[i, j] = line[j];
            }
        }

        return labirynth;
    }

    private static string FindShortestPath()
    {
        Point startPoint = FindStart();
        if (startPoint == null) return null;

        q = new Queue<Point>();
        q.Enqueue(startPoint);

        while(q.Count > 0)
        {
            Point p = q.Dequeue();
           
            if(IsExit(p))
            {
                return GetPathString(p); ;
            }

            EnqueueCell(p, 'U', -1, 0);
            EnqueueCell(p, 'R', 0, 1);
            EnqueueCell(p, 'D', 1, 0);
            EnqueueCell(p, 'L', 0, -1);

            BlockCell(p);
        }

        return null;
    }

    private static void BlockCell(Point p)
    {
        labyrinth[p.X, p.Y] = '*';
    }

    private static bool IsExit(Point p)
    {
        return labyrinth[p.X, p.Y] != '*' && (p.X == 0 || p.Y == 0 || p.X == labyrinth.GetLength(0) - 1 || p.Y == labyrinth.GetLength(1) - 1);
    }

    private static void EnqueueCell(Point p, char dir, int xMov, int yMov)
    {
        int x = p.X + xMov;
        int y = p.Y + yMov;

        if(IsAvailable(x, y))
        {
            Point p1 = new Point(x, y, dir, p);
            q.Enqueue(p1);
        }
    }

    private static bool IsAvailable(int x, int y)
    {
        return labyrinth[x, y] != '*' && x >= 0 && y >= 0 && x < labyrinth.GetLength(0) && y < labyrinth.GetLength(1);
    }

    private static string GetPathString(Point p)
    {
        string path = "";
        while(p != null)
        {
            if(p.Dir != ' ')
            {
                path += p.Dir;
            }
            p = p.Previous;
        }

        string path1 = "";
        for (int i = path.Length - 1; i >= 0; i--)
        {
            path1 += path[i];
        }

        return path1;
    }
}
