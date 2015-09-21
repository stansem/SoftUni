using System;
using System.Collections.Generic;
using System.Linq;

class PlusRemove
{
    static List<char[]> symbols = new List<char[]>();
    static List<bool[]> isHidden = new List<bool[]>();

    static void Main()
    {
        Input();
        RemovePlusses();
        Print();
    }

    static void Input()
    {
        string line;
        while ((line = Console.ReadLine()) != "END")
        {
            char[] arr = line.ToCharArray();
            symbols.Add(arr);
            isHidden.Add(new bool[arr.Length]);
        }
    }

    static void RemovePlusses()
    {
        for (int i = 0; i < symbols.Count - 2; i++)
        {
            for (int j = 1; j < symbols[i].Length; j++)
            {
                if (
                    j - 1 < symbols[i + 1].Length && char.ToLower(symbols[i][j]) == char.ToLower(symbols[i + 1][j - 1]) &&
                    j < symbols[i + 1].Length && char.ToLower(symbols[i][j]) == char.ToLower(symbols[i + 1][j]) &&
                    j + 1 < symbols[i + 1].Length && char.ToLower(symbols[i][j]) == char.ToLower(symbols[i + 1][j + 1]) &&
                    j < symbols[i + 2].Length && char.ToLower(symbols[i][j]) == char.ToLower(symbols[i + 2][j])
                )
                {
                    isHidden[i][j] = true;
                    isHidden[i + 1][j - 1] = true;
                    isHidden[i + 1][j] = true;
                    isHidden[i + 1][j + 1] = true;
                    isHidden[i + 2][j] = true;
                }
            }
        }
    }

    static void Print()
    {
        for (int i = 0; i < symbols.Count; i++)
        {
            for (int j = 0; j < symbols[i].Length; j++)
            {
                if (!isHidden[i][j])
                {
                    Console.Write(symbols[i][j]);
                }
            }
            Console.WriteLine();
        }
    }
}

