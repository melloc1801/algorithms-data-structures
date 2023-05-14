using NUnit.Framework;

namespace Helpers.Test;

[TestFixture]
public class StringCaseIgnoreComparerTests
{
    [TestCase(null, null, true)]
    [TestCase("", null, false)]
    [TestCase("", "", true)]
    [TestCase(null, "a", false)]
    [TestCase("a", null, false)]
    [TestCase("a", "A", true)]
    [TestCase("1", "1", true)]
    [TestCase("1", "1", true)]
    [TestCase("aB1", "Ab1", true)]
    [TestCase("ab1", "ba1", false)]
    public void Equals_Should_CompareStringIgnoreCase(string str1, string str2, bool result)
    {
        // Arrange
        var comparer = new StringCaseIgnoreComparer();

        // Act
        var actual = comparer.Equals(str1, str2);

        // Assert
        Assert.That(actual, Is.EqualTo(result));
    }

    [TestCase(null, null, true)]
    [TestCase(null, "", false)]
    [TestCase(null, "0", false)]
    [TestCase("", "", true)]
    [TestCase("a", "b", false)]
    [TestCase("a", "B", false)]
    [TestCase("a", "A", true)]
    [TestCase("aB", "Ab", true)]
    public void GetHashCode_Should_ReturnTheSameHashCodeIgnoreCase(string str1, string str2, bool expected)
    {
        // Arrange
        var comparer = new StringCaseIgnoreComparer();

        // Act
        var actual1 = comparer.GetHashCode(str1);
        var actual2 = comparer.GetHashCode(str2);

        // Assert
        Assert.That(actual1 == actual2, Is.EqualTo(expected));
    }
}