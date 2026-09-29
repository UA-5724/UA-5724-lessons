using System;
using System.Collections.Generic;

// ---------- Interfaces ----------
interface IFlyable
{
    void Fly();
}

// IComparable<IDeveloper> lets List<IDeveloper>.Sort() sort programmers and builders together
interface IDeveloper : IComparable<IDeveloper>
{
    string Tool { get; }
    void Create();
    void Destroy();
}

// ---------- Classes ----------
class Bird : IFlyable
{
    public string Name;
    public bool CanFly;

    public Bird(string name, bool canFly)
    {
        Name = name;
        CanFly = canFly;
    }

    public void Fly()
    {
        if (CanFly)
            Console.WriteLine($"{Name} is flying.");
        else
            Console.WriteLine($"{Name} cannot fly.");
    }
}

class Plane : IFlyable
{
    public string Mark;
    public int HighFly;

    public Plane(string mark, int highFly)
    {
        Mark = mark;
        HighFly = highFly;
    }

    public void Fly()
    {
        Console.WriteLine($"{Mark} flies at {HighFly} meters.");
    }
}

class Programmer : IDeveloper
{
    public string Language;

    public Programmer(string language)
    {
        Language = language;
    }

    // Programmer's tool is the programming language
    public string Tool => Language;

    public void Create()
    {
        Console.WriteLine($"Programmer creates code in {Language}.");
    }

    public void Destroy()
    {
        Console.WriteLine($"Programmer deletes code in {Language}.");
    }

    public int CompareTo(IDeveloper? other)
    {
        return DeveloperComparer.CompareByTool(this, other);
    }
}

class Builder : IDeveloper
{
    private string tool;

    public Builder(string tool)
    {
        this.tool = tool;
    }

    public string Tool => tool;

    public void Create()
    {
        Console.WriteLine($"Builder builds using {tool}.");
    }

    public void Destroy()
    {
        Console.WriteLine($"Builder destroys using {tool}.");
    }

    public int CompareTo(IDeveloper? other)
    {
        return DeveloperComparer.CompareByTool(this, other);
    }
}

static class DeveloperComparer
{
    public static int CompareByTool(IDeveloper current, IDeveloper? other)
    {
        if (other is null)
            return 1;

        return string.Compare(current.Tool, other.Tool, StringComparison.OrdinalIgnoreCase);
    }
}

// ---------- Program ----------
class Program
{
    static void Main()
    {
        int task = ReadInt("Choose task (1-4): ");

        switch (task)
        {
            case 1:
                Task1();
                break;
            case 2:
                Task2();
                break;
            case 3:
                Task3();
                break;
            case 4:
                Task4();
                break;
            default:
                Console.WriteLine("Invalid task.");
                break;
        }
    }

    // Homework 6.1
    static void Task1()
    {
        Console.WriteLine("=== IFlyable ===");

        List<IFlyable> items = new List<IFlyable>()
        {
            new Bird("Eagle", true),
            new Bird("Penguin", false),
            new Bird("Parrot", true),
            new Plane("Boeing 737", 10000),
            new Plane("Airbus A320", 12000)
        };

        foreach (IFlyable item in items)
        {
            item.Fly();
        }
    }

    // Homework 6.2
    static void Task2()
    {
        Console.WriteLine("=== Collections ===");

        List<int> myColl = new List<int>();

        Console.WriteLine("Enter 10 integers:");

        for (int i = 0; i < 10; i++)
        {
            myColl.Add(ReadInt($"Number {i + 1}: "));
        }

        Console.WriteLine("\nIndexes of -10:");
        bool found = false;

        for (int i = 0; i < myColl.Count; i++)
        {
            if (myColl[i] == -10)
            {
                Console.WriteLine(i);
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("Not found.");

        myColl.RemoveAll(x => x > 20);

        Console.WriteLine("\nAfter removing values > 20:");
        foreach (int n in myColl)
            Console.Write(n + " ");

        Console.WriteLine();

        // After removing values > 20 the list can be shorter than the position,
        // and Insert() would throw ArgumentOutOfRangeException. Then the value goes to the end.
        InsertAt(myColl, 2, 1);
        InsertAt(myColl, 8, -3);
        InsertAt(myColl, 5, -4);

        Console.WriteLine("\nAfter inserting:");
        foreach (int n in myColl)
            Console.Write(n + " ");

        Console.WriteLine();

        myColl.Sort();

        Console.WriteLine("\nSorted collection:");
        foreach (int n in myColl)
            Console.Write(n + " ");

        Console.WriteLine();
    }

    // Homework 6.3
    static void Task3()
    {
        Console.WriteLine("=== Developers ===");

        List<IDeveloper> developers = new List<IDeveloper>()
        {
            new Programmer("C#"),
            new Programmer("Python"),
            new Programmer("Java"),
            new Builder("Hammer"),
            new Builder("Drill"),
            new Builder("Saw")
        };

        foreach (IDeveloper dev in developers)
        {
            dev.Create();
            dev.Destroy();
            Console.WriteLine($"Tool: {dev.Tool}\n");
        }

        developers.Sort();

        Console.WriteLine("Developers sorted by tool:");
        foreach (IDeveloper dev in developers)
            Console.WriteLine($"{dev.GetType().Name}: {dev.Tool}");
    }

    // Homework 6.4
    static void Task4()
    {
        Console.WriteLine("=== Dictionary ===");

        Dictionary<uint, string> persons = new Dictionary<uint, string>();

        Console.WriteLine("Enter 7 pairs (ID Name):");

        for (int i = 0; i < 7; i++)
        {
            uint id = ReadUInt("ID: ");

            if (persons.ContainsKey(id))
            {
                Console.WriteLine($"ID {id} already exists. Enter another one.");
                i--;
                continue;
            }

            Console.Write("Name: ");
            string name = Console.ReadLine() ?? string.Empty;

            persons[id] = name;
        }

        uint searchId = ReadUInt("\nEnter ID to search: ");

        if (persons.TryGetValue(searchId, out string? foundName))
        {
            Console.WriteLine($"Name: {foundName}");
        }
        else
        {
            Console.WriteLine("ID not found.");
        }
    }

    static void InsertAt(List<int> list, int position, int value)
    {
        if (position > list.Count)
        {
            Console.WriteLine($"Position {position} is out of range, {value} is added to the end.");
            position = list.Count;
        }

        list.Insert(position, value);
    }

    static int ReadInt(string message)
    {
        Console.Write(message);

        int value;
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.Write("Invalid number. Try again: ");
        }

        return value;
    }

    static uint ReadUInt(string message)
    {
        Console.Write(message);

        uint value;
        while (!uint.TryParse(Console.ReadLine(), out value))
        {
            Console.Write("ID must be a non-negative integer. Try again: ");
        }

        return value;
    }
}