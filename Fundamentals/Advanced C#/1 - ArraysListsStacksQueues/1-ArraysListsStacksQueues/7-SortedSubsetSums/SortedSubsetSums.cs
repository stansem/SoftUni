using System;
using System.Collections.Generic;
using System.Linq;

class SortedSubsetSums
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
        List<List<int>> lists = new List<List<int>>();

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
                numbers.Sort();
                lists.Add(numbers);
            }
        }

        if (lists.Count == 0)
        {
            Console.WriteLine("No matching subsets.");
        }
        else
        {
            lists = lists.OrderBy(x => x.Count).ThenBy(x => x[0]).ToList();

            foreach(List<int> l in lists)
            {
                Console.WriteLine(string.Join(" + ", l) + " = " + sum); 
            }
        }
    }
}
