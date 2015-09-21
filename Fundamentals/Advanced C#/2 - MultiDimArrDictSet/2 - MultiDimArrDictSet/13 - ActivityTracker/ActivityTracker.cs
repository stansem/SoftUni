using System;
using System.Collections.Generic;
using System.Linq;

class ActivityTracker
{
    static SortedDictionary<int, SortedDictionary<string, int>> dict = new SortedDictionary<int, SortedDictionary<string, int>>();

    static void Main()
    {
        InputActivity();
        OutputActivity();
    }

        
    static void InputActivity()
    {
        int n = int.Parse(Console.ReadLine());

        for(int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            string[] input = line.Split(' ');
            int month = int.Parse(input[0].Split('/')[1]);
            string user = input[1];
            int distance = int.Parse(input[2]);

            SortedDictionary<string, int> users;
            if (!dict.TryGetValue(month, out users))
            {
                users = new SortedDictionary<string, int>();
                dict.Add(month, users);
            }

            if(!dict[month].ContainsKey(user))
            {
                dict[month].Add(user, 0);
            }
            dict[month][user] += distance;
        }
    }

    static void OutputActivity()
    {
        foreach(var kv in dict)
        {
            Console.Write(kv.Key + ": ");
            List<string> l = new List<string>();
            foreach (var users in kv.Value)
            {
               l.Add(string.Format("{0}({1})", users.Key, users.Value));
            }
            Console.WriteLine(string.Join(", ", l));
        }
    }
}

