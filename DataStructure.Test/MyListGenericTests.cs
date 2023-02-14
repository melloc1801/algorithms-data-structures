using DataStructures;
using NUnit.Framework;

namespace DataStructure.Test;

[TestFixture]
public class MyListGenericTests
{
    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    public void InitializeWithCapacity_Should_CreateEmptyMyListWithCapacity(int capacity)
    {
        if (capacity < 0)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var _ = new MyList<int>(capacity);
            });
            return;
        }
        var ml = new MyList<int>(capacity);

        var actual = ml.Capacity;

        Assert.That(actual, Is.EqualTo(capacity));
    }
    
    [TestCase(new int[] {})]
    [TestCase(new [] {0})]
    [TestCase(new [] {1})]
    [TestCase(new [] {-1, 0})]
    [TestCase(new [] {-1, 0, 1})]
    public void Add_Should_AddOneItemToTheEnd(int[] values)
    {
        var ml = new MyList<int>();
        
        foreach (var value in values)
        {
            ml.Add(value);
        }
        
        foreach (var i in ml)
        {
            Console.WriteLine(i);
        } 
        
        CollectionAssert.AreEqual(values, ml);
    }

    [TestCase(new int[] {})]
    [TestCase(new [] {0})]
    [TestCase(new [] {1})]
    [TestCase(new [] {-1, 0})]
    [TestCase(new [] {-1, 0, 1})]
    public void InitializeWithArray_Should_CreateMyListBasedOnArray(int[] values)
    {
        var ml = new MyList<int>(values);
        
        CollectionAssert.AreEqual(values, ml);
    }

    [TestCase(new int[] { }, 0)]
    [TestCase(new[] {-1}, 1)]
    [TestCase(new[] {-1, 0}, 2)]
    [TestCase(new[] {-1, 0, 1}, 3)]
    public void IsCountCorrect_Should_ReturnAmountOfActualElements(int[] values, int expected)
    {
        var ml = new MyList<int>(values);

        var actual = ml.Count;
        
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(new int[] { }, new int[] {}, 0)]
    [TestCase(new[] {-1}, new int[] {}, 1)]
    [TestCase(new[] {-1, 0, 1, 2, 3}, new int[] {}, 5)]
    [TestCase(new int[] { }, new [] {-1}, 4)]
    [TestCase(new[] {-1}, new [] {0}, 2)]
    [TestCase(new[] {-1, 0}, new [] {1}, 4)]
    [TestCase(new[] {-1, 0, 1, 2, 3}, new [] {1}, 10)]
    public void IsCapacityCorrect_Should_Return_ListLengthIncludeBuffer(int[] initialValues, int[] values, int expected)
    {
        var ml = new MyList<int>(initialValues);
        foreach (var value in values)
        {
            ml.Add(value);
        }

        var actual = ml.Capacity;
        
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(new int[] {}, 0, null)]
    [TestCase(new [] {-1}, 0, -1)]
    [TestCase(new [] {-1, 0}, 1, 0)]
    [TestCase(new [] {-1, 0}, 2, null)]
    public void Getter_Should_ReturnItemByIndex(int[] values, int index, int? expected)
    {
        var ml = new MyList<int>(values);

        if (index < 0 || index >= ml.Count)
        {
            Assert.Throws<IndexOutOfRangeException>(() => _ = ml[index]);
            return;
        }
        var actual = ml[index];
        
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [TestCase(new int[] {}, 0, -1, null)]
    [TestCase(new [] {-1}, 0, 0, new [] {0})]
    [TestCase(new [] {-1, 0}, 1, 1, new [] {-1, 1})]
    [TestCase(new [] {-1, 0}, 2, 2, null)]
    [TestCase(new [] {-1, 0, 1}, 2, 1, new [] {-1, 0, 1})]
    public void Setter_Should_SetItemByIndex(int[] values, int index, int value, int[]? expected)
    {
        var ml = new MyList<int>(values);

        if (index < 0 || index >= ml.Count)
        {
            Assert.Throws<IndexOutOfRangeException>(() => ml[index] = value);
            return;
        }
        ml[index] = value;

        Assert.That(ml, Is.EqualTo(expected));
    }

    [TestCase(new int[] { }, 2, 0)]
    [TestCase(new [] {-1, 0}, -1, -1)]
    [TestCase(new [] {-1, 0, 1}, 2, 0)]
    [TestCase(new [] { 0, 1, 1 }, 1, 1)]
    public void Find_Should_ReturnFirstMatchedItem(int[] values, int valueToBeFound, int expected)
    {
        var ml = new MyList<int>(values);
        
        var actual = ml.Find(value => value == valueToBeFound);
        
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(new int[] { }, 0, new int[]{})]
    [TestCase(new [] { 0 }, 1, new int[] {})]
    [TestCase(new [] { 1 }, 1, new [] {1})]
    [TestCase(new [] { 1, 1 }, 2, new int[] {})]
    [TestCase(new [] { 1, 1, 3 }, 1, new [] {1, 1})]
    [TestCase(new [] { 1, 2, 2, 3 }, 2, new [] {2, 2})]
    public void Find_Should_ReturnAllMathcedItems(int[] values, int valueToBeFound, int[] expected)
    {
        var ml = new MyList<int>(values);

        var actual = ml.FindAll(value => value == valueToBeFound);
        
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [TestCase(new int[] { }, 0, -1)]
    [TestCase(new [] { 0 }, 1, -1)]
    [TestCase(new [] { -1, 0 }, -1, 0)]
    [TestCase(new [] { -1, 0 }, 0, 1)]
    [TestCase(new [] { -1, 0, 0 }, 0, 1)]
    public void Find_Should_ReturnFirstMatchedElementIndex(int[] values, int valueToBeFound, int expected)
    {
        var ml = new MyList<int>(values);

        var actual = ml.FindIndex((item) => item == valueToBeFound);

        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [TestCase(new int [] {}, -1, null)]
    [TestCase(new int [] {}, 0, null)]
    [TestCase(new [] {-1}, 0, new int[] {})]
    [TestCase(new [] {-1, 0, 1, 0}, 1, new [] {-1, 1, 0})]
    [TestCase(new [] {-1, 0, 1, 0}, 3, new [] {-1, 0, 1})]
    public void RemoveAt_Should_RemoveOneItemByIndex(int[] values, int index, int[] expected)
    {
        var ml = new MyList<int>(values);

        if (index < 0 || index >= ml.Count)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ml.RemoveAt(index));
            return;
        }
        ml.RemoveAt(index);
        
        CollectionAssert.AreEqual(expected, ml);
    }

    [TestCase(new int[] {}, 2, new int[] {}, false)]
    [TestCase(new [] {-1}, 2, new [] {-1}, false)]
    [TestCase(new [] {-1}, -1, new int[] {}, true)]
    [TestCase(new [] {-1, 0, 0}, 0, new [] {-1, 0}, true)]
    [TestCase(new [] {-1, 0, 0, 1, 1}, 0, new [] {-1, 0, 1, 1}, true)]
    public void Remove_Should_RemoveFirstMatchedItem(int[] values, int valueToBeRemoved, int[] expectedValues, bool expectedResult)
    {
        var ml = new MyList<int>(values);

        var actualResult = ml.Remove(valueToBeRemoved);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
        CollectionAssert.AreEqual(expectedValues, ml);
    }
    
    [TestCase(new int[] {}, 2, new int[] {}, 0)]
    [TestCase(new [] {-1}, 2, new [] {-1}, 0)]
    [TestCase(new [] {-1}, -1, new int[] {}, 1)]
    [TestCase(new [] {-1, 0, 0}, 0, new [] {-1}, 2)]
    [TestCase(new [] {-1, 0, 0, 1, 1}, 0, new [] {-1, 1, 1}, 2)]
    public void RemoveAll_Should_RemoveAllMatchedItems(int[] values, int valueToBeRemoved, int[] expectedValues, int expectedResult)
    {
        var ml = new MyList<int>(values);

        var actualResult = ml.RemoveAll(item => item == valueToBeRemoved);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
        CollectionAssert.AreEqual(expectedValues, ml);
    }

    [TestCase(new int [] {})]
    [TestCase(new [] {-1})]
    [TestCase(new [] {-1, 0})]
    [TestCase(new [] {-1, 0, 1, 2, 3})]
    public void ToArray_Should_ReturnArrayBasedOnMyList(int[] values)
    {
        var ml = new MyList<int>(values);

        var actual = ml.ToArray();

        CollectionAssert.AreEqual(values, actual);
    }
}