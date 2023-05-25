using NUnit.Framework;

namespace DataStructures.Test;

[TestFixture]
public class MyTreeTests
{
    private IMyTree<int> _myTree;

    [SetUp]
    public void Init()
    {
        _myTree = new MyTree<int>(10);

        var myTree1_1 = new MyTree<int>(6);
        var myTree1_2 = new MyTree<int>(2);
        
        var myTree2_1 = new MyTree<int>(1);
        var myTree2_2 = new MyTree<int>(5);
        var myTree2_3 = new MyTree<int>(3);
        var myTree2_4 = new MyTree<int>(0);
        var myTree2_5 = new MyTree<int>(1);

        myTree1_1.AddSubTree(myTree2_1);
        myTree1_1.AddSubTree(myTree2_2);
        myTree1_1.AddSubTree(myTree2_3);
        
        myTree1_2.AddSubTree(myTree2_4);
        myTree1_2.AddSubTree(myTree2_5);

        _myTree.AddSubTree(myTree1_1);
        _myTree.AddSubTree(myTree1_2);
    }

    [Test]
    public void Count_Should_ReturnAmountOfNodes()
    {
        // Arrange
        var expectedAmount = 8;
        
        // Act
        var actual = _myTree.Count;

        // Assert
        Assert.That(actual, Is.EqualTo(expectedAmount));
    }

    [Test]
    public void Root_Should_ReturnTopLevelNode()
    {
        // Arrange
        var expected = 10;

        // Act
        var actual = _myTree.Root;

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void NumberOfSubtrees_Should_ReturnAmountOfAdjacentSubtrees()
    {
        // Arrange
        var expectedNumber = 2;

        // Act
        var actual = _myTree.NumberOfSubTrees;

        // Assert
        Assert.That(actual, Is.EqualTo(expectedNumber));
    }

    [Test]
    public void IsLeaf_Should_ShowWhetherTreeHasAdjacentSubtrees()
    {
        // Arrange
        var expected = true;

        // Act
        var actual = _myTree.IsLeaf;

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Height_Should_ReturnAmountOfLevels()
    {
        // Arrange
        var expected = 3;

        // Act
        var actual = _myTree.Height;

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void AddSubTree_Should_AddAdjacentTree()
    {
        // Arrange
        var subtree = new MyTree<int>(5);
        var expectedCount = 9;
        var expectedHeight = 3;
        var expectedNumberOfSubtrees = 3;

        // Act
        _myTree.AddSubTree(subtree);
        var actualCount = _myTree.Count;
        var actualHeight = _myTree.Height;
        var actualNumberOfSubTrees = _myTree.NumberOfSubTrees;
        
        // Assert
        Assert.That(actualCount, Is.EqualTo(expectedCount));
        Assert.That(actualHeight, Is.EqualTo(expectedHeight));
        Assert.That(actualNumberOfSubTrees, Is.EqualTo(expectedNumberOfSubtrees));
    }
    
    [Test]
    public void LevelOrderTraversal_Should_TraversTreeByLevels()
    {
        // Arrange
        var expected = new[] {10, 6, 2, 1, 5, 3, 0, 1};

        // Act
        var actual = _myTree.LevelOrderTraversal();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}