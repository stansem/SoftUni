using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;
using System.Threading;

class Event : IComparable<Event>
{
    public DateTime Time { get; set; }
    public string Name { get; set; }

    public int CompareTo(Event other)
    {
        return Time.CompareTo(other.Time);
    }
}

class Events
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        int n = int.Parse(Console.ReadLine());
        OrderedBag<Event> events = new OrderedBag<Event>();

        for(int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            string eventName = line.Split('|')[0].Trim();
            DateTime eventDate = Convert.ToDateTime(line.Split('|')[1].Trim());

            Event e = new Event() { Time = eventDate, Name = eventName };
            events.Add(e);
        }
         
        int numRanges = int.Parse(Console.ReadLine());
        for(int i = 0; i < numRanges; i++)
        {
            string line = Console.ReadLine();
            DateTime startDate = Convert.ToDateTime(line.Split('|')[0].Trim());
            DateTime endDate = Convert.ToDateTime(line.Split('|')[1].Trim());

            Event e1 = new Event() { Time = startDate };
            Event e2 = new Event() { Time = endDate };

            var subEvents = events.Range(e1, true, e2, true);

            foreach(var e in subEvents)
            {
                Console.WriteLine("{0} | {1}", e.Name, e.Time);
            }

        }
    }
}

