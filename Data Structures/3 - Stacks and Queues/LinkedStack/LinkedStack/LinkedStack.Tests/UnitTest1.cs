using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTestsCircularQueue
{
    [TestMethod]
    public void PushEmptyStack()
    {
        // Arrange

        // Act        
        var stack = new LinkedStack<int>();

        stack.Push(5);

        // Assert
        Assert.AreEqual(1, stack.Count);
    }

    [TestMethod]
    public void PushPop_ShouldWorkCorrectly()
    {
        // Arrange
        var stack = new LinkedStack<string>();
        var element = "some value";

        // Act
        stack.Push(element);
        var elementFromQueue = stack.Pop();

        // Assert
        Assert.AreEqual(0, stack.Count);
        Assert.AreEqual(element, elementFromQueue);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void PopEmptyStack_ThrowsException()
    {
        // Arrange
        var stack = new LinkedStack<int>();

        // Act
        stack.Pop();

        // Assert: expect and exception
    }

    [TestMethod]
    public void PushPop100Elements_ShouldWorkCorrectly()
    {
        // Arrange
        var stack = new LinkedStack<int>();
        int numberOfElements = 1000;

        // Act
        for (int i = 0; i < numberOfElements; i++)
        {
            stack.Push(i);
        }

        // Assert
        for (int i = 0; i < numberOfElements; i++)
        {
            Assert.AreEqual(numberOfElements - i, stack.Count);
            var element = stack.Pop();
            Assert.AreEqual(numberOfElements - i - 1, element);
            Assert.AreEqual(numberOfElements - i - 1, stack.Count);
        }
    }

    [TestMethod]
    public void Push500Elements_ToArray_ShouldWorkCorrectly()
    {
        // Arrange
        var array = Enumerable.Range(1, 500).ToArray();
        var stack = new LinkedStack<int>();

        // Act
        for (int i = 0; i < array.Length; i++)
        {
            stack.Push(array[array.Length - i - 1]);
        }
        var arrayFromStack = stack.ToArray();

        // Assert
        CollectionAssert.AreEqual(array, arrayFromStack);
    }
}
