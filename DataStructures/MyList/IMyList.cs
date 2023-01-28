namespace DataStructures.MyList;

public interface IMyList<T> : IEnumerable<T>
{
    public T this[int index] { get; set; }
    public int Count { get; }
    public int Capacity { get; }
    
    public void Add(T item);

    public T Find(Predicate<T> match);

    public IMyList<T> FindAll(Predicate<T> match);

    public int FindIndex(Predicate<T> match);

    public bool Remove(T item);

    public int RemoveAll(Predicate<T> match);
    
    public void RemoveAt(int index);

    public T[] ToArray();
}