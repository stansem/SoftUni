using System;
using System.Collections.Generic;
using System.Text;

class StringBuilderTest
{
    private static StringBuilder se = new StringBuilder();
    
    public static void Main()
    {
        List<string> lines = new List<string>();

        for (int i = 0; i < 100000; i++)
        {
            lines.Add("APPEND pesho");
            lines.Add("APPEND 123");
            lines.Add("APPEND 123");
            lines.Add("INSERT 0 456");
            lines.Add("INSERT 0 456");
            lines.Add("DELETE 1 2");
            lines.Add("DELETE 100 200");
            //lines.Add("PRINT");
            lines.Add("REPLACE 1 5 kiro");
            lines.Add("REPLACE 700 800 hi");
            lines.Add("APPEND Hello C#");
            //lines.Add("PRINT");
        }

        DateTime start = DateTime.Now;


        foreach (string line in lines)
        {
            string operation = line.Split(' ')[0];
            string text = "";
            if (operation != "PRINT")
            {
                text = line.Substring(operation.Length + 1);
            }

            ExecuteOperation(operation, text);
        }

        //ExecuteOperation("PRINT", "");

        Console.WriteLine(DateTime.Now - start);
    }
    

    private static void ExecuteOperation(string operation, string text)
    {
        switch (operation)
        {
            case "APPEND":
                se.Append(text);
            break;

            case "INSERT":
                string index = text.Split(' ')[0];
                string finalText = text.Substring(index.Length + 1);
                int finalIndex = int.Parse(index);

                se.Insert(finalIndex, finalText);
            break;

            case "DELETE":
                int start = int.Parse(text.Split(' ')[0]);
                int count = int.Parse(text.Split(' ')[1]);

                try
                {
                    se.Remove(start, count);
                }
                catch (Exception e) { }

            break;

            case "REPLACE":
                string startReplace = text.Split(' ')[0];
                string countReplace = text.Substring(startReplace.Length + 1);
                string textReplace = countReplace.Substring(countReplace.Split(' ')[0].Length + 1);
                int finalStartReplace = int.Parse(startReplace);
                int finalCountReplace = int.Parse(countReplace.Split(' ')[0]);

                try
                {
                    se.Remove(finalStartReplace, finalCountReplace);
                    se.Insert(finalStartReplace, textReplace);
                }
                catch (Exception e) { }
            break;

            case "PRINT":
                Console.WriteLine(se.ToString());
            break;
        }
    }
}
