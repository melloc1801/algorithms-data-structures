using DataStructures;
using Helpers;
using NUnit.Framework;

namespace DataStructures.Test;

class StringIgnoreTestCase
{
    public string[] InitialValues { get; }
    public string[] ValuesToInsert { get; }
    public string[] ExpectedValues { get; }

    public StringIgnoreTestCase(
        string[] initialValues, 
        string[] valuesToInsert,
        string[] expectedValues
    )
    {
        InitialValues = initialValues;
        ValuesToInsert = valuesToInsert;
        ExpectedValues = expectedValues;
    }
}

[TestFixture]
public class MyHashSetTests
{
    private List<StringIgnoreTestCase> _stringIgnoreAddTestCases = new()
    {
        new (new string[] { }, new string[] { }, new string[] { }),
        new (new[] {""}, new[] {""}, new[] {""}),
        new (new[] {"a"}, new[] {"a"}, new[] {"a"}),
        new (new[] {"a"}, new[] {"A"}, new[] {"a"}),
        new (new[] {"A"}, new[] {"a"}, new[] {"A"}),
        new (new[] {"1HA"}, new[] {"1ha"}, new[] {"1HA"}),
        new (new[] {"1HA", "1ha", "AbC"}, new string[] {}, new[] {"1HA", "AbC"}),
        new (new[] {"1HA", "1ha", "AbC"}, new [] {"aBc"}, new[] {"1HA", "AbC"}),
        new (new string[] {}, new [] {"1HA", "1ha", "AbC"}, new[] {"1HA", "AbC"}),
    };

    [Test]
    public void EmptyCtor_Should_CreateEmptyMyHashset()
    {
        // Act
        var _ = new MyHashSet<int>();
    }

    [Test]
    public void CtorWithCollection_Should_Throws_ArgumentNullException()
    {
        // Arrange
        ICollection<int>? collection = null;
        // Act
        Assert.Throws<ArgumentNullException>(() => new MyHashSet<int>(collection));
    }

    [TestCase(new int[] { }, new int[] { })]
    [TestCase(new[] {-1}, new[] {-1})]
    [TestCase(new[] {-1, -1}, new[] {-1})]
    [TestCase(new[] {0}, new[] {0})]
    [TestCase(new[] {0, 0}, new[] {0})]
    [TestCase(new[] {1}, new[] {1})]
    [TestCase(new[] {1, 1}, new[] {1, 1})]
    public void CtorWithCollection_Should_CreateMyHashsetBasedOnIntCollection(int[] initialValues, int[] expected)
    {
        // Act
        var actual = new MyHashSet<int>(initialValues);
        
        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void CtorWithComparer_Should_CreateHashsetWithComparer()
    {
        // Arrange
        var comparer = new StringCaseIgnoreComparer();
        
        // Act
        var _ = new MyHashSet<string>(comparer);
    }

    [Test]
    public void CtorWithCapacity_Should_Throws_ArgumentOutOfRangeException()
    {
        // Arrange
        var capacity = -2;
        
        // Act
        Assert.Throws<ArgumentOutOfRangeException>(() => new MyHashSet<int>(capacity));
    }

    [Test]
    public void CtorWithCapacity_Should_CreateHashsetWithInitialCapacity()
    {
        // Arrange 
        var capacity = 64;
        
        // Act
        var _ = new MyHashSet<string>(capacity);
    }

    [Test]
    public void CtorWithCapacityAndComparer_Should_Throws_ArgumentOutOfRangeException()
    {
        // Arrange
        var capacity = -2;
        var comparer = new StringCaseIgnoreComparer();
        
        // Act
        Assert.Throws<ArgumentOutOfRangeException>(() => new MyHashSet<string>(capacity, comparer));
    }

    [Test]
    public void CtorWithCapacityAndComparer_Should_CreateHashSetWithCapacityAndComparer()
    {
        // Arrange
        var capacity = 222;
        var comparer = new StringCaseIgnoreComparer();

        // Act
        var _ = new MyHashSet<string>(capacity, comparer);
    }

    [Test]
    public void CtorWithCollectionAndComparer_Should_Throws_NullArgumentException()
    {
        // Arrange
        string[] collection = null;
        var comparer = new StringCaseIgnoreComparer();
        
        // Act
        Assert.Throws<ArgumentOutOfRangeException>(() => new MyHashSet<string>(collection, comparer));
    }

    [Test]
    public void CtorWithCollectionAndComparer_Should_CreateHashSetBasedOnCollectionWithComparer()
    {
        // Arrange
        var collection = new [] {"aB", "Ab", "010A"};
        var comparer = new StringCaseIgnoreComparer();
        var expected = new[] { "aB", "010A" };
        
        // Act
        var actual = new MyHashSet<string>(collection, comparer);
        
        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Add_Should_ThrowsArgumentNullException()
    {
        // Arrange
        var myHashSet = new HashSet<string>();
        
        // Act
        Assert.Throws<ArgumentNullException>(() => myHashSet.Add(null));
    }

    [TestCase(new int[] { }, 0, new[] {0}, true)]
    [TestCase(new int[] { }, 1, new[] {1}, true)]
    [TestCase(new[] {0}, -1, new[] {0, -1}, true)]
    [TestCase(new[] {0}, 1, new[] {0, 1}, true)]
    [TestCase(new[] {1}, 1, new[] {1}, false)]
    [TestCase(new[] {1}, 2, new[] {1, 2}, true)]
    [TestCase(new[] {-1, 0}, -1, new[] {-1, 0}, false)]
    public void Add_Should_AddOneItemToTheEnd(int[] initialValues, int valueToAdd, int[] expected, bool expectedOutput)
    {
        // Arrange
        var myHashset = new MyHashSet<int>();
        foreach (var value in initialValues)
        {
            myHashset.Add(value);
        }
        
        // Act
        var actualOutput = myHashset.Add(valueToAdd);
        
        // Assert
        CollectionAssert.AreEqual(expected, myHashset);
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void AddWithCaseIgnore_Should_AddOneItemToTheEnd()
    {
        var comparer = new StringCaseIgnoreComparer();

        foreach (var textCase in _stringIgnoreAddTestCases)
        {
            // Arrange
            var myHashSet = new MyHashSet<string>(textCase.InitialValues, comparer);
            
            // Act
            foreach (var value in textCase.ValuesToInsert)
            {
                myHashSet.Add(value);
            }
            
            // Assert
            CollectionAssert.AreEqual(textCase.ExpectedValues, myHashSet, "NN");
        }
    }
}