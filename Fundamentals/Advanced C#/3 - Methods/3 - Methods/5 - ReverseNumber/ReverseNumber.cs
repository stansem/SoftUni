using System;
using System.Collections.Generic;
using System.Linq;

class ReverseNumber
{
    static void Main()
    {
        Console.WriteLine(GetReversedNumber(123));
        Console.WriteLine(GetReversedNumber(56.87));
        Console.WriteLine(GetReversedNumber(0));
        Console.WriteLine(GetReversedNumber(1111.23));
    }

    static double GetReversedNumber(double n)
    {
        string str = n.ToString();
        char[] arr = str.ToCharArray();
        Array.Reverse(arr);
        str = new string(arr);

        return double.Parse(str);
    }
}
