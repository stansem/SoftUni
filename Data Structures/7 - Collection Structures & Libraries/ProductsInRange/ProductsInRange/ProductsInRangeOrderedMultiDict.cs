using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using Wintellect.PowerCollections;

namespace ProductsInRange
{
    class ProductsInRangeMultiDict
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

            int n = 500000;
            Random r = new Random();

            OrderedMultiDictionary<double, string> dict = new OrderedMultiDictionary<double, string>(true);

            DateTime start = DateTime.Now;

            for (int i = 0; i < n; i++)
            {
                int rnd = r.Next(1, 10000);
                string name = "prod-" + rnd + "-" + r.Next(1, 100);
                double price = rnd;

                dict.Add(price, name);
            }

            for (int i = 0; i < 10000; i++)
            {
                int rnd = r.Next(1, 10000);
                int rnd2 = r.Next(rnd, 10000);

                double minPrice = rnd;
                double maxPrice = rnd2;
                var subProducts = dict.Range(minPrice, true, maxPrice, true);                

                int cnt = 0;
                foreach (var kv in subProducts)
                {
                    foreach(string name in kv.Value)
                    {
                        if (cnt == 20) break;

                        //Console.WriteLine("{0} {1}", kv.Key, name);

                        cnt++;
                    }
                }
            }

            Console.WriteLine(DateTime.Now - start);
        }
    }
}
