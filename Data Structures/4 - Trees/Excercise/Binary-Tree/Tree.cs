using System;
using System.Collections.Generic;

public class Tree<T>
{
    public T Value { get; set; }
    public List<Tree<T>> Children { get; set; }

    public Tree(T value, params Tree<T>[] children)
    {
        Value = value;
        Children = new List<Tree<T>>();

        foreach(Tree<T> t in children)
        {
            Children.Add(t);
        }
    }

    public void Print(int indent = 0)
    {
        Console.WriteLine(new string(' ', 2 * indent) + Value);

        foreach(Tree<T> t in Children)
        {
            t.Print(indent + 1);
        }
    }

    public void Each(Action<T> action)
    {
        action(Value);

        foreach (Tree<T> t in Children)
        {
            t.Each(action);
        }
    }

    public Tree<T> FindSubtree(T value)
    {
        if(Value.Equals(value)) return this;

        foreach (Tree<T> t in Children)
        {
            Tree<T> t2 = t.FindSubtree(value);
            if(t2 != null) return t2;
        }

        return null;
    }

    public void GetLeaves(ref SortedSet<T> set)
    {
        if (Children.Count == 0)
        {
            set.Add(Value);
        }
        else
        {
            foreach (Tree<T> t in Children)
            {
                t.GetLeaves(ref set);
            }
        }
    }

    public void GetMiddleNodes(ref SortedSet<T> set, int depth = 0)
    {
        if (Children.Count > 0)
        {
            if (depth > 0)
            {
                set.Add(Value);
            }

            foreach (Tree<T> t in Children)
            {
                t.GetMiddleNodes(ref set, depth + 1);
            }
        }
    }

    public void GetLongestPath(ref List<T> longestPath, List<T> currentPath = null)
    {
        if (currentPath == null)
        {
            currentPath = new List<T>();
        }
        else
        {
            currentPath = new List<T>(currentPath);
        }

        currentPath.Add(Value);

        if (Children.Count == 0)
        {
            if(currentPath.Count > longestPath.Count)
            {
                longestPath = currentPath;
            }
        }
        else
        {
            foreach (Tree<T> t in Children)
            {
                t.GetLongestPath(ref longestPath, currentPath);
            }
        }
    }

    public void FindPathsWithSumP(int p, ref List<List<T>> paths, int sum = 0, List<T> currentPath = null)
    {
        if (currentPath == null)
        {
            currentPath = new List<T>();
        }
        else
        {
            currentPath = new List<T>(currentPath);
        }

        currentPath.Add(Value);
        sum += int.Parse(Value.ToString());

        if (sum == p)
        {
            paths.Add(currentPath);
        }
        else
        {
            foreach (Tree<T> t in Children)
            {
                t.FindPathsWithSumP(p, ref paths, sum, currentPath);
            }
        }
    }

    public int FindTreesWithSumP(int p, ref List<Tree<T>> paths, int sum = 0)
    {
        if (Children.Count == 0)
        {
            return int.Parse(Value.ToString());
        }
        else
        {
            sum = int.Parse(Value.ToString());

            foreach (Tree<T> t in Children)
            {
                sum += t.FindTreesWithSumP(p, ref paths, sum);
            }

            if(sum == p)
            {
                paths.Add(this);
            }
            return sum;
        }
    }
}
