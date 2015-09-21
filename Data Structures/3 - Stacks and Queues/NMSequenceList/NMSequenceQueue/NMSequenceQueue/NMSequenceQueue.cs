using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Item
{
    public int Value { get; set; }
    public Item Prev { get; set; }

    public Item(int value, Item prev)
    {
        Value = value;
        Prev = prev;
    }
}

class NMSequenceQueue
{
    static void Main()
    {
        int n = 3;
        int m = 10;

        Item mItem = FindM(n, m);

        PrintSequence(mItem);
    }

    static Item FindM(int n, int m)
    {
        if(m < n)
        {
            throw new InvalidOperationException("M must be larger than N!");
        }

        Queue<Item> q = new Queue<Item>();

        Item item = new Item(n, null);
        q.Enqueue(item);

        while(true)
        {
            item = q.Dequeue();
            if (item.Value == m) return item;

            q.Enqueue(new Item(item.Value + 1, item));
            q.Enqueue(new Item(item.Value + 2, item));
            q.Enqueue(new Item(item.Value * 2, item));
        }
    }

    static void PrintSequence(Item item)
    {
        while(item != null)
        {
            Console.WriteLine(item.Value);
            item = item.Prev;
        }
    }
}
