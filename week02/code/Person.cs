using System;

/// <summary>
/// Represents a person in the queue with a name and number of turns.
/// </summary>
public class Person
{
    public string Name { get; }
    public int Turns { get; set; }

    public Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }

    public override string ToString()
    {
        return Name;
    }
}
