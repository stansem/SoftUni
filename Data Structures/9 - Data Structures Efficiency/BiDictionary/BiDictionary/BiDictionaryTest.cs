using System;
using System.Collections.Generic;

class BiDictionaryTest
{
    public static void Main()
    {
        var distances = new BiDictionary<string, string, int>();
        distances.Add("Sofia", "Varna", 443);
        distances.Add("Sofia", "Varna", 468);
        distances.Add("Sofia", "Varna", 490);
        distances.Add("Sofia", "Plovdiv", 145);
        distances.Add("Sofia", "Bourgas", 383);
        distances.Add("Plovdiv", "Bourgas", 253);
        distances.Add("Plovdiv", "Bourgas", 292);

        var distancesFromSofia = distances.FindByKey1("Sofia"); // [443, 468, 490, 145, 383]
        foreach(int i in distancesFromSofia)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        var distancesToBourgas = distances.FindByKey2("Bourgas"); // [383, 253, 292]
        foreach (int i in distancesToBourgas)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        var distancesPlovdivBourgas = distances.Find("Plovdiv", "Bourgas"); // [253, 292]
        foreach (int i in distancesPlovdivBourgas)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        var distancesRousseVarna = distances.Find("Rousse", "Varna"); // []
        foreach (int i in distancesRousseVarna)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        var distancesSofiaVarna = distances.Find("Sofia", "Varna"); // [443, 468, 490]
        foreach (int i in distancesSofiaVarna)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        Console.WriteLine(distances.Remove("Sofia", "Varna")); // true
        Console.WriteLine(distances.Remove("Sofia", "Varna")); // false
        var distancesFromSofiaAgain = distances.FindByKey1("Sofia"); // [145, 383]
        foreach (int i in distancesFromSofiaAgain)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        var distancesToVarna = distances.FindByKey2("Varna"); // []
        foreach (int i in distancesToVarna)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        var distancesSofiaVarnaAgain = distances.Find("Sofia", "Varna"); // []
        foreach (int i in distancesSofiaVarnaAgain)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}
