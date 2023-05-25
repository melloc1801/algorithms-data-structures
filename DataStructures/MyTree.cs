namespace DataStructures;

public class MyTree<T>: IMyTree<T>
{
    public int Count { get; private set; }
    public T Root { get; }
    public MyList<IMyTree<T>> Children { get; }
    public bool IsLeaf => Children.Count > 0;
    public int NumberOfSubTrees => Children.Count;
    public int Height => 1 + (Children.MaxBy(st => st.Height)?.Height ?? 0);

    public MyTree(T root)
    {
        Root = root;
        Children = new MyList<IMyTree<T>>();
        Count = 1;
    }

    public void AddSubTree(IMyTree<T> subtree)
    {
        if (subtree == null)
            throw new ArgumentNullException();

        Count += subtree.Count;
        Children.Add(subtree);
    }

    public T[] LevelOrderTraversal()
    {
        var queue = new Queue<IMyTree<T>>();
        queue.Enqueue(this);

        var result = new MyList<T>();
        
        while (queue.Count > 0)
        {
            var currentLevelNodes = new MyList<IMyTree<T>>();

            while (queue.Count > 0)
            {
                var tree = queue.Dequeue();
                currentLevelNodes.Add(tree);
            }

            foreach (var tree in currentLevelNodes)
            {
                foreach (var subtree in tree.Children)
                {
                    queue.Enqueue(subtree);
                }
                
                result.Add(tree.Root);
            }
        }

        return result.ToArray();
    }
}