using System.Collections;

namespace DataStructures;

public class MyLinkedList<T>: IMyLinkedList<T>
{
    public int Count { get; private set; }
    public IMyLinkedListNode<T> First { get; private set; }
    public IMyLinkedListNode<T> Last { get; private set; }

    public MyLinkedList()
    {
        Count = 0;
        First = null;
        Last = null;
    }

    public MyLinkedList(IEnumerable<T> enumerable)
    {
        if (enumerable == null)
        {
            throw new ArgumentNullException();
        }

        Count = 0;
        foreach (var el in enumerable)
        {
            AddLast(new MyLinkedListNode<T>(el));
        }
    }

    public void AddFirst(IMyLinkedListNode<T> node)
    {
        if(node == null) {
            throw new ArgumentNullException();
        }
        Count++;
        if (Last == null)
        {
            First = node;
            Last = node;
            return;
        }
        node.Next = First;
        First = node;
    }

    public void AddLast(IMyLinkedListNode<T> node)
    {
        if(node == null) {
            throw new ArgumentNullException();
        }
        Count++;
        if (Last == null)
        {
            First = node;
            Last = node;
            return;
        }

        node.Prev = Last;
        Last.Next = node;
        Last = node;
    }

    public void Clear()
    {
        First = null;
        Last = null;
        Count = 0;
    }

    public IMyLinkedListNode<T> Find(T value)
    {
        if (Count == 0)
        {
            return null;
        }
        if (First.Data.Equals(value))
        {
            return First;
        }

        if (Last.Data.Equals(value))
        {
            return Last;
        }
        
        var current = First;
        while (current.Next != null)
        {
            if (current.Data.Equals(value))
            {
                return current;
            }

            current = current.Next;
        }
        
        return null;
    }

    public void Remove(T item)
    {
        if (Count == 0)
        {
            return;
        }
        if (item == null)
        {
            throw new ArgumentNullException();
        }
        if (item.Equals(First.Data))
        {
            RemoveFirst();
            return;
        }

        if (item.Equals(Last.Data))
        {
            RemoveLast();
            return;
        }


        var current = First;
        while (current.Next != null)
        {
            if (current.Data.Equals(item))
            {
                var prev = current.Prev;
                var next = current.Next;
                prev.Next = current.Next;
                next.Prev = prev;
            }

            current = current.Next;
        }
    }

    public void RemoveFirst()
    {
        if (First == null)
        {
            throw new InvalidOperationException();
        }
        
        if (Count == 1)
        {
            First = null;
            Last = null;
            Count--;
            return;
        }

        var newFirst = First.Next;
        newFirst.Prev = null;

        First = newFirst;
        Count--;
    }

    public void RemoveLast()
    {
        if (Last == null)
        {
            throw new InvalidOperationException();
        }
        
        if (Count == 1)
        {
            First = null;
            Last = null;
            Count--;
            return;
        }

        var newLast = Last.Prev;
        newLast.Next = null;
        Last = newLast;
        Count--;
    }

    public T[] ToArray()
    {
        var result = new T[Count];

        var en = GetEnumerator();
        var index = 0;
        while (en.MoveNext())
        {
            result[index] = en.Current;
            index++;
        }

        return result;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return new MyLinkedListEnumerator<T>(First);
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    class MyLinkedListEnumerator<T>: IEnumerator<T>
    {
        private IMyLinkedListNode<T> _currentNode;
        private IMyLinkedListNode<T> _firstNode;

        public MyLinkedListEnumerator(IMyLinkedListNode<T> firstNode)
        {
            _currentNode = null;
            _firstNode = firstNode;
        }
        
        public bool MoveNext()
        {
            if (_firstNode == null)
            {
                return false;
            }
            if (_currentNode == null)
            {
                _currentNode = _firstNode;
                return true;
            }
            if (_currentNode.Next == null)
            {
                return false;
            }

            _currentNode = _currentNode.Next;
            return true;
        }

        public void Reset()
        {
            _currentNode = null;
        }

        public T Current => _currentNode.Data;

        object IEnumerator.Current => Current;

        public void Dispose() { }
    }
}