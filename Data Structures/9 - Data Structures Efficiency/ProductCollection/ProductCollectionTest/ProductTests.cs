using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


[TestClass]
public class UnitTest1
{
    private IProductCollection products;

    [TestInitialize]
    public void TestInitialize()
    {
        products = new ProductCollection();
    }

    [TestMethod]
    public void AddProduct_ShouldWorkCorrectly()
    {
        // Arrange

        // Act
        this.products.Add(12, "Sirenye", "Yulievo", 9.99);

        // Assert
        Assert.AreEqual(1, products.Count);
    }

    [TestMethod]
    public void FindProduct_ExistingPerson_ShouldReturnProduct()
    {
        // Arrange
        this.products.Add(10, "Hlyab", "Dobrodja", 0.99);

        // Act
        var person = products.FindByTitle("Hlyab");

        // Assert
        Assert.IsNotNull(person);
    }

    [TestMethod]
    public void DeletePerson_ShouldWorkCorrectly()
    {
        // Arrange
        this.products.Add(10, "Hlyab", "Dobrodja", 0.99);

        // Act
        var isDeletedExisting =
            this.products.Remove(10);
        var isDeletedNonExisting =
            this.products.Remove(10);

        // Assert
        Assert.IsTrue(isDeletedExisting);
        Assert.IsFalse(isDeletedNonExisting);
        Assert.AreEqual(0, products.Count);
    }
}

