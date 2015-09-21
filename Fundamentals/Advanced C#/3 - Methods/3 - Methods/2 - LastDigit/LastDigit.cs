using System;
using System.Collections.Generic;
using System.Linq;

class LastDigit
{
    static void Main()
    {
        Console.WriteLine(GetLastDigitAsWord(123));
        Console.WriteLine(GetLastDigitAsWord(-3));
        Console.WriteLine(GetLastDigitAsWord(0));
        Console.WriteLine(GetLastDigitAsWord(1198));
        Console.WriteLine(GetLastDigitAsWord(111111));
    }

    static string GetLastDigitAsWord(int a)
    {
        int last = Math.Abs(a) % 10;

        switch(last)
        {
            case 0: return "zero";
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eight";
            default: return "nine";
        }
    }
}

