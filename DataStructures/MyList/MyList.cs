using System.Collections;

namespace DataStructures.MyList;

public class MyList<T>: IMyList<T>
{
    private T[] _storage;
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return _storage[index];
        }
        set
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            _storage[index] = value;
        }
    }

    public int Count { get; }
    public int Capacity { get; }
    
    public MyList() { }
    public MyList(int capacity) { }
    public MyList(T[] value) { }

    public void Add(T item)
    {
        throw new NotImplementedException();
    }

    public T Find(Predicate<T> match)
    {
        throw new NotImplementedException();
    }

    public IMyList<T> FindAll(Predicate<T> match)
    {
        throw new NotImplementedException();
    }

    public int FindIndex(Predicate<T> match)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public int RemoveAll(Predicate<T> match)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public T[] ToArray()
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}