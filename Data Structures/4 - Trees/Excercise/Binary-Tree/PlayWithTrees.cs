using System;
using System.Collections.Generic;

class PlayWithTrees
{
    static void Main()
    {
        BinaryTree<int> b = new BinaryTree<int>(1, 
                    new BinaryTree<int>(2,
                            new BinaryTree<int>(3),
                            new BinaryTree<int>(4)),
                    new BinaryTree<int>(5,
                            new BinaryTree<int>(6)));


        Console.WriteLine(b.CheckCount());

        /*
        Tree<int> tree = GenerateTree();
        tree.Print();

        Console.WriteLine("Root Node: " + tree.Value);

        Console.WriteLine("Leaves: ");
        SortedSet<int> leaves = new SortedSet<int>();
        tree.GetLeaves(ref leaves);

        foreach(int i in leaves)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("\n----------\n\n Middle Nodes: ");
        SortedSet<int> middleNodes = new SortedSet<int>();
        tree.GetMiddleNodes(ref middleNodes);

        foreach (int i in middleNodes)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("\n----------\n\n Longest Path: ");
        List<int> longestPath = new List<int>();
        tree.GetLongestPath(ref longestPath);

        foreach (int i in longestPath)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("\n----------\n\n Sum P paths: ");
        List<List<int>> paths = new List<List<int>>();
        tree.FindPathsWithSumP(16, ref paths);

        foreach (List<int> list in paths)
        {
            foreach(int i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\n----------\n\n Sum P Subtrees: ");
        List<Tree<int>> trees = new List<Tree<int>>();
        tree.FindTreesWithSumP(24, ref trees);

        foreach (Tree<int> t in trees)
        {
            t.Print();
        }
        */
    }

    static Tree<int> GenerateTree()
    {
        Tree<int> tree = new Tree<int>(0);

        int n = int.Parse(Console.ReadLine());

        for(int i = 0; i < n - 1; i++)
        {
            string line = Console.ReadLine();
            int parentValue = int.Parse(line.Split(' ')[0]);
            int childValue = int.Parse(line.Split(' ')[1]);

            Tree<int> parent;
            Tree<int> child = new Tree<int>(childValue);

            if(i == 0)
            {
                parent = new Tree<int>(parentValue);
                tree = parent;
            }
            else
            {
                parent = tree.FindSubtree(parentValue);
            }

            parent.Children.Add(child);
        }

        return tree;
    }
}
