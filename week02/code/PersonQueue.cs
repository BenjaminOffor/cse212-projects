using System;
using System.Collections.Generic;

/// <summary>
/// A basic implementation of a queue for Person objects.
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the back of the queue.
    /// </summary>
    public void Enqueue(Person person)
    {
        _queue.Add(person);
    }

    /// <summary>
    /// Remove a person from the front of the queue.
    /// Throws InvalidOperationException if queue is empty.
    /// </summary>
    public Person Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        var person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    public bool IsEmpty() => _queue.Count == 0;

    public override string ToString() => $"[{string.Join(", ", _queue)}]";
}
