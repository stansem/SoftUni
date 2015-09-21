using System.IO;
using System.Linq;
using System.Text;
using System;

public static class CountSubstringsBuffer
{
    /*
    static void Main()
    {
        DateTime start = DateTime.Now;

        // Read the input list of words
        string[] wordsOriginal = File.ReadAllLines("words.txt");
        string[] wordsLowercase =
            wordsOriginal.Select(w => w.ToLower()).ToArray();

        // Process the file char by char
        int[] occurrences = new int[wordsLowercase.Length];
        StringBuilder buffer = new StringBuilder();
        using (StreamReader text = File.OpenText("text.txt"))
        {
            int nextChar;
            while ((nextChar = text.Read()) != -1)
            {
                char ch = (char)nextChar;
                if (char.IsLetter(ch))
                {
                    // A letter is found --> check all words for matches
                    ch = char.ToLower(ch);
                    buffer.Append(ch);
                    for (int i = 0; i < wordsLowercase.Length; i++)
                    {
                        string word = wordsLowercase[i];
                        if (buffer.EndsWith(word))
                        {
                            occurrences[i]++;
                        }
                    }
                }
                else
                {
                    // A non-letter is found --> clean the buffer
                    buffer.Clear();
                }
            }
        }

        // Print the result
        using (StreamWriter result = File.CreateText("result2.txt"))
        {
            for (int i = 0; i < wordsOriginal.Length; i++)
            {
                result.WriteLine("{0} --> {1}",
                    wordsOriginal[i], occurrences[i]);
            }
        }

        Console.WriteLine(DateTime.Now - start);
    }
    */
    static bool EndsWith(this StringBuilder buffer, string str)
    {
        if (buffer.Length < str.Length)
        {
            return false;
        }
        for (int bufIndex = buffer.Length - str.Length, strIndex = 0;
            strIndex < str.Length;
            bufIndex++, strIndex++)
        {
            if (buffer[bufIndex] != str[strIndex])
            {
                return false;
            }
        }
        return true;
    }
}