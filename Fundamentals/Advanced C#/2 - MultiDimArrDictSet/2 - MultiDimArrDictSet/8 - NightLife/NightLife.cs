using System;
using System.Collections.Generic;
using System.Linq;

class NightLife
{
    static Dictionary<string, SortedDictionary<string, SortedSet<string>>> dict =
            new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();

    static void Main()
    {
        InputData();
        PrintData();
    }

    static void InputData()
    {
        string line;
        while((line = Console.ReadLine()) != "END")
        {
            string[] arr = line.Split(';');
            string city = arr[0];
            string venue = arr[1];
            string performer = arr[2];

            SortedDictionary<string, SortedSet<string>> venues;
            if (!dict.TryGetValue(city, out venues))
            {
                venues = new SortedDictionary<string, SortedSet<string>>();
                dict.Add(city, venues);
            }

            SortedSet<string> performers;
            if(!dict[city].TryGetValue(venue, out performers))
            {
                performers = new SortedSet<string>();
                dict[city].Add(venue, performers);
            }

            dict[city][venue].Add(performer);
        }
    }

    static void PrintData()
    {
        foreach(var city in dict)
        {
            Console.WriteLine(city.Key);

            foreach(var venue in city.Value)
            {
                Console.WriteLine("->{0}: {1}", venue.Key, string.Join(", ", venue.Value));
            }
        }
    }
}