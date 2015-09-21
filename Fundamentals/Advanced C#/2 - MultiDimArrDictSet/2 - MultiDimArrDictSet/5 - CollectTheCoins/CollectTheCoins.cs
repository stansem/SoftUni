using System;
using System.Collections.Generic;
using System.Linq;

class CollectTheCoins
{
    static void Main()
    {
        char[][] jagged = new char[4][];

        for(int i = 0; i < 4; i++)
        {
            string line = Console.ReadLine();
            jagged[i] = line.ToArray();
        }

        string moves = Console.ReadLine();
        int coins = 0;
        int wallHits = 0;
        int row = 0, col = 0;

        for(int i = 0; i <= moves.Length; i++)
        {
            if(jagged[row][col] == '$')
            {
                coins++;
            }

            if(i < moves.Length)
            {
                switch (moves[i])
                {
                    case 'V':
                        row++;
                        if (row == 4)
                        {
                            row--;
                            wallHits++;
                        }
                        else if (col >= jagged[row].Length)
                        {
                            row--;
                            wallHits++;
                        }
                        break;
                    case '>':
                        col++;
                        if (col == jagged[row].Length)
                        {
                            col--;
                            wallHits++;
                        }
                    break;
                    case '<':
                        col--;
                        if (col == -1)
                        {
                            col++;
                            wallHits++;
                        }
                    break;
                    case '^':
                        row--;
                        if (row == -1)
                        {
                            row++;
                            wallHits++;
                        }
                        else if (col >= jagged[row].Length)
                        {
                            row++;
                            wallHits++;
                        }
                        break;
                }
            }
        }

        Console.WriteLine("Coins collected: " + coins);
        Console.WriteLine("Walls hit: " + wallHits);
    }
}

