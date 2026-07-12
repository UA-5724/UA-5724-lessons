using System;
using System.Collections.Generic;

// Interface
public interface IDeveloper : IComparable<IDeveloper>
{
    string Tool { get; }

    void Create();
    void Destroy();
}

// Programmer class
public class Programmer : IDeveloper
{
    private string language;

    public Programmer(string language)
    {
        this.language = language;
    }

    public string Tool
    {
        get { return language; }
    }

    public void Create()
    {
        Console.WriteLine($"Programmer creates a program using {language}.");
    }

    public void Destroy()
    {
        Console.WriteLine($"Programmer deletes a program written in {language}.");
    }

    public int CompareTo(IDeveloper other)
    {
        return Tool.CompareTo(other.Tool);
    }
}

// Builder class
public class Builder : IDeveloper
{
    private string tool;

    public Builder(string tool)
    {
        this.tool = tool;
    }

    public string Tool
    {
        get { return tool; }
    }

    public void Create()
    {
        Console.WriteLine($"Builder creates something using {tool}.");
    }

    public void Destroy()
    {
        Console.WriteLine($"Builder destroys something using {tool}.");
    }

    public int CompareTo(IDeveloper other)
    {
        return Tool.CompareTo(other.Tool);
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        List<IDeveloper> developers = new List<IDeveloper>()
        {
            new Programmer("C#"),
            new Programmer("Python"),
            new Builder("Hammer"),
            new Builder("Drill")
        };

        Console.WriteLine("Before sorting:\n");

        foreach (IDeveloper dev in developers)
        {
            Console.WriteLine("Tool: " + dev.Tool);
            dev.Create();
            dev.Destroy();
            Console.WriteLine();
        }

        developers.Sort();

        Console.WriteLine("After sorting:\n");

        foreach (IDeveloper dev in developers)
        {
            Console.WriteLine(dev.Tool);
        }

        Console.ReadKey();
    }
}