using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    static List<List<int>> Graph;
    static bool[] visited;

    public static void Main()
    {
        Graph = new List<List<int>>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            List<int> list = line.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();

            Graph.Add(list);
        }
        
        InitialiseVisited();
        ShowComponents();
    }

    private static void ShowComponents()
    {
        for (int i = 0; i < Graph.Count; i++)
        {
            if (!visited[i])
            {
                Console.Write("Connected component:");
                DFS(i);
                Console.WriteLine();
            }
        }
    }
   
    private static void InitialiseVisited()
    {
        int length = Graph.Count;
        visited = new bool[length];

        for(int i = 0; i < length; i++)
        {
            visited[i] = false;
        }
    }

    private static void DFS(int node)
    {
        if(!visited[node])
        {
            visited[node] = true;
            
            foreach(int n in Graph[node])
            {
                DFS(n);
            }

            Console.Write(" " + node);
        }
    }
}
