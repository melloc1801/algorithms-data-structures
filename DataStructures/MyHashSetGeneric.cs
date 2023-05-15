using System.Collections;

namespace DataStructures;
public class MyHashSet<T>: IMyHashSetGeneric<T>
{
    private const int BaseCapacity = 16;
    private MyLinkedList<T> _orderStorage;
    private MyLinkedList<T>[] _storage;
    private int _capacity; 
    public IEqualityComparer<T> Comparer { get; }

    public int Count { get; private set; }

    public MyHashSet()
    {
        _capacity = BaseCapacity;
        _orderStorage = new MyLinkedList<T>();
        _storage = new MyLinkedList<T>[_capacity];
        Count = 0;
        Comparer = EqualityComparer<T>.Default;
    }
    public MyHashSet(IEnumerable<T> collection): this()
    {
        if (collection == null)
        {
            throw new ArgumentNullException();
        }
        var coll = collection.ToArray();
        _capacity = coll.Length > BaseCapacity ? coll.Length : BaseCapacity;
        
        foreach (var item in coll)
        {
            Add(item);
        }
    }
    public MyHashSet(IEqualityComparer<T> comparer): this()
    {
        if (comparer == null)
        {
            Comparer = EqualityComparer<T>.Default;
            return;
        }
        Comparer = comparer;
    }
    public MyHashSet(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        
        _capacity = capacity;
        _orderStorage = new MyLinkedList<T>();
        _storage = new MyLinkedList<T>[_capacity];
        Count = 0;
        Comparer = EqualityComparer<T>.Default;
    }
    public MyHashSet(IEnumerable<T> collection, IEqualityComparer<T> comparer)
    {
        if (collection == null)
        {
            throw new ArgumentNullException("Collection is null");
        }
        var coll = collection.ToArray(); 
        _capacity = coll.Length > 0 ? coll.Length : BaseCapacity;
        _orderStorage = new MyLinkedList<T>();
        _storage = new MyLinkedList<T>[_capacity];

        if (comparer == null)
        {
            Comparer = EqualityComparer<T>.Default;
        }
        else
        {
            Comparer = comparer;
        }
        
        Count = 0;

        foreach (var item in coll)
        {
            Add(item);
        }
    }
    public MyHashSet(int capacity, IEqualityComparer<T> comparer): this(capacity)
    {
        if (comparer == null)
        {
            Comparer = EqualityComparer<T>.Default;
            return;
        }
        Comparer = comparer;
    }
    public bool Add(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException();
        } 
        
        var index = GetIndexByHashcode(item);
        if (_storage[index] != null && _storage[index].First(nodeItem => Comparer.Equals(nodeItem, item)) != null)
        {
            return false;
        }
        
        if (Count == _capacity)
        {
            _capacity *= 2;
            var newStorage = new MyLinkedList<T>[_capacity];

            foreach (var linkedList in _storage)
            {
                foreach (var node in linkedList)
                {
                    var ind = GetIndexByHashcode(node);

                    if (newStorage[ind] == null)
                    {
                        newStorage[ind] = new MyLinkedList<T>();
                    }
                    newStorage[ind].AddLast(new MyLinkedListNode<T>(node));
                }
            }
            _storage = newStorage;
        }
        if (_storage[index] == null)
        {
            _storage[index] = new MyLinkedList<T>();
        }
        _orderStorage.AddLast(new MyLinkedListNode<T>(item));
        _storage[index].AddLast(new MyLinkedListNode<T>(item));
        Count++;
        
        return true;
    }

    void ICollection<T>.Add(T item)
    {
        Add(item);
    }
    
    public void Clear()
    {
        _capacity = 0;
        _orderStorage.Clear();
        _storage = new MyLinkedList<T>[] { };
    }

    public bool Contains(T item)
    {
        var index = GetIndexByHashcode(item);
        var bucket = _storage[index];
        if (bucket == null)
        {
            return false;
        }

        return bucket.Find(item) != null;
    }

    public bool Remove(T item)
    {
        var index = GetIndexByHashcode(item);
        var bucket = _storage[index];
        if (bucket == null)
        {
            return false;
        }

        var lengthBefore = bucket.Count;
        bucket.Remove(item);
        _orderStorage.Remove(item);
        var isRemoved = lengthBefore > bucket.Count;
        if (isRemoved)
        {
            Count--;
        }
        return isRemoved;
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
        foreach (var i in _orderStorage)
        {
            yield return i;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private int GetIndexByHashcode(T value)
    {
        var hashcode = Comparer.GetHashCode(value) & 0x7FFFFFFF;
        return hashcode % _capacity;
    }
}