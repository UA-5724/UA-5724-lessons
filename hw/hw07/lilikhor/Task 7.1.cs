using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Person
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }

    public virtual void Print()
    {
        Console.WriteLine($"Person: {Name}");
    }

    public override string ToString()
    {
        return $"Person: {Name}";
    }
}

class Staff : Person
{
    public double Salary { get; set; }

    public Staff(string name, double salary)
        : base(name)
    {
        Salary = salary;
    }

    public override void Print()
    {
        Console.WriteLine($"Staff: {Name}, Salary: {Salary}");
    }

    public override string ToString()
    {
        return $"Staff: {Name}, Salary: {Salary}";
    }
}

class Teacher : Staff
{
    public string Subject { get; set; }

    public Teacher(string name, string subject, double salary)
        : base(name, salary)
    {
        Subject = subject;
    }

    public override void Print()
    {
        Console.WriteLine(
            $"Teacher: {Name}, Subject: {Subject}, Salary: {Salary}");
    }

    public override string ToString()
    {
        return $"Teacher: {Name}, Subject: {Subject}, Salary: {Salary}";
    }
}

class Developer : Staff
{
    public string Level { get; set; }

    public Developer(string name, string level, double salary)
        : base(name, salary)
    {
        Level = level;
    }

    public override void Print()
    {
        Console.WriteLine(
            $"Developer: {Name}, Level: {Level}, Salary: {Salary}");
    }

    public override string ToString()
    {
        return $"Developer: {Name}, Level: {Level}, Salary: {Salary}";
    }
}

class Program
{
    static void Main()
    {
        // Create a list containing different Person types
        List<Person> people = new List<Person>
        {
            new Person("John"),
            new Teacher("Alice", "Math", 3500),
            new Developer("Bob", "Senior", 5000),
            new Teacher("Kate", "Physics", 4000),
            new Developer("Mike", "Junior", 2500)
        };

        // Print all people
        Console.WriteLine("=== All People ===");

        foreach (Person person in people)
        {
            person.Print();
        }

        // Search by name
        Console.Write("\nEnter a name to search: ");
        string name = Console.ReadLine();

        Person found = people.FirstOrDefault(
            p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (found != null)
        {
            Console.WriteLine("\n=== Found Person ===");
            found.Print();
        }
        else
        {
            Console.WriteLine("Person not found.");
        }

        // Sort by name
        List<Person> sortedPeople = people
            .OrderBy(p => p.Name)
            .ToList();

        Console.WriteLine("\n=== Sorted by Name ===");

        foreach (Person person in sortedPeople)
        {
            person.Print();
        }

        // Save sorted result to file
        File.WriteAllLines(
            "output.txt",
            sortedPeople.Select(p => p.ToString()));

        Console.WriteLine("\nSorted list saved to output.txt");

        // Advanced task:
        // Get only Staff objects (Teacher + Developer)
        List<Staff> employees = people
            .OfType<Staff>()
            .ToList();

        // Sort employees by salary
        List<Staff> sortedBySalary = employees
            .OrderBy(s => s.Salary)
            .ToList();

        Console.WriteLine("\n=== Employees Sorted by Salary ===");

        foreach (Staff employee in sortedBySalary)
        {
            employee.Print();
        }
    }
}