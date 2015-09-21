using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class ToTheStars
{
    static Dictionary<string, Tuple<double, double>> stars = new Dictionary<string, Tuple<double, double>>();
    static double x = 0, y = 0;
    static int moves = 0;

    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");

        Input();
        Travel();
    }

    static void Input()
    {
        for(int i = 0; i < 3; i++)
        {
            string[] data = Console.ReadLine().Split(' ');
            string name = data[0];
            double x = double.Parse(data[1]);
            double y = double.Parse(data[2]);

            stars.Add(name, new Tuple<double, double>(x, y));
        }

        string[] coords = Console.ReadLine().Split(' ');
        x = double.Parse(coords[0]);
        y = double.Parse(coords[1]);
        moves = int.Parse(Console.ReadLine());
    }

    static void Travel()
    {
        for(int i = 0; i <= moves; i++)
        {
            bool found = false;
            foreach(var kv in stars)
            {
                var startX = kv.Value.Item1 - 1;
                var endX = kv.Value.Item1 + 1;
                var startY = kv.Value.Item2 - 1;
                var endY = kv.Value.Item2 + 1;

                if (x >= startX && x <= endX && y >= startY && y <= endY)
                {
                    Console.WriteLine(kv.Key.ToLower());
                    found = true;
                }
            }

            if(!found)
            {
                Console.WriteLine("space");
            }

            y++;
        }
    }
}
