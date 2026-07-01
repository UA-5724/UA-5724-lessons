using System;
using System.Collections;
class Person
{
    //person fields
    private string name = "";
    private DateTime birthYear;
    public Person() 
    {
    }
    //constructor with parameters
    public Person(string name, DateTime birthYear)
    {
    //Initialize object fields
    this.name = name;
    this.birthYear = birthYear;
    }
    public string Name
    {
        get
        {
            //return the current name
            return name;
        }
    }
    public DateTime BirthYear
    {
        get
        {
            //return the person's birth date
            return birthYear;
        }
    }
    //сalculate the person's age
    public int Age()
    {
        return DateTime.Now.Year - birthYear.Year;
    }
    public void Input()
    {
        //read person data from console
        name = Console.ReadLine()!;
        birthYear = DateTime.Parse(Console.ReadLine()!);
    }
    //Change the person's name
    public void ChangeName(string newName)
    {
        name = newName;
    }
    //compare names
    public static bool operator ==(Person a, Person b)
    {
        if (ReferenceEquals(a, b))
        {  
            return true;
        }

        if (a is null || b is null)
        { 
            return false; 
        }

        return a.name == b.name;
    }
    public static bool operator !=(Person a, Person b)
    {
        return !(a == b);
    }
    //return formatted person info
    public override string ToString()
    {
        return $"Name: {name}, Age: {Age ()}";
    }
    //сompare two persons by name
    public override bool Equals(object? obj)
    {
        if (obj is Person other)
        {
            return name == other.name;
        }

        return false;
    }
    //return hash code based on the person's name
    public override int GetHashCode()
    {
        return HashCode.Combine(name);
    }
    //display person info
    public void Output()
    {
        Console.WriteLine(ToString());
    }
}
class Program
{
    static void Main()
    {
        //create 6 person objects
        Person p1 = new Person();
        Person p2 = new Person();
        Person p3 = new Person();
        Person p4 = new Person();
        Person p5 = new Person();
        Person p6 = new Person();

        //read info for each person
        p1.Input();
        p2.Input();
        p3.Input();
        p4.Input();
        p5.Input();
        p6.Input();
        //rename person younger than 16
        if (p1.Age() < 16)
        {
            p1.ChangeName("Very Young");
        }
        if (p2.Age() < 16)
        {
            p2.ChangeName("Very Young");
        }
        if (p3.Age() < 16)
        {
            p3.ChangeName("Very Young");
        }
        if (p4.Age() < 16)
        {
            p4.ChangeName("Very Young");
        }
        if (p5.Age() < 16)
        {
            p5.ChangeName("Very Young");
        }
        if (p6.Age() < 16)
        {
            p6.ChangeName("Very Young");
        }
        //find persons with same name
        if (p1 == p2)
        {
            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }
        if (p1 == p3)
        {
            Console.WriteLine(p1);
            Console.WriteLine(p3);
        }
        if (p1 == p4)
        {
            Console.WriteLine(p1);
            Console.WriteLine(p4);
        }
        if (p1 == p5)
        {
            Console.WriteLine(p1);
            Console.WriteLine(p5);
        }
        if (p1 == p6)
        {
            Console.WriteLine(p1);
            Console.WriteLine(p6);
        }
        if (p2 == p3)
        {
            Console.WriteLine(p2);
            Console.WriteLine(p3);
        }
        if (p2 == p4)
        {
            Console.WriteLine(p2);
            Console.WriteLine(p4);
        }
        if (p2 == p5)
        {
            Console.WriteLine(p2);
            Console.WriteLine(p5);
        }
        if (p2 == p6)
        {
            Console.WriteLine(p2);
            Console.WriteLine(p6);
        }
        if (p3 == p4)
        {
            Console.WriteLine(p3);
            Console.WriteLine(p4);
        }
        if (p3 == p5)
        {
            Console.WriteLine(p3);
            Console.WriteLine(p5);
        }
        if (p3 == p6)
        {
            Console.WriteLine(p3);
            Console.WriteLine(p6);
        }
        if (p4 == p5)
        {
            Console.WriteLine(p4);
            Console.WriteLine(p5);
        }
        if (p4 == p6)
        {
            Console.WriteLine(p4);
            Console.WriteLine(p6);
        }
        if (p5 == p6)
        {
            Console.WriteLine(p5);
            Console.WriteLine(p6);
        }
        //show person info
        p1.Output();
        p2.Output();
        p3.Output();
        p4.Output();
        p5.Output();
        p6.Output();
    }
}
