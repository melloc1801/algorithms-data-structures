using System.Collections;

namespace DataStructures;
public class MyHashSet<T>: IMyHashSetGeneric<T>
{
    private const int BaseCapacity = 16;
    private T[] _orderStorage;
    private MyLinkedList<T>[] _storage;
    private int _capacity; 
    public IEqualityComparer<T> Comparer { get; }

    public int Count { get; private set; }

    public MyHashSet()
    {
        _capacity = BaseCapacity;
        _orderStorage = new T[_capacity];
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
        _orderStorage = new T[_capacity];
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
        _orderStorage = new T[_capacity];
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
        if (_storage[index] != null && _storage[index].Any(node => Comparer.Equals(node.Data, item)))
        {
            return false;
        }
        
        if (Count == _capacity)
        {
            _capacity *= 2;
            var newStorage = new MyLinkedList<T>[_capacity];
            var newOrderStorage = new T[_capacity];

            foreach (var linkedList in _storage)
            {
                foreach (var node in linkedList)
                {
                    var ind = GetIndexByHashcode(node.Data);

                    if (newStorage[ind] == null)
                    {
                        newStorage[ind] = new MyLinkedList<T>();
                    }
                    newStorage[ind].AddLast(new MyLinkedListNode<T>(node.Data));
                }
            }

            for (int i = 0; i < _orderStorage.Length; i++)
            {
                newOrderStorage[i] = _orderStorage[i];
            }

            _storage = newStorage;
            _orderStorage = newOrderStorage;
        }
        if (_storage[index] == null)
        {
            _storage[index] = new MyLinkedList<T>();
        }
        _orderStorage[Count] = item;
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
        _orderStorage = Array.Empty<T>();
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

        return bucket.Any(node => Comparer.Equals(node.Data, item));
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
        return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    class Enumerator: IEnumerator<T>
    {
        private int _position = -1;
        private MyHashSet<T> _currentInstance;

        public Enumerator(MyHashSet<T> currentInstance)
        {
            _currentInstance = currentInstance;
        }
        
        public bool MoveNext()
        {
            if (_position + 1 == _currentInstance.Count)
            {
                return false;
            }
            if (_currentInstance._orderStorage.Length > 0)
            {
                _position++;
                return true;
            }

            return false;
        }


        public T Current => _currentInstance._orderStorage[_position];

        object IEnumerator.Current => Current;
        
        public void Reset()
        { }
        
        public void Dispose()
        {
        }
    }

    private int GetIndexByHashcode(T value)
    {
        var hashcode = Comparer.GetHashCode(value) & 0x7FFFFFFF;
        return hashcode % _capacity;
    }
}