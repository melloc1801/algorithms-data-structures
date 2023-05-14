using DataStructures;
using NUnit.Framework;

namespace DataStructures.Test;

public class MyLinkedListTests
{
    [Test]
    public void Initialize_Should_CreateEmptyMyLinkedList()
    {
        var _ = new MyLinkedList<int>();
    }

    [Test]
    public void AddFirst_Should_ThrowsArgumentNullException()
    {
        var mll = new MyLinkedList<int>();

        Assert.Throws<ArgumentNullException>(() => mll.AddFirst(null));
    }
    [TestCase(new int[] {}, null, new int[] {})]
    [TestCase(new [] {-1}, -1, new [] {-1})]
    [TestCase(new [] {-1, 0}, 0, new [] {0, -1})]
    [TestCase(new [] {-1, 0, 1}, 1, new [] {1, 0, -1})]
    public void AddFirst_Should_InsertNodeAtTheStart(int[] nodeValues, int? expectedFirstValue, int[] expectedValues)
    {
        var mll = new MyLinkedList<int>();
        foreach (var nodeValue in nodeValues)
        {
            mll.AddFirst(new MyLinkedListNode<int>(nodeValue));
        }

        int? actual = mll.First == null ? null : mll.First.Data;

        Assert.That(actual, Is.EqualTo(expectedFirstValue));
        CollectionAssert.AreEqual(expectedValues, mll.ToArray());
    }
    
    [Test]
    public void AddLast_Should_ThrowsArgumentNullException()
    {
        var mll = new MyLinkedList<int>();

        Assert.Throws<ArgumentNullException>(() => mll.AddLast(null));
    }
    [TestCase(new int[] {}, null, new int[] {})]
    [TestCase(new [] {-1}, -1, new [] {-1})]
    [TestCase(new [] {-1, 0}, 0, new [] {-1, 0})]
    [TestCase(new [] {-1, 0, 1}, 1, new [] {-1, 0, 1})]
    public void AddLast_Should_InsertNodeAtTheEnd(int[] nodeValues, int? expectedLastValue, int[] expectedValues)
    {
        var mll = new MyLinkedList<int>();
        foreach (var nodeValue in nodeValues)
        {
            mll.AddLast(new MyLinkedListNode<int>(nodeValue));
        }

        int? actual = mll.Last == null ? null : mll.Last.Data;

        Assert.That(actual, Is.EqualTo(expectedLastValue));
        CollectionAssert.AreEqual(expectedValues, mll.ToArray());
    }

    [Test]
    public void InitializeWithArray_Should_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new MyLinkedList<int>(null));
    }
    [TestCase(new int[] {})]
    [TestCase(new [] {-1})]
    [TestCase(new [] {-1, 0})]
    [TestCase(new [] {-1, 0, 1})]
    public void InitializeWithArray_Should_CreateMyLinkedListBasedOnArray(int[] nodeValues)
    {
        var actual = new MyLinkedList<int>(nodeValues);
        
        CollectionAssert.AreEqual(nodeValues, actual.ToArray());
    }

    [TestCase(new int[] {}, 0)]
    [TestCase(new [] {-1}, 1)]
    [TestCase(new [] {-1, 0}, 2)]
    [TestCase(new [] {-1, 0, 1}, 3)]
    [TestCase(new [] {-1, 0, 0, 1}, 4)]
    public void Count_Should_ReturnNodeAmount(int[] nodeValues, int expected)
    {
        var mll = new MyLinkedList<int>(nodeValues);

        var actual = mll.Count;
        
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [TestCase(new int[] {}, null)]
    [TestCase(new [] {-1}, -1)]
    [TestCase(new [] {-1, 0}, -1)]
    public void First_Should_ReturnFirstNode(int[] nodeValues, int? expected)
    {
        var mll = new MyLinkedList<int>(nodeValues);

        int? actual = mll.First == null ? null : mll.First.Data;
        
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [TestCase(new int[] {}, null)]
    [TestCase(new [] {-1}, -1)]
    [TestCase(new [] {-1, 0}, 0)]
    [TestCase(new [] {-1, 0, 1}, 1)]
    public void Last_Should_ReturnLastNode(int[] nodeValues, int? expected)
    {
        var mll = new MyLinkedList<int>(nodeValues);

        int? actual = mll.Last == null ? null : mll.Last.Data;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(new int[] {})]
    [TestCase(new [] {-1})]
    [TestCase(new [] {-1, 0})]
    [TestCase(new [] {-1, 0, 1})]
    public void Clear_Should_RemoveAllNodeFromMyLinkedList(int[] nodeValues)
    {
        var actual = new MyLinkedList<int>(nodeValues);
        
        actual.Clear();
        
        CollectionAssert.AreEqual(actual, new int[] {});
    }

    [TestCase(new int[] {}, 1, null)]
    [TestCase(new [] {-1}, 1, null)]
    [TestCase(new [] {0}, 0, 0)]
    [TestCase(new [] {-1, 0, 1}, 1, 1)]
    [TestCase(new [] {-1, 0, 1, 1}, 1, 1)]
    public void Find_Should_ReturnFirstMatchedNode(int[] nodeValues, int valueToBeFound, int? expected)
    {
        var mll = new MyLinkedList<int>(nodeValues);

        var founded = mll.Find(valueToBeFound);
        int? actual = founded == null ? null : founded.Data;
        
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Remove_Should_Throws_ArgumentNullException()
    {
        // Arrange
        var mll = new MyLinkedList<string>(new [] {"a", "b"});
        string valueToInsert = null;

        // Act
        Assert.Throws<ArgumentNullException>(() => mll.Remove(valueToInsert));
    }

    [TestCase(new int[] {}, 0, new int[] {})]
    [TestCase(new [] {-1}, 0, new [] {-1})]
    [TestCase(new [] {0}, 0, new int[] {})]
    [TestCase(new [] {-1, 0}, 0, new [] {-1})]
    [TestCase(new [] {-1, 0}, -1, new [] {0})]
    [TestCase(new [] {-1, 0}, 1, new [] {-1, 0})]
    [TestCase(new [] {-1, 0, 1}, 1, new [] {-1, 0})]
    [TestCase(new [] {-1, 0, 1, 1}, 1, new [] {-1, 0, 1})]
    public void Remove_Should_DeleteFirstMatchedItem(int[] initialValues, int valueToRemove, int[] expectedValues)
    {
        // Arrange
        var mll = new MyLinkedList<int>(initialValues);
        
        // Act
        mll.Remove(valueToRemove);

        // Assert
        CollectionAssert.AreEqual(expectedValues, mll.ToArray());
    } 

    [Test]
    public void RemoveFirst_Should_ThrowsInvalidOperationException()
    {
        var mll = new MyLinkedList<int>();

        Assert.Throws<InvalidOperationException>(() => mll.RemoveFirst());
    }
    [TestCase(new [] {-1}, new int[] {})]
    [TestCase(new [] {-1, 0, 0}, new [] {0, 0})]
    [TestCase(new [] {-1, 0, -1}, new [] {0, -1})]
    public void RemoveFirst_Should_DeleteFirstNode(int[] nodeValues, int[] expected)
    {
        var actual = new MyLinkedList<int>(nodeValues);

        actual.RemoveFirst();
        
        CollectionAssert.AreEqual(expected, actual.ToArray());
    }
    
    [Test]
    public void RemoveLast_Should_ThrowsInvalidOperationException()
    {
        var mll = new MyLinkedList<int>();

        Assert.Throws<InvalidOperationException>(() => mll.RemoveLast());
    }
    [TestCase(new [] {-1}, new int[] {})]
    [TestCase(new [] {-1, 0, -1}, new [] {-1, 0})]
    [TestCase(new [] {-1, 0, 0}, new [] {-1, 0})]
    public void RemoveLast_Should_DeleteLastNode(int[] nodeValues, int[] expected)
    {
        var actual = new MyLinkedList<int>(nodeValues);

        actual.RemoveLast();
        
        CollectionAssert.AreEqual(expected, actual.ToArray());
    }
} 