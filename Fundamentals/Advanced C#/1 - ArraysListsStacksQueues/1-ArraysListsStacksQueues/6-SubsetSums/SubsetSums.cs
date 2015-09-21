using System;
using System.Collections.Generic;
using System.Linq;

class SubsetSums
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        FindSubsets(arr, n);
    }

    private static void FindSubsets(int[] array, int sum)
    {
        int numOfSubsets = 1 << array.Length;
        int cnt = 0;

        for (int i = 0; i < numOfSubsets; i++)
        {
            List<int> numbers = new List<int>();

            int pos = array.Length - 1;
            int bitmask = i;

            while (bitmask > 0)
            {
                if ((bitmask & 1) == 1)
                {
                    numbers.Add(array[pos]);
                }

                bitmask >>= 1;
                pos--;
            }

            if (numbers.Count > 0 && numbers.Sum() == sum)
            {
                Console.WriteLine(string.Join(" + ", numbers) + " = " + sum);
                cnt++;
            }
        }

        if(cnt == 0)
        {
            Console.WriteLine("No matching subsets.");
        }
    }
}
