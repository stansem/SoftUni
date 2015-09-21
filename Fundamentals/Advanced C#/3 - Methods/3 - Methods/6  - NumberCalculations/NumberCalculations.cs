using System;
using System.Collections.Generic;


class NumberCalculations
{
    static void Main()
    {
        double[] arr = { 1.4, 2.5, 3.6, 4.7, 5.8 };
        decimal[] arr1 = { 1.45m, 2.55m, 3.65m, 4.75m, 5.85m };

        Console.WriteLine(Max(arr));
        Console.WriteLine(Min(arr));
        Console.WriteLine(Sum(arr));
        Console.WriteLine(Average(arr));
        Console.WriteLine(Product(arr));

        Console.WriteLine();
        Console.WriteLine(Max(arr1));
        Console.WriteLine(Min(arr1));
        Console.WriteLine(Sum(arr1));
        Console.WriteLine(Average(arr1));
        Console.WriteLine(Product(arr1));
    }

    static double Max(double[] arr)
    {
        double max = double.MinValue;

        foreach(double d in arr)
        {
            if(d > max)
            {
                max = d;
            }
        }

        return max;
    }

    static double Min(double[] arr)
    {
        double min = double.MaxValue;

        foreach (double d in arr)
        {
            if (d < min)
            {
                min = d;
            }
        }

        return min;
    }

    static double Sum(double[] arr)
    {
        double sum = 0;

        foreach (double d in arr)
        {
            sum += d;
        }

        return sum;
    }

    static double Average(double[] arr)
    {
        return Sum(arr) / arr.Length;
    }

    static double Product(double[] arr)
    {
        double prod = 1;

        foreach (double d in arr)
        {
            prod *= d;
        }

        return prod;
    }


    static decimal Max(decimal[] arr)
    {
        decimal max = decimal.MinValue;

        foreach (decimal d in arr)
        {
            if (d > max)
            {
                max = d;
            }
        }

        return max;
    }

    static decimal Min(decimal[] arr)
    {
        decimal min = decimal.MaxValue;

        foreach (decimal d in arr)
        {
            if (d < min)
            {
                min = d;
            }
        }

        return min;
    }

    static decimal Sum(decimal[] arr)
    {
        decimal sum = 0;

        foreach (decimal d in arr)
        {
            sum += d;
        }

        return sum;
    }

    static decimal Average(decimal[] arr)
    {
        return Sum(arr) / arr.Length;
    }

    static decimal Product(decimal[] arr)
    {
        decimal prod = 1;

        foreach (decimal d in arr)
        {
            prod *= d;
        }

        return prod;
    }
}
