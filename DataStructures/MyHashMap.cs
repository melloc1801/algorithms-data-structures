using System.Collections;

namespace DataStructures;

public class MyHashMap<TKey, TValue>: IMyHashMap<TKey, TValue>
{
    public int Count { get; }
    public bool IsReadOnly { get; }
    public ICollection<TKey> Keys { get; }
    public ICollection<TValue> Values { get; }

    public TValue this[TKey key]
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    public MyHashMap()
    {
        throw new NotImplementedException();
    }
    
    public void Add(TKey key, TValue value)
    {
        throw new NotImplementedException();
    }
    public void Add(KeyValuePair<TKey, TValue> item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(KeyValuePair<TKey, TValue> item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }
    
    public bool ContainsKey(TKey key)
    {
        throw new NotImplementedException();
    }
    
    public bool TryGetValue(TKey key, out TValue value)
    {
        throw new NotImplementedException();
    }

    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
        throw new NotImplementedException();
    }

    public bool Remove(TKey key)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}