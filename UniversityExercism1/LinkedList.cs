using System;

public class Deque<T>
{
    private Node? head;
    private Node? tail;

    public void Push(T value)
    {
        var node = new Node(value) { Previous = tail };

        if (tail is null)
            head = node;
        else
            tail.Next = node;

        tail = node;
    }

    public T Pop()
    {
        Node node = tail ?? throw new InvalidOperationException("The deque is empty.");
        tail = node.Previous;

        if (tail is null)
            head = null;
        else
            tail.Next = null;

        return node.Value;
    }

    public void Unshift(T value)
    {
        var node = new Node(value) { Next = head };

        if (head is null)
            tail = node;
        else
            head.Previous = node;

        head = node;
    }

    public T Shift()
    {
        Node node = head ?? throw new InvalidOperationException("The deque is empty.");
        head = node.Next;

        if (head is null)
            tail = null;
        else
            head.Previous = null;

        return node.Value;
    }

    private sealed class Node
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; }
        public Node? Previous { get; set; }
        public Node? Next { get; set; }
    }
}
