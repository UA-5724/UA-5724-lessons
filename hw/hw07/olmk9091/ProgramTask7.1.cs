using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
// Base class that contains common information for all people
class Person
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }

    public virtual void Print()
    {
        Console.WriteLine(ToString());
    }
    // Return a text representation of the object
    public override string ToString()
    {
        return $"Person: {Name}";
    }
}

// Represents an employee and adds salary information
class Staff : Person
{
    public decimal Salary { get; set; }

    public Staff(string name, decimal salary)
        : base(name)
    {
        Salary = salary;
    }

    public override void Print()
    {
        Console.WriteLine(ToString());
    }
    // Return a text representation of the object
    public override string ToString()
    {
        return $"Staff: {Name}, salary: {Salary}";
    }
}

// Represents a teacher and adds a subject
class Teacher : Staff
{
    public string Subject { get; set; }

    public Teacher(string name, string subject, decimal salary)
        : base(name, salary)
    {
        Subject = subject;
    }
    // Print teacher-specific information
    public override void Print()
    {
        Console.WriteLine(ToString());
    }
    // Return full information about the teacher
    public override string ToString()
    {
        return $"Teacher: {Name}, subject: {Subject}, salary: {Salary:F2}";
    }
}

// Represents a developer and adds a professional level
class Developer : Staff
{
    public string Level { get; set; }

    public Developer(string name, string level, decimal salary)
        : base(name, salary)
    {
        Level = level;
    }
    // Print developer-specific information
    public override void Print()
    {
        Console.WriteLine(ToString());
    }
    // Return a text representation of the object
    public override string ToString()
    {
        return $"Developer: {Name}, level: {Level}, salary: {Salary}";
    }
}

class Program
{
    static void Main()
    {
        // Create one collection that stores objects of different Person types
        List<Person> people = new List<Person>
        {
            new Person("John"),
            new Teacher("Alice", "Math", 2500),
            new Developer("Bob", "Senior", 4000),
            new Teacher("Kate", "English", 2800),
            new Developer("David", "Junior", 2200)
        };

        Console.WriteLine("\nAll people:");
        // Polymorphism: the correct Print() method is called for each real object type
        foreach (Person person in people)
        {
            person.Print();
        }

        // Search for a person by name, ignoring letter case
        Console.Write("\nEnter name: ");
        string searchName = Console.ReadLine() ?? "";
        // Return the first matching person or null if no match is found
        Person? found = people.FirstOrDefault(
            person => person.Name.Equals(
                searchName,
                StringComparison.OrdinalIgnoreCase));
        // Print full information if the person was found
        if (found != null)
        {
            Console.WriteLine("\nFound:");
            found.Print();
        }
        else
        {
            Console.WriteLine("\nPerson not found.");
        }
        // Create a new list sorted alphabetically by name
        List<Person> sortedByName = people
            .OrderBy(person => person.Name)
            .ToList();
        // Convert every object to text and save the sorted result to a file
        File.WriteAllLines(
            "output.txt",
            sortedByName.Select(person => person.ToString()));
        Console.WriteLine("\nSorted data was saved to output.txt.");
        // Filter employees and sort them by salary in ascending order
        List<Staff> employees = people
            .OfType<Staff>()
            .OrderBy(employee => employee.Salary)
            .ToList();
        Console.WriteLine("\nEmployees sorted by salary:");
        // Display employees from the lowest salary to the highest
        foreach (Staff employee in employees)
        {
            employee.Print();
        }
    }
}
