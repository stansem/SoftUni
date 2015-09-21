using System;
using System.Collections.Generic;

class RootFinder
{
    static void Main()
    {
        int nodes = int.Parse(Console.ReadLine());
        int verts = int.Parse(Console.ReadLine());

        bool[] hasParent = new bool[nodes];
       
        for(int i = 0; i < verts; i++)
        {
            string[] line = Console.ReadLine().Split(' ');
            int node2 = int.Parse(line[1]);

            hasParent[node2] = true;
        }

        int noParent = 0;
        int root = 0;

        for(int i = 0; i < nodes; i++)
        {
            if (!hasParent[i])
            {
                noParent++;
                root = i;
            }
        }

        if(noParent == 0)
        {
            Console.WriteLine("No root!");
        }
        else if (noParent > 1)
        {
            Console.WriteLine("Multiple root nodes!");
        }
        else
        {
            Console.WriteLine(root);
        }
    }
}
