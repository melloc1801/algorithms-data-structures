using System.Collections;
using System.Runtime.Serialization;

namespace DataStructures;

public class MyHashSet<T>: IMyHashSetGeneric<T>
{
    private int[] _orderStorage;
    private MyLinkedList<T>[] _storage;
    private int _capacity; 
    public IEqualityComparer<T> Comparer { get; }

    public int Count { get; }

    public MyHashSet()
    {
        throw new NotImplementedException();
    }
    public MyHashSet(IEnumerable<T> collection)
    {
        throw new NotImplementedException();
    }
    public MyHashSet(IEqualityComparer<T> comparer)
    {
        throw new NotImplementedException();
    }
    public MyHashSet(int capacity)
    {
        throw new NotImplementedException();
    }
    public MyHashSet(IEnumerable<T> collection, IEqualityComparer<T> comparer)
    {
        throw new NotImplementedException();
    }
    public MyHashSet(int capacity, IEqualityComparer<T> comparer)
    {
        throw new NotImplementedException();
    }
    public bool Add(T item)
    {
        throw new NotImplementedException();
    }

    void ICollection<T>.Add(T item)
    {
        throw new NotImplementedException();
    }
    
    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }
    
    public void ExceptWith(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    public void IntersectWith(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    public bool IsProperSubsetOf(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    public bool IsProperSupersetOf(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    public bool IsSubsetOf(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    public bool IsSupersetOf(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    public bool Overlaps(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    public bool SetEquals(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    public void SymmetricExceptWith(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    public void UnionWith(IEnumerable<T> other)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }
    
    public bool IsReadOnly { get; }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private int GetIndexByHashcode(T value)
    {
        var hashcode = value.GetHashCode();
        return hashcode % _capacity;
    }
}