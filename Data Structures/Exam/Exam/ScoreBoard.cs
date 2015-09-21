using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class Score : IComparable<Score>
{
    public int Points { get; set; }

    public int CompareTo(Score other)
    {
        return -1 * Points.CompareTo(other.Points);
    }
}

class ScoreBoard
{
    Dictionary<string, string> users = new Dictionary<string, string>();
    Dictionary<string, string> games = new Dictionary<string, string>();
    Dictionary<string, SortedDictionary<Score, OrderedBag<string>>> scoreboard = new Dictionary<string, SortedDictionary<Score, OrderedBag<string>>>();

    public void AddUser(string username, string password)
    {
        if(!users.ContainsKey(username))
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
            if(games[name] == password)
            {
                games.Remove(name);
                scoreboard.Remove(name);
                Console.WriteLine("Game daleted");
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
        if(users.ContainsKey(username) && games.ContainsKey(game))
        {
            if(users[username] == userPass && games[game] == gamePass)
            {
                Score sc = new Score() { Points = score };
                scoreboard.EnsureKeyExists(game);
                scoreboard[game].EnsureKeyExists(sc);
                
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
        if(games.ContainsKey(game))
        {
            if(scoreboard.ContainsKey(game))
            {
                int cnt = 1;
                foreach(var dict in scoreboard[game])
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
        Console.WriteLine("TODO");
    }

    public void ProcessLine(string line)
    {
        string[] el = line.Split(' ');

        switch(el[0])
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
                Console.WriteLine("Invalid command");
            break;
        }
    }
}

