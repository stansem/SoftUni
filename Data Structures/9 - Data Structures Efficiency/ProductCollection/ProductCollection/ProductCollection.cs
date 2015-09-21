using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class Product : IComparable<Product>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Supplier { get; set; }
    public double Price { get; set; }

    public int CompareTo(Product other)
    {
        return Id.CompareTo(other.Id);
    }
}

public class ProductCollection : IProductCollection
{
    Dictionary<int, Product> idDict;
    Dictionary<string, SortedSet<Product>> titleDict;
    Dictionary<string, SortedSet<Product>> titlePriceDict;
    Dictionary<string, SortedSet<Product>> supplierPriceDict;
    OrderedDictionary<double, SortedSet<Product>> priceRangeDict;
    Dictionary<string, OrderedDictionary<double, SortedSet<Product>>> titlePriceRangeDict;
    Dictionary<string, OrderedDictionary<double, SortedSet<Product>>> supplierPriceRangeDict;
    
    public ProductCollection()
    {
        idDict = new Dictionary<int,Product>();
        titleDict = new Dictionary<string, SortedSet<Product>>();
        titlePriceDict = new Dictionary<string, SortedSet<Product>>();
        supplierPriceDict = new Dictionary<string, SortedSet<Product>>();
        priceRangeDict = new OrderedDictionary<double, SortedSet<Product>>();
        titlePriceRangeDict = new Dictionary<string, OrderedDictionary<double, SortedSet<Product>>>();
        supplierPriceRangeDict = new Dictionary<string, OrderedDictionary<double, SortedSet<Product>>>();
    }

    public int Count
    {
        get
        {
            return idDict.Count;
        }
    }

    public void Add(int id, string title, string supplier, double price)
    {
        Remove(id);

        Product p = new Product { Id = id, Title = title, Supplier = supplier, Price = price };

        idDict.Add(id, p);

        titleDict.AppendValueToKey(title, p);

        string titlePrice = title + "|" + price;
        titlePriceDict.AppendValueToKey(titlePrice, p);

        string supplierPrice = supplier + "|" + price;
        supplierPriceDict.AppendValueToKey(supplierPrice, p);

        priceRangeDict.AppendValueToKey(price, p);

        titlePriceRangeDict.EnsureKeyExists(title);
        titlePriceRangeDict[title].AppendValueToKey(price, p);

        supplierPriceRangeDict.EnsureKeyExists(supplier);
        supplierPriceRangeDict[supplier].AppendValueToKey(price, p);
    }

    public bool Remove(int id)
    {
        if (idDict.ContainsKey(id))
        {
            Product p =  idDict[id];

            idDict.Remove(id);
            titleDict[p.Title].Remove(p);
            titlePriceDict[p.Title + "|" + p.Price].Remove(p);
            supplierPriceDict[p.Supplier + "|" + p.Price].Remove(p);
            priceRangeDict[p.Price].Remove(p);
            titlePriceRangeDict[p.Title][p.Price].Remove(p);
            supplierPriceRangeDict[p.Supplier][p.Price].Remove(p);

            return true;
        }

        return false;
    }

    public IEnumerable<Product> FindByTitle(string title)
    {
        return titleDict.GetValuesForKey(title);
    }

    public IEnumerable<Product> FindByTitleAndPrice(string title, double price)
    {
        return titleDict.GetValuesForKey(title + "|" + price);
    }

    public IEnumerable<Product> FindBySupplierAndPrice(string supplier, double price)
    {
        return titleDict.GetValuesForKey(supplier + "|" + price);
    }

    public IEnumerable<Product> FindByPriceRange(double start, double end)
    {
        var range = priceRangeDict.Range(start, true, end, true);

        foreach(var dict in range)
        {
            foreach(var p in dict.Value)
            {
                yield return p;
            }
        }
    }

    public IEnumerable<Product> FindByTitleAndPriceRange(string title, double start, double end)
    {
        if(titlePriceRangeDict.ContainsKey(title))
        {
            var range = titlePriceRangeDict[title].Range(start, true, end, true);

            foreach (var dict in range)
            {
                foreach (var p in dict.Value)
                {
                    yield return p;
                }
            }
        }

        yield break;
    }

    public IEnumerable<Product> FindBySupplierAndPriceRange(string supplier, double start, double end)
    {
        if (supplierPriceRangeDict.ContainsKey(supplier))
        {
            var range = supplierPriceRangeDict[supplier].Range(start, true, end, true);

            foreach (var dict in range)
            {
                foreach (var p in dict.Value)
                {
                    yield return p;
                }
            }
        }

        yield break;
    }
}
