using System;

/// <summary>
/// This queue is circular. When people are added via AddPerson, they are added to the 
/// back of the queue (FIFO). When GetNextPerson is called, the next person
/// is dequeued, returned, and re-added to the back of the queue if they still have turns left.
/// Turns <= 0 means infinite turns; turns == 1 after last use means remove from queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add a new person to the queue with a name and number of turns
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue.
    /// Re-enqueue if turns remain or infinite.
    /// Throws InvalidOperationException if queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
            throw new InvalidOperationException("No one in the queue.");

        Person person = _people.Dequeue();

        if (person.Turns <= 0)       // infinite turns
        {
            _people.Enqueue(person);
        }
        else if (person.Turns > 1)   // decrement and re-enqueue
        {
            person.Turns--;
            _people.Enqueue(person);
        }
        // else Turns == 1: last turn, do not re-enqueue

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
