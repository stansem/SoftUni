using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NMSequenceList
{
    static void Main()
    {
        int n = 3;
        int m = 12;

        List<int> numbers = new List<int>();
        numbers.Add(n);

        int i = 0;

        while(true)
        {
            int num = numbers[i];
            if(num == m)
            {
                PrintSequence(numbers, n, i);
                break;
            }

            numbers.Add(num + 1);
            numbers.Add(num + 2);
            numbers.Add(num * 2);

            i++;
        }
    }

    private static void PrintSequence(List<int> numbers, int start, int indexOfEnd)
    {
        int end = numbers[indexOfEnd];
        Console.WriteLine(end);

        while(end > start)
        {
            int blockNum = (int)Math.Ceiling((double)indexOfEnd / 3);
            indexOfEnd = blockNum - 1;
            end = numbers[indexOfEnd];
            Console.WriteLine(end);
        }
    }

}
