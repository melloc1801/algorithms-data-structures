namespace DataStructures;

public interface IMyLinkedListNode<T>
{
    public T Data { get; }

    public IMyLinkedListNode<T> Prev { get; set; }
    public IMyLinkedListNode<T> Next { get; set; }
}