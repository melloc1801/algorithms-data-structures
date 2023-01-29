using DataStructures;
using NUnit.Framework;

namespace DataStructure.Test;

public class MyLinkedListNodeTests
{
    [TestCase(-1)]
    [TestCase(-0)]
    [TestCase(-1)]
    public void InitializeNode_Should_ReturnNodeWithValueAndNullNext(int value)
    {
        var actual = new MyLinkedListNode<int>(value);
        
        Assert.That(actual.Data, Is.EqualTo(value));
        Assert.That(actual.Next, Is.EqualTo(null));
    }

    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    public void NextProperty_Should_SetAndReturnNextNode(int nextNodeValue)
    {
        var currentNode = new MyLinkedListNode<int>(10);
        var nextNode = new MyLinkedListNode<int>(nextNodeValue);

        currentNode.Next = nextNode;
        var actual = currentNode.Next;
        
        Assert.That(actual, Is.EqualTo(nextNode));
    }
}