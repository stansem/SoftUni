using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class StringEditor
{
    BigList<char> rope;

    public StringEditor()
    {
        rope = new BigList<char>();
    }

    public bool Append(string text)
    {
        for (int i = 0; i < text.Length; i++ )
        {
            rope.Add(text[i]);
        }

        return true;
    }

    public bool Insert(string text, int position)
    {
        if (position <= rope.Count)
        {
            for (int i = 0; i < text.Length; i++)
            {
                rope.Insert(position + i, text[i]);
            }

            return true;
        }

        return false;
    }

    public bool Delete(int start, int count)
    {
        if (start + count <= rope.Count)
        {
            for (int i = 0; i < count; i++)
            {
                rope.RemoveAt(start);
            }
            return true;
        }

        return false;
    }

    public bool Replace(int start, int count, string text)
    {
        if(Delete(start, count))
        {
            Insert(text, start);
            return true;
        }

        return false;
    }

    public string Print()
    {
        return rope.ToString();
    }
}

