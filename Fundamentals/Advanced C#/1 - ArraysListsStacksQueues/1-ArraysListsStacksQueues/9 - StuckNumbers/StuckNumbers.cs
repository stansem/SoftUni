using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StuckNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] arr = Console.ReadLine().Split(' ');
        int len = arr.Length;
        int cnt = 0;

        for(int a = 0; a < len; a++)
        {
            for (int b = 0; b < len; b++)
            {
                if(b != a)
                {
                    string stuck1 = arr[a] + arr[b];
                    for (int c = 0; c < len; c++)
                    {
                        if(c != a && c != b)
                        {
                            for (int d = 0; d < len; d++)
                            {
                                if (d != a && d != b && d != c)
                                {
                                    string stuck2 = arr[c] + arr[d];

                                    if(stuck1 == stuck2)
                                    {
                                        Console.WriteLine(arr[a] + "|" + arr[b] + "==" + arr[c] + "|" + arr[d]);
                                        cnt++;
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }

        if(cnt == 0)
        {
            Console.WriteLine("No");
        }
    }
}

