using System;
using System.Collections.Generic;
using System.Linq;

class TerroristsWin
{
    static void Main()
    {
        string str = Console.ReadLine();
        bool searchFirst = true;

        int index = str.IndexOf("|");
        int firstIndex = str.IndexOf("|");

        while (index != -1)
        {
            if(searchFirst == false)
            {
                string inBomb = str.Substring(firstIndex + 1, index - firstIndex - 1);
                int n = GetN(inBomb);
                int start = firstIndex - n;            
                int length = 2 * n + 2 + inBomb.Length;
                if (start < 0)
                {
                    length += start;
                    start = 0;
                }
                if (length + start > str.Length)
                {
                    length = str.Length - start;
                }
                string toReplace = str.Substring(start, length);

                string replacement = new string('.', toReplace.Length);
                str = str.Replace(toReplace, replacement);
            }
            else
            {
                firstIndex = index;
            }

            searchFirst = !searchFirst;
            index = str.IndexOf("|", index + 1);
        }

        Console.WriteLine(str);
    }

    static int GetN(string s)
    {
        int sum = 0;
        foreach(char c in s)
        {
            sum += c;
        }
        return sum % 10;
    }
}

