namespace DataStructures;

public interface IMyLinkedListNode<T>
{
    public T Data { get; }

    public IMyLinkedListNode<T> Next { get; set; }
}