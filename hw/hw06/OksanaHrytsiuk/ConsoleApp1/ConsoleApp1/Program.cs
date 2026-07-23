using System;
using System.Collections.Generic;

//Task 1
public interface IFlyable
{
    void Fly();
}

public class Bird : IFlyable
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
            Console.WriteLine($"{Name} flies.");
        else
            Console.WriteLine($"{Name} cannot fly.");
    }
}

public class Plane : IFlyable
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

class Program
{
    static void Main()
    {
        List<IFlyable> items = new List<IFlyable>()
        {
            new Bird("Eagle", true),
            new Bird("Penguin", false),
            new Plane("Boeing", 10000),
            new Plane("Airbus", 12000)
        };

        foreach (var item in items)
        {
            item.Fly();
        }
    }
}