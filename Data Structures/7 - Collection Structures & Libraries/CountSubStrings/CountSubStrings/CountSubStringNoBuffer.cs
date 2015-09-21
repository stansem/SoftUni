using System.IO;
using System.Linq;
using System.Text;
using System;

public static class CountSubstringsNoBuffer
{
    static void Main()
    {
        DateTime start = DateTime.Now;

        // Read the input list of words
        string[] wordsOriginal = File.ReadAllLines("words.txt");
        string[] wordsLowercase =
            wordsOriginal.Select(w => w.ToLower()).ToArray();

        // Process the file char by char
        int[] occurrences = new int[wordsLowercase.Length];
        using (StreamReader text = File.OpenText("text.txt"))
        {
            char[] textArr = text.ReadToEnd().ToLower().ToCharArray();

            for (int j = 0; j < wordsLowercase.Length; j++)
            {
                string word = wordsLowercase[j];
                for(int i = 0; i < textArr.Length - word.Length + 1; i++)
                {
                    int cnt = 1;
                    for(int k = 0; k < word.Length; k++)
                    {
                        if(textArr[i + k] != word[k])
                        {
                            cnt = 0;
                            break;
                        }
                    }

                    if(cnt == 1)
                    {
                        occurrences[j]++;
                    }
                }
            }
        }

        // Print the result
        using (StreamWriter result = File.CreateText("result.txt"))
        {
            for (int i = 0; i < wordsOriginal.Length; i++)
            {
                result.WriteLine("{0} --> {1}",
                    wordsOriginal[i], occurrences[i]);
            }
        }

        Console.WriteLine(DateTime.Now - start);
    }
    
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