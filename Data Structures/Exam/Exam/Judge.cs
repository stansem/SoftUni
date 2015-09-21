using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class ScoreBoardMain1
{
    static void Main(string[] args)
    {
        ScoreBoard1 s = new ScoreBoard1();
        string line;

        while ((line = Console.ReadLine()) != "End")
        {
            s.ProcessLine(line);
        }
    }
}

public static class DictionaryExtensions1
{
    /// <summary>
    /// Ensures the specified key exists in the dictionary.
    /// If the key does not exist, it is mapped to a new empty value.
    /// </summary>
    public static void EnsureKeyExists1<TKey, TValue>(
        this IDictionary<TKey, TValue> dict, TKey key)
        where TValue : new()
    {
        if (!dict.ContainsKey(key))
        {
            dict.Add(key, new TValue());
        }
    }

    public static void AppendValueToKey<TKey, TCollection, TValue>(
        this IDictionary<TKey, TCollection> dict, TKey key, TValue value)
        where TCollection : ICollection<TValue>, new()
    {
        TCollection collection;
        if (!dict.TryGetValue(key, out collection))
        {
            collection = new TCollection();
            dict.Add(key, collection);
        }
        collection.Add(value);
    }
}

class Score1 : IComparable<Score1>
{
    public int Points { get; set; }

    public int CompareTo(Score1 other)
    {
        return -1 * Points.CompareTo(other.Points);
    }
}

class ScoreBoard1
{
    Dictionary<string, string> users = new Dictionary<string, string>();
    Dictionary<string, string> games = new Dictionary<string, string>();
    Dictionary<string, SortedDictionary<Score1, OrderedBag<string>>> scoreboard = new Dictionary<string, SortedDictionary<Score1, OrderedBag<string>>>();
    Dictionary<string, SortedSet<string>> prefixes = new Dictionary<string, SortedSet<string>>();

    public void AddUser(string username, string password)
    {
        if (!users.ContainsKey(username))
        {
            users.Add(username, password);
            Console.WriteLine("User registered");
        }
        else
        {
            Console.WriteLine("Duplicated user");
        }
    }

    public void AddGame(string name, string password)
    {
        if (!games.ContainsKey(name))
        {
            games.Add(name, password);

            for (int i = 0; i < name.Length; i++)
            {
                string prefix = name.Substring(0, i + 1);

                SortedSet<string> set;
                if(!prefixes.TryGetValue(prefix, out set))
                {
                    set = new SortedSet<string>();
                    prefixes.Add(prefix, set);
                }
                set.Add(name);
            }
            Console.WriteLine("Game registered");
        }
        else
        {
            Console.WriteLine("Duplicated game");
        }
    }

    public void DeleteGame(string name, string password)
    {
        if (games.ContainsKey(name))
        {
            if (games[name] == password)
            {
                games.Remove(name);
                scoreboard.Remove(name);

                for (int i = 0; i < name.Length; i++)
                {
                    string prefix = name.Substring(0, i + 1);
                    prefixes[prefix].Remove(name);
                }

                Console.WriteLine("Game deleted");
            }
            else
            {
                Console.WriteLine("Cannot delete game");
            }
        }
        else
        {
            Console.WriteLine("Cannot delete game");
        }
    }


    public void AddScore(string username, string userPass, string game, string gamePass, int score)
    {
        if (users.ContainsKey(username) && games.ContainsKey(game))
        {
            if (users[username] == userPass && games[game] == gamePass)
            {
                Score1 sc = new Score1() { Points = score };
                scoreboard.EnsureKeyExists1(game);
                scoreboard[game].EnsureKeyExists1(sc);

                OrderedBag<string> collection;
                if (!scoreboard[game].TryGetValue(sc, out collection))
                {
                    collection = new OrderedBag<string>();
                    scoreboard[game].Add(sc, collection);
                }
                collection.Add(username);

                Console.WriteLine("Score added");
            }
            else
            {
                Console.WriteLine("Cannot add score");
            }
        }
        else
        {
            Console.WriteLine("Cannot add score");
        }
    }

    public void ShowScoreboard(string game)
    {
        if (games.ContainsKey(game))
        {
            if (scoreboard.ContainsKey(game))
            {
                int cnt = 1;
                foreach (var dict in scoreboard[game])
                {
                    if (cnt > 10) break;
                    foreach (var username in dict.Value)
                    {
                        if (cnt > 10) break;

                        Console.WriteLine("#{0} {1} {2}", cnt, username, dict.Key.Points);
                        cnt++;
                    }
                }
            }
            else
            {
                Console.WriteLine("No score");
            }
        }
        else
        {
            Console.WriteLine("Game not found");
        }
    }

    public void ListGamesByPrefix(string prefix)
    {
        SortedSet<string> gameNames;
        if(prefixes.TryGetValue(prefix, out gameNames))
        {
            if(gameNames.Count > 0)
            {
                int cnt = 0;

                List<string> prefixGames = new List<string>();
                foreach(string g in gameNames)
                {
                    prefixGames.Add(g);
                    if (cnt == 9) break;
                    cnt++;
                }

                Console.WriteLine(string.Join(", ", prefixGames));
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }

    public void ProcessLine(string line)
    {
        string[] el = line.Split(' ');
        
        switch (el[0])
        {
            case "RegisterUser":
                AddUser(el[1], el[2]);
                break;

            case "RegisterGame":
                AddGame(el[1], el[2]);
                break;

            case "DeleteGame":
                DeleteGame(el[1], el[2]);
                break;

            case "AddScore":
                AddScore(el[1], el[2], el[3], el[4], int.Parse(el[5]));
                break;

            case "ShowScoreboard":
                ShowScoreboard(el[1]);
                break;

            case "ListGamesByPrefix":
                ListGamesByPrefix(el[1]);
                break;

            default:
                //Console.WriteLine("Invalid command");
                break;
        }
    }
}



