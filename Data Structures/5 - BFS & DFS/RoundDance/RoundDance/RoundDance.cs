using System;
using System.Collections.Generic;

class RoundDance
{
    static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
    static List<int> visited;

    static void Main()
    {
        visited = new List<int>();

        int lead = Input();
        int longest = FindLongestPath(lead);
        Console.WriteLine(longest);
    }

    private static int Input()
    {
        int f = int.Parse(Console.ReadLine());
        int lead = int.Parse(Console.ReadLine());

        for(int i = 0; i < f; i++)
        {
            string line = Console.ReadLine();
            int parent = int.Parse(line.Split(' ')[0]);
            int child = int.Parse(line.Split(' ')[1]);

            if(!graph.ContainsKey(parent))
            {
                graph[parent] = new List<int>();
            }
            graph[parent].Add(child);

            if (!graph.ContainsKey(child))
            {
                graph[child] = new List<int>();
            }
            graph[child].Add(parent);
        }

        return lead;
    }

    private static int FindLongestPath(int node)
    {
        if(!visited.Contains(node))
        {
            visited.Add(node);

            List<int> children = graph[node];
            int longest = 0;
            foreach (int i in children)
            {
                int current = FindLongestPath(i);
                if(current > longest)
                {
                    longest = current;
                }
            }
            return 1 + longest;
        }

        return 0;
    }
}