using System;

class Person
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }

    public virtual void Print()
    {
        Console.WriteLine($"Name: {Name}");
    }

    public override string ToString()
    {
        return $"Name: {Name}";
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
        Console.WriteLine($"Name: {Name}, Salary: {Salary}");
    }

    public override string ToString()
    {
        return $"Name: {Name}, Salary: {Salary}";
    }
}


class Teacher : Staff
{
    public string Subject { get; set; }

    public Teacher(string name, double salary, string subject)
        : base(name, salary)
    {
        Subject = subject;
    }

    public override void Print()
    {
        Console.WriteLine($"Teacher: {Name}, Subject: {Subject}, Salary: {Salary}");
    }

    public override string ToString()
    {
        return $"Teacher: {Name}, Subject: {Subject}, Salary: {Salary}";
    }
}

class Developer : Staff
{
    public string Level { get; set; }

    public Developer(string name, double salary, string level)
        : base(name, salary)
    {
        Level = level;
    }

    public override void Print()
    {
        Console.WriteLine($"Developer: {Name}, Level: {Level}, Salary: {Salary}");
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
        // Створення списку людей
        List<Person> people = new List<Person>
        {
            new Person("Ivan"),
            new Teacher("Iryna", 2500, "Math"),
            new Developer("Igor", 3200, "Senior"),
            new Teacher("Oksana", 2200, "Physics"),
            new Developer("Oleh", 1800, "Junior")
        };

        // Вивести всіх
        Console.WriteLine("=== All People ===");

        foreach (Person person in people)
        {
            person.Print();
        }

        // Пошук за ім'ям
        Console.Write("\nEnter name: ");
        string name = Console.ReadLine();

        Person found = people.FirstOrDefault(p => p.Name == name);

        if (found != null)
        {
            Console.WriteLine("\nFound:");
            found.Print();
        }
        else
        {
            Console.WriteLine("Person not found.");
        }

        // Сортування за ім'ям
        List<Person> sorted = people.OrderBy(p => p.Name).ToList();

        Console.WriteLine("\n=== Sorted by Name ===");

        foreach (Person person in sorted)
        {
            person.Print();
        }

        // Запис у файл
        File.WriteAllLines("output.txt",
            sorted.Select(p => p.ToString()));

        Console.WriteLine("\nData saved to output.txt");

        // Створення списку працівників
        List<Staff> employees = people.OfType<Staff>().ToList();

        // Сортування за зарплатою
        employees = employees.OrderBy(e => e.Salary).ToList();

        Console.WriteLine("\n=== Employees sorted by Salary ===");

        foreach (Staff employee in employees)
        {
            employee.Print();
        }
    }
}
