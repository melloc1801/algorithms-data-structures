using System.Collections;

namespace DataStructures;

public class MyHashMap<TKey, TValue>: IMyHashMap<TKey, TValue>
{
    private const int BaseCapacity = 16;
    private readonly MyLinkedList<KeyValuePair<TKey, TValue>> _orderStorage;
    private MyLinkedList<KeyValuePair<TKey, TValue>>[] _storage;
    private int _capacity;
    private double LoadFactor => (double) Count / _capacity;

    public int Count { get; private set; }
    public bool IsReadOnly => false;
    public ICollection<TKey> Keys => _orderStorage.Select(pair => pair.Key).ToArray();
    public ICollection<TValue> Values => _orderStorage.Select(pair => pair.Value).ToArray();

    public TValue this[TKey key]
    {
        get
        {
            if (key == null)
                throw new ArgumentNullException();
            
            var ind = GetIndexByHashCode(key);
            if (_storage[ind] == null)
                throw new KeyNotFoundException();
            var valuesWithKey = _storage[ind]
                .Where(p => p.Key?.Equals(key) ?? false)
                .ToArray();
            if (valuesWithKey.Length < 1)
                throw new KeyNotFoundException();
            return _storage[ind].FirstOrDefault(p => p.Key?.Equals(key) ?? false).Value;
        }
        set
        {
            if (key == null)
                throw new ArgumentNullException();
            
            var ind = GetIndexByHashCode(key);
            if (_storage[ind] == null)
                throw new KeyNotFoundException();
            var pair = _storage[ind].FirstOrDefault(p => p.Key.Equals(key));
            if (pair.Equals(default))
                throw new KeyNotFoundException();

            _storage[ind].Remove(pair);
            _orderStorage.Remove(pair);
            
            var newPair = new KeyValuePair<TKey, TValue>(key, value);
            var newNode = new MyLinkedListNode<KeyValuePair<TKey, TValue>>(newPair);
            _storage[ind].AddLast(newNode);
            _orderStorage.AddLast(newNode);
        }
    }

    public MyHashMap()
    {
        _capacity = BaseCapacity;
        _orderStorage = new MyLinkedList<KeyValuePair<TKey, TValue>>();
        _storage = new MyLinkedList<KeyValuePair<TKey, TValue>>[_capacity];
        Count = 0;
    }
    
    public void Add(TKey key, TValue value)
    {
        if (key == null) throw new ArgumentNullException();
        if (ContainsKey(key))
            throw new ArgumentException();

        if (LoadFactor > 0.7)
        {
            _capacity *= 2;
            var newStorage = new MyLinkedList<KeyValuePair<TKey, TValue>>[_capacity];
            foreach (var myLinkedList in _storage)
            {
                if (myLinkedList == null) continue;
                foreach (var node in myLinkedList)
                {
                    var ind = GetIndexByHashCode(node.Key);
                    newStorage[ind].AddLast(new MyLinkedListNode<KeyValuePair<TKey, TValue>>(node));
                }
            }
            _storage = newStorage;
        }

        var index = GetIndexByHashCode(key);
        if (_storage[index] == null)
            _storage[index] = new MyLinkedList<KeyValuePair<TKey, TValue>>();
        
        var pairs = _storage[index]
            .Where(p => p.Key?.Equals(key) ?? false)
            .ToArray();
        if (pairs.Length > 0) return;

        var pair = new KeyValuePair<TKey, TValue>(key, value);
        var newNode = new MyLinkedListNode<KeyValuePair<TKey, TValue>>(pair); 
        _storage[index].AddLast(newNode);
        _orderStorage.AddLast(newNode);
        Count++;
    }
    
    public void Add(KeyValuePair<TKey, TValue> pair)
    {
        if (pair.Key == null) throw new ArgumentNullException();
        
        var ind = GetIndexByHashCode(pair.Key);
        if (_storage[ind] != null)
        {
            var existPairs = _storage[ind]
                .Where(p => p.Key != null && p.Value != null && p.Key.Equals(pair.Key) && p.Value.Equals(pair.Value))
                .ToArray();
            if (existPairs.Length > 0)
                throw new ArgumentException();
        }
        
        Add(pair.Key, pair.Value);
    }

    public void Clear()
    {
        Count = 0;
        _storage = new MyLinkedList<KeyValuePair<TKey, TValue>>[] {};
        _orderStorage.Clear();
        _capacity = BaseCapacity;
    }

    public bool Contains(KeyValuePair<TKey, TValue> pair)
    {
        var index = GetIndexByHashCode(pair.Key);
        if (_storage[index] == null) return false;

        var candidate = _storage[index].Find(pair);
        if (candidate == null) return false;

        return true;
    }

    public void CopyTo(KeyValuePair<TKey, TValue>[] pairs, int arrayIndex)
    {
        if (pairs == null) throw new ArgumentException();
        if (arrayIndex < 0) throw new ArgumentOutOfRangeException();
        if (pairs.Length - arrayIndex < Count) throw new ArgumentException();
        
        var index = arrayIndex;
        foreach (var pair in _orderStorage)
        {
            if (index >= _orderStorage.Count)
            {
                break;
            }

            pairs[index] = pair;
            index++;
        }
    }
    
    public bool ContainsKey(TKey key)
    {
        if (key == null)
            throw new ArgumentNullException();
        
        var index = GetIndexByHashCode(key);
        if (_storage[index] == null) return false;

        var t = _storage[index]
            .Where(p => p.Key?.Equals(key) ?? false)
            .ToArray();
        
        return t.Length > 0;
    }
    
    public bool TryGetValue(TKey key, out TValue value)
    {
        if (key == null)
            throw new ArgumentNullException();
        
        var ind = GetIndexByHashCode(key);
        if (_storage[ind] == null)
        {
            value = default;
            return false;
        }
        var values = _storage[ind]
            .Where(p => p.Key?.Equals(key) ?? false) 
            .ToArray();

        if (values.Length == 0)
        {
            value = default;
            return false;
        }

        value = values[0].Value;
        return true;
    }

    public bool Remove(KeyValuePair<TKey, TValue> pair)
    {
        var ind = GetIndexByHashCode(pair.Key);
        if (_storage[ind] == null)
        {
            return false;
        }
        var p = _storage[ind].Find(pair);
        if (p == null) return false;
        
        _storage[ind].Remove(pair);
        _orderStorage.Remove(pair);
        return true;
    }

    public bool Remove(TKey key)
    {
        if (key == null)
            throw new ArgumentNullException();
        
        var ind = GetIndexByHashCode(key);
        if (_storage[ind] == null)
            return false;
        var pairsWithKey = _storage[ind]
            .Where(p => p.Key?.Equals(key) ?? false)
            .ToArray();
        if (pairsWithKey.Length == 0) return false;

        var pairToRemove = pairsWithKey.First(p => p.Key.Equals(key));
        
        _storage[ind].Remove(pairToRemove);
        _orderStorage.Remove(pairToRemove);
        return true;
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        foreach (var pair in _orderStorage) yield return pair;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private int GetIndexByHashCode(TKey value)
    {
        return (value.GetHashCode() & 0x7FFFFFFF) % _capacity;
    }
}