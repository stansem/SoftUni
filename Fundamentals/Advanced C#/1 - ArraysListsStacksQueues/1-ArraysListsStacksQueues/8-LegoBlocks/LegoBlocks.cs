using System;
using System.Collections.Generic;
using System.Linq;

class LegoBlocks
{
    static void Main()
    {
        int numLines = int.Parse(Console.ReadLine());
        int[][] arr1 = new int[numLines][];
        int[][] arr2 = new int[numLines][];

        bool lego = true;
        int numPerRow = 0;
        int totalElements = numPerRow;

        //четем масивите и същевременно трупаме общ брой елементи и проверяваме дали са "лего"
        for (int i = 0; i < numLines; i++)
        {
            string line = Console.ReadLine();
            if (line == "")
            {
                arr1[i] = new int[] { };
            }
            else
            {
                arr1[i] = line.Split(' ').Select(x => int.Parse(x)).ToArray();
            }
        }
        for (int i = 0; i < numLines; i++)
        {
            string line = Console.ReadLine();
            if (line == "")
            {
                arr2[i] = new int[] { };
            }
            else
            {
                arr2[i] = line.Split(' ').Select(x => int.Parse(x)).ToArray();
            }
            if (i == 0)
            {
                numPerRow = arr1[0].Length + arr2[0].Length;
            }
            if (arr1[i].Length + arr2[i].Length != numPerRow)
            {
                lego = false;
            }
            totalElements += arr1[i].Length + arr2[i].Length;
        }
        
        //показваме матрицата или обшия брой елементи
        if (lego)
        {
            for(int i = 0; i < numLines; i++)
            {
                Console.Write("[");
                for(int j = 0; j < arr1[i].Length; j++)
                {
                    Console.Write(arr1[i][j]);
                    if (j != arr1[i].Length)
                    {
                        Console.Write(", ");
                    }
                }
                for (int k = arr2[i].Length - 1; k >= 0; k--)
                {
                    Console.Write(arr2[i][k]);
                    if (k != 0)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine("]");
            }
        }
        else
        {
            Console.WriteLine("The total number of cells is: " + totalElements);
        }
    }
}

