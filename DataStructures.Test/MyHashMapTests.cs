using NUnit.Framework;

namespace DataStructures.Test;

[TestFixture]
public class MyHashMapTests
{
    private MyHashMap<int, int> _myHashMap;


    [SetUp]
    public void Init()
    {
        _myHashMap = new MyHashMap<int, int>();
        _myHashMap.Add(1, 1);
        _myHashMap.Add(2, 2);
        _myHashMap.Add(3, 3);
        
    }

    [Test]
    public void Add_Should_Throw_ArgumentException()
    {
        // Act
        Assert.Throws<ArgumentException>(() => _myHashMap.Add(new KeyValuePair<int, int>(2, 40)));
    }

    [Test]
    public void Add_Should_Throw_ArgumentNullException()
    {
        // Arrange
        var mhm = new MyHashMap<string, int>();
        var pair = new KeyValuePair<string, int>(null, 20);
        
        // Act
        Assert.Throws<ArgumentNullException>(() => mhm.Add(pair));
    }
    
    [TestCase(
        5, 5,
        new [] {1, 2, 3, 5},
        new  [] {1, 2, 3 ,5}
    )]
    public void Add_Should_InsertPairInCollection(
        int keyToInsert,
        int valueToInsert,
        int[] expectedKeys,
        int[] expectedValues
    )
    {
        // Arrange
        var expectedPairs = new KeyValuePair<int, int>[expectedKeys.Length];
        for (int i = 0; i < expectedKeys.Length; i++)
        {
            var key = expectedKeys[i];
            var value = expectedValues[i];
            expectedPairs[i] = new KeyValuePair<int, int>(key, value);
        }

        // Act
        _myHashMap.Add(keyToInsert, valueToInsert);
        
        // Assert
        CollectionAssert.AreEqual(expectedPairs, _myHashMap);
    }

    [TestCase(
        5, 5,
        new [] {1, 2, 3, 5},
        new  [] {1, 2, 3 ,5}
    )]
    public void AddKeyPair_Should_InsertPairInCollection(
        int keyToInsert,
        int valueToInsert,
        int[] expectedKeys,
        int[] expectedValues
    )
    {
        // Arrange
        var pairToInsert = new KeyValuePair<int, int>(keyToInsert, valueToInsert);
        var expectedPairs = new KeyValuePair<int, int>[expectedKeys.Length];
        for (int i = 0; i < expectedKeys.Length; i++)
        {
            var key = expectedKeys[i];
            var value = expectedValues[i];
            expectedPairs[i] = new KeyValuePair<int, int>(key, value);
        }

        // Act
        _myHashMap.Add(pairToInsert);
        
        // Assert
        CollectionAssert.AreEqual(expectedPairs, _myHashMap);
    }

    [Test]
    public void Getter_Should_Throw_KeyNotFoundException()
    {
        // Arrange
        var key = 124;

        // Act
        Assert.Throws<KeyNotFoundException>(() => _ = _myHashMap[key]);
    }

    [Test]
    public void Getter_Should_Throw_ArgumentNullException()
    {
        // Arrange
        var mhm = new MyHashMap<string, int>();
        string key = null;
        
        // Act
        Assert.Throws<ArgumentNullException>(() => _ = mhm[key]);
    }
    
    [TestCase(1, 1)]
    [TestCase(2, 2)]
    [TestCase(3, 3)]
    public void Getter_Should_ReturnItemByKey(int key, int value)
    {
        // Act
        var actual = _myHashMap[key];

        // Assert
        Assert.That(actual, Is.EqualTo(value));
    }
    
    [Test]
    public void Setter_Should_Throw_ArgumentNullException()
    {
        // Arrange
        var mhm = new MyHashMap<string, int>();
        string key = null;
        
        // Act
        Assert.Throws<ArgumentNullException>(() => _ = mhm[key]);
    }

    [TestCase(4)]
    [TestCase(5)]
    public void Setter_Should_Throw_KeyNotFoundException(
        int key
    )
    {
        int valueToInsert = 1;
        
        // Act
        Assert.Throws<KeyNotFoundException>(() => _ = _myHashMap[key] = valueToInsert);
    }

    [TestCase(1, 11, new [] {1, 2, 3,}, new [] {11, 2, 3})]
    [TestCase(2, 22, new [] {1, 2, 3,}, new [] {1, 22, 3})]
    public void Setter_Should_SetItemByKey(
        int key,
        int valueToInsert,
        int[] expectedKeys,
        int[] expectedValues
    )
    {
        // Arrange
        var expectedPairs = new KeyValuePair<int, int>[expectedKeys.Length];
        for (int i = 0; i < expectedKeys.Length; i++)
        {
            var k = expectedKeys[i];
            var v = expectedValues[i];
            expectedPairs[i] = new KeyValuePair<int, int>(k, v);
        }
        
        // Act
        _myHashMap[key] = valueToInsert;
        
        // Assert
        CollectionAssert.AreEquivalent(expectedPairs, _myHashMap);
    }

    [Test]
    public void Keys_Should_ReturnAllItemsKeys()
    {
        // Arrange
        var expectedKeys = new [] {1, 2, 3};
        
        // Act
        var actual = _myHashMap.Keys;

        // Assert
        CollectionAssert.AreEqual(expectedKeys, actual);
    }
    
    [Test]
    public void Values_Should_ReturnAllItemsValues()
    {
        // Arrange
        var expectedValues = new[] {1, 2, 3};
        
        // Act
        var actual = _myHashMap.Values;

        // Assert
        CollectionAssert.AreEqual(expectedValues, actual);
    }

    [Test]
    public void Count_Should_ReturnCurrentCollectionSize()
    {
        // Arrange
        var expectedCount = 3;
        
        // Act
        var actual = _myHashMap.Count;

        // Assert
        Assert.That(actual, Is.EqualTo(expectedCount));
    }
    
    [Test]
    public void Clear_Should_RemoveAllItemsFromCollection()
    {
        // Arrange
        var myHashMap = new MyHashMap<string, int>();
        myHashMap.Add("one", 1);
        myHashMap.Add("two", 2);
        myHashMap.Add("tree", 3);
        var expected = Array.Empty<KeyValuePair<string, int>>();

        // Act
        myHashMap.Clear();

        // Assert    
        CollectionAssert.AreEqual(expected, myHashMap);
    }

    [TestCase(0, 0, false)]
    [TestCase(1, 1, true)]
    [TestCase(1, 2, false)]
    [TestCase(3, 3, true)]
    [TestCase(-1, 42, false)]
    public void Contains_Should_CheckItemExistence(int findedKey, int findedValue, bool expected)
    {
        // Arrange
        var findedPair = new KeyValuePair<int, int>(findedKey, findedValue);
        
        // Act
        var actual = _myHashMap.Contains(findedPair);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ContainsKey_Should_Throws_ArgumentNullException()
    {
        // Arrange
        var mhm = new MyHashMap<string, int>();
        string key = null;
        
        // Act
        Assert.Throws<ArgumentNullException>(() => _ = mhm.ContainsKey(null));
    }

    [TestCase(-1, false)]
    [TestCase(0, false)]
    [TestCase(1, true)]
    [TestCase(5, false)]
    public void ContainsKey_Should_CheckItemWithKeyExistence(int key, bool expected)
    {
        // Act
        var actual = _myHashMap.ContainsKey(key);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TryGetValue_Should_Throws_ArgumentNullException()
    {
        // Arrange
        var mhm = new MyHashMap<string, int>();
        string key = null;

        // Act
        Assert.Throws<ArgumentNullException>(() => _ = mhm.TryGetValue(key, out int value));
    }

    [TestCase(0, false, default(int))]
    [TestCase(1, true, 1)]
    [TestCase(2, true, 2)]
    [TestCase(4, false, default(int))]
    public void TryGetValue_Should_ReturnValueAssociatedWithKey(
        int key,
        bool expected,
        int value
    )
    {
        // Act
        var actual = _myHashMap.TryGetValue(key, out int expectedValue);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
        Assert.That(value, Is.EqualTo(expectedValue));
    }

    [TestCase(0, 0, false, new [] {1, 2, 3}, new [] {1, 2, 3})]
    [TestCase(1, 1, true, new [] {2, 3}, new [] {2, 3})]
    [TestCase(3, 2, false, new [] {1, 2, 3}, new [] {1, 2, 3})]
    [TestCase(3, 3, true, new [] {1, 2}, new [] {1, 2})]
    [TestCase(4, 4, false, new [] {1, 2, 3}, new [] {1, 2, 3})]
    public void RemovePair_Should_RemovePairFromCollection(
        int keyToRemove,
        int valueToRemove,
        bool expectedOutput,
        int[] expectedKeys,
        int[] expectedValues
    ) 
    {
        // Arrange
        var pair = new KeyValuePair<int, int>(keyToRemove, valueToRemove);
        var expectedPairs = new KeyValuePair<int, int>[expectedKeys.Length];
        for (int i = 0; i < expectedPairs.Length; i++)
        {
            var key = expectedKeys[i];
            var value = expectedValues[i];
            expectedPairs[i] = new KeyValuePair<int, int>(key, value);
        }
        
        // Act
        var actual = _myHashMap.Remove(pair);

        // Assert
        CollectionAssert.AreEqual(expectedPairs, _myHashMap);
        Assert.That(actual, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void RemoveByKey_Should_Throws_ArgumentNullException()
    {
        // Arrange
        var mhm = new MyHashMap<string, int>();
        string key = null;

        // Act
        Assert.Throws<ArgumentNullException>(() => _ = mhm.ContainsKey(key));
    }
    
    [TestCase(0, false, new [] {1, 2, 3}, new [] {1, 2, 3})]
    [TestCase(1, true, new [] {2, 3}, new [] {2, 3})]
    [TestCase(4, false, new [] {1, 2, 3}, new [] {1, 2, 3})]
    public void RemoveByKey_Should_RemovePairFromCollection(
        int keyToRemove,
        bool expectedOutput,
        int[] expectedKeys,
        int[] expectedValues
    ) 
    {
        // Arrange
        var expectedPairs = new KeyValuePair<int, int>[expectedKeys.Length];
        for (int i = 0; i < expectedKeys.Length; i++)
        {
            var key = expectedKeys[i];
            var value = expectedValues[i];
            expectedPairs[i] = new KeyValuePair<int, int>(key, value);
        }
        
        // Act
        var actual = _myHashMap.Remove(keyToRemove);

        // Assert
        CollectionAssert.AreEqual(expectedPairs, _myHashMap);
        Assert.That(actual, Is.EqualTo(expectedOutput));
    }
}