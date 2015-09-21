using System.Collections.Generic;

public interface IProductCollection
{
    void Add(int id, string title, string supplier, double price);
    bool Remove(int id);
    int Count { get; }

    IEnumerable<Product> FindByTitle(string title);
    IEnumerable<Product> FindByTitleAndPrice(string title, double price);
    IEnumerable<Product> FindBySupplierAndPrice(string supplier, double price);
    IEnumerable<Product> FindByPriceRange(double start, double end);
    IEnumerable<Product> FindByTitleAndPriceRange(string title, double start, double end);
    IEnumerable<Product> FindBySupplierAndPriceRange(string supplier, double start, double end);
}
