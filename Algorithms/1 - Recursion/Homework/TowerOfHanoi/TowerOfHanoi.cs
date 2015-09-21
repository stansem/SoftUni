using System;
using System.Collections.Generic;
using System.Linq;

class TowerOfHanoi
{
    private static int stepsTaken = 0;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Stack<int> source = new Stack<int>(Enumerable.Range(1, n).Reverse());
        Stack<int> destination = new Stack<int>();
        Stack<int> spare = new Stack<int>();

        MoveDisks(n, source, destination, spare);

        Console.WriteLine(stepsTaken);
    }

    private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
    {
        stepsTaken++;

        if(bottomDisk == 1)
        {
            destination.Push(source.Pop());
        }
        else
        {
            MoveDisks(bottomDisk - 1, source, spare, destination);
            destination.Push(source.Pop());
            MoveDisks(bottomDisk - 1, spare, destination, source);
        }
    }
}

