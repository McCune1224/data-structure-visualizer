
using System.Collections;
using System.Collections.Generic;

namespace Graph;

internal class Node<Value>
{
    public Value Item;
    public Node<Value> Next;
    public Node(Value val)
    {
        Item = val;
    }
    public Node(Value val, Node<Value> next)
    {
        Item = val;
        Next = next;
    }
    public Node()
    {

    }
}

public class Bag<Item> : IEnumerable<Item>
{

    public Bag()
    {

    }

    private Node<Item> _head;
    private int _count = 0;

    public void Add(Item item)
    {
        Node<Item> oldHead = _head;
        _head = new Node<Item>();
        _head.Item = item;
        _head.Next = oldHead;
        _count++;
    }

    public bool IsEmpty() { return _head == null; }
    public int GetSize()
    {
        int tally = 0;
        Node<Item> current = _head;
        while (current != null)
        {
            tally++;
            current = current.Next;
        }
        return tally;
    }

    public IEnumerator<Item> GetEnumerator()
    {
        return new ListIterator(_head);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new ListIterator(_head);
    }

    internal class ListIterator : IEnumerator<Item>
    {
        private Node<Item> _current;
        private Node<Item> _first;

        public ListIterator(Node<Item> firstIterableItem)
        {
            _first = firstIterableItem;
            _current = null;
        }

        public Item Current => _current.Item;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_current == null)
                _current = _first;
            else
                _current = _current.Next;
            return _current != null;
        }

        public void Reset()
        {
            _current = null;
        }

        //TODO: Idk if this matters to implement ngl...
        public void Dispose() { }
    }
}
