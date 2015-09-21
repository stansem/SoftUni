using System;
using System.Collections.Generic;
using System.Linq;

class SequenceOfEqualStrings
{
    static void Main()
    {
        string[] arr = Console.ReadLine().Split(' ');

        string cur = arr[0];
        foreach(string s in arr)
        {
            if(s != cur)
            {
                Console.WriteLine();
            }

            Console.Write(s + " ");
            cur = s;
        }

        Console.WriteLine();
    }
}
