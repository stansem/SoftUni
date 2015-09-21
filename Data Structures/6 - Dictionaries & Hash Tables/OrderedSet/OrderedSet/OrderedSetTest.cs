using System;

class BinarySearchTreeExample
{
    static void Main()
    {
        BinarySearchTree<string> tree =
            new BinarySearchTree<string>();
        tree.Insert("Telerik");
        tree.Insert("Google");
        tree.Insert("Microsoft");
        tree.Insert("ATNT");
        tree.Insert("Blizoo");
        tree.Insert("MTel");
        tree.Insert("ZaraLab");
        tree.Insert("Yahoo");
        tree.PrintTreeDFS(); // Google Microsoft Telerik
        Console.WriteLine(tree.Contains("Telerik")); // True
        Console.WriteLine(tree.Contains("IBM")); // False
        tree.Remove("Telerik");
        Console.WriteLine(tree.Contains("Telerik")); // False
        tree.PrintTreeDFS(); // Google Microsoft
    }
}

