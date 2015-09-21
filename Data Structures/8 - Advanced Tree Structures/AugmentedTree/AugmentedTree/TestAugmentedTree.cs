using System;
using System.Collections.Generic;

class TestAugmentedTree
{
    static void Main()
    {
        AugmentedTree<int> tree = new AugmentedTree<int>();
        tree.Insert(1, 10);
        tree.Insert(19, 20);
        tree.Insert(0, 2);
        tree.Insert(-1, 4);
        tree.Insert(4, 11);
        tree.Insert(30, 60);

        Console.WriteLine(tree.Search(5, 11));
    }
}

