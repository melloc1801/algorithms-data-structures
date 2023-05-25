namespace DataStructures;

public interface IMyTree<T>
{
    int Count { get; }
    T Root { get; }
    MyList<IMyTree<T>> Children { get; }
    bool IsLeaf { get; }
    int NumberOfSubTrees { get; }
    int Height { get; }
    void AddSubTree(IMyTree<T> subtree);
    T[] LevelOrderTraversal();
}