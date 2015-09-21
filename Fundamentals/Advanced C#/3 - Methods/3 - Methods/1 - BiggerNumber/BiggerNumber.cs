using System;
using System.Collections.Generic;
using System.Linq;

class BiggerNumber
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine(GetMax(a, b));
    }

    public static int GetMax(int a, int b)
    {
        if (a > b) return a;
        return b;
    }
}
