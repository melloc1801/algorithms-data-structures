namespace DataStructures;

public class MyLinkedListNode<T>: IMyLinkedListNode<T>
{
    public T Data { get; }
    public IMyLinkedListNode<T>? Prev { get; set; }
    public IMyLinkedListNode<T>? Next { get; set; }

    public MyLinkedListNode(T value)
    {
        Data = value;
    }
}