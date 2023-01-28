using System.Collections;

namespace DataStructures;

public class MyList<T>: IMyList<T>
{
    private T[] _storage;
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            return _storage[index];
        }
        set
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            _storage[index] = value;
        }
    }

    public int Count { get; private set; }
    public int Capacity { get; private set; }

    public MyList()
    {
        _storage = Array.Empty<T>();
        Count = 0;
        Capacity = 0;
    }

    public MyList(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        _storage = new T[capacity];
        Count = 0;
        Capacity = capacity;
    }

    public MyList(T[] value)
    {
        _storage = new T[value.Length];
        for (int i = 0; i < value.Length; i++)
        {
            var el = value[i];
            _storage[i] = el;
        }
        Count = value.Length;
        Capacity = value.Length;
    }

    public void Add(T item)
    {
        if (Count == Capacity)
        {
            var newCapacity = Capacity == 0 ? 4 : Capacity * 2;
            var newStorage = new T[newCapacity];
            for (int i = 0; i < Capacity; i++)
            {
                newStorage[i] = _storage[i];
            }

            _storage = newStorage;
            Capacity = newCapacity;
        }
        
        _storage[Count] = item;
        Count += 1; 
    }

    public T Find(Predicate<T> match)
    {
        for (int i = 0; i < Count; i++)
        {
            var el = _storage[i];
            if (match(el))
            {
                return el;
            }
        }
        
        T candidate;
        return default;
    }

    public IMyList<T> FindAll(Predicate<T> match)
    {
        var res = new MyList<T>();
        for (int i = 0; i < Count; i++)
        {
            var el = _storage[i];
            if (match(el))
            {
                res.Add(el);
            }
        }

        return res;
    }

    public int FindIndex(Predicate<T> match)
    {
        for (int i = 0; i < Count; i++)
        {
            var el = _storage[i];
            if (match(el))
            {
                return i;
            }
        }
        
        return -1;
    }

    public bool Remove(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            var el = _storage[i];

            if (el.Equals(item))
            {
                RemoveAt(i);
                return true;
            }
        }

        return false;
    }

    public int RemoveAll(Predicate<T> match)
    {
        var counter = 0;
        for (int i = 0; i < Count; i++)
        {
            var el = _storage[i];

            if (match(el))
            {
                RemoveAt(i);
                i--;
                counter++;
            }
        }

        return counter;
    }
    
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (_storage.Length > 1)
        {
            var fromIndexToEnd = Count - index;
            for (int i = index + 1; i <= fromIndexToEnd; i++)
            {
                _storage[i - 1] = _storage[i];
            }    
        }
        
        Count--;
    }

    public T[] ToArray()
    {
        var res = new T[Count];

        for (int i = 0; i < Count; i++)
        {
            res[i] = _storage[i];
        }

        return res;
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return new MyListEnumerator(_storage, Count);
    }

    class MyListEnumerator: IEnumerator<T>
    {
        private int _position = -1;
        private readonly T[] _list;
        private readonly int _count;
        
        public MyListEnumerator(T[] list, int count)
        {
            _list = list;
            _count = count;
        }
        
        public bool MoveNext()
        {
            if (_position >= _count - 1)
            {
                return false;
            }
        
            _position++;
            return true;
        }

        public void Reset()
        {
            _position = -1;
        }

        public T Current => _list[_position];

        object IEnumerator.Current => Current;

        public void Dispose() {}
    }
}