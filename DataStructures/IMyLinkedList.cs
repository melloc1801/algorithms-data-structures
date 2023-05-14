namespace DataStructures;

public interface IMyLinkedList<T>: IEnumerable<IMyLinkedListNode<T>>
{
    int Count { get; }

    IMyLinkedListNode<T> First { get; }
    
    IMyLinkedListNode<T> Last { get; }

    void AddFirst(IMyLinkedListNode<T> node);
    
    void AddLast(IMyLinkedListNode<T> node);

    void Clear();

    IMyLinkedListNode<T> Find(T value);
    void Remove(T item);

    void RemoveFirst();
    
    void RemoveLast();

    T[] ToArray();
}