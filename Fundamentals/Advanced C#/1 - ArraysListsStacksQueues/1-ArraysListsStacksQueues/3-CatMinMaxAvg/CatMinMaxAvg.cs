using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class CatMinMaxAvg
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");

        double[] arr = Console.ReadLine().Split(' ').Select(x => double.Parse(x)).ToArray();

        List<double> round = new List<double>();
        List<double> nonRound = new List<double>();

        double rMin = double.MaxValue, rMax = double.MinValue, rAvg = 0, rSum = 0, nrMin = double.MaxValue, nrMax = double.MinValue, nrAvg = 0, nrSum = 0;

        foreach(double d in arr)
        {
            if(d % 1 == 0)
            {
                round.Add(d);
                rSum += d;
                if (d > rMax) rMax = d;
                if (d < rMin) rMin = d;
            }
            else
            {
                nonRound.Add(d);
                nrSum += d;
                if (d > nrMax) nrMax = d;
                if (d < nrMin) nrMin = d;
            }
        }

        rAvg = rSum / round.Count;
        nrAvg = nrSum / nonRound.Count;

        Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:0.00}", string.Join(", ", nonRound), nrMin, nrMax, nrSum, nrAvg);
        Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:0.00}", string.Join(", ", round), rMin, rMax, rSum, rAvg);

    }
}
