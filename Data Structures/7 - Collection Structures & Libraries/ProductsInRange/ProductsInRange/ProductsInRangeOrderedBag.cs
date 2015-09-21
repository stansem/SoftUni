using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using Wintellect.PowerCollections;

namespace ProductsInRange
{
    class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public int CompareTo(Product other)
        {
            int cmp = Price.CompareTo(other.Price);

            if(cmp == 0)
            {
                return Name.CompareTo(other.Name);
            }

            return cmp;
        }
    }

    class ProductsInRangeOrderedBag
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

            int n = 500000;
            Random r = new Random();

            OrderedSet<Product> bag = new OrderedSet<Product>();

            DateTime start = DateTime.Now;

            for(int i = 0; i < n; i++)
            {
                int rnd = r.Next(1, 10000);
                string name = "prod-" + rnd + "-" + r.Next(1, 100);
                double price = rnd;

                Product p = new Product() { Name = name, Price = price };
                bag.Add(p);
            }

            Console.WriteLine("Generated: " + (DateTime.Now - start));



            for(int i = 0; i < 10000; i++)
            {
                int rnd = r.Next(1, 10000);
                int rnd2 = r.Next(rnd, 10000);

                double minPrice = rnd;
                double maxPrice = rnd2;
                Product minProduct = new Product() { Price = minPrice, Name = "aaa" };
                Product maxProduct = new Product() { Price = maxPrice, Name = "zzz" };
                var subProducts = bag.Range(minProduct, true, maxProduct, true);

                Console.WriteLine("Subrange " + i  + ": " + (DateTime.Now - start));


                int cnt = 0;
                foreach (Product p in subProducts)
                {
                    if (cnt == 20) break;

                    //Console.WriteLine("{0} {1}", p.Price, p.Name);

                    cnt++;
                }
            }

            Console.WriteLine(DateTime.Now - start);
        }
    }
}
