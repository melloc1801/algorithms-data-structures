using NUnit.Framework;

namespace Algorithms.Test;

[TestFixture]
public class SorterGenericTests
{
    [Test]
    public void BubbleSort_Should_SortArray()
    {
        var sorter = new Sorter<int>();
        var actual = new[] {12333 ,534, 1, 2, 312, 121, 123};
        var expected  = new[] {1, 2, 121, 123, 312, 534, 12333};
        
        sorter.BubbleSort(actual);
        
        CollectionAssert.AreEqual(expected, actual);
    }
}