using System;
using System.Collections.Generic;

/// <summary>
/// Maintains a queue where each item has a priority.
/// Highest priority is dequeued first; FIFO among same priority.
/// </summary>
public class PriorityQueue
{
    private readonly List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value with associated priority.
    /// Always added to back of queue.
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    /// <summary>
    /// Remove and return value with highest priority.
    /// FIFO among same priority.
    /// Throws InvalidOperationException if queue is empty.
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        int highIndex = 0;
        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority > _queue[highIndex].Priority)
                highIndex = i;
        }

        string value = _queue[highIndex].Value;
        _queue.RemoveAt(highIndex);
        return value;
    }

    public override string ToString() => $"[{string.Join(", ", _queue)}]";
}

/// <summary>
/// Helper class for PriorityQueue
/// </summary>
internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString() => $"{Value} (Pri:{Priority})";
}
