class Program
{
    static void Main()
    {
        Console.WriteLine("===== Task 1. Person, Staff, Teacher, Developer =====");
        Task1();

        Console.WriteLine("\n===== Task 2. Shapes =====");
        Task2();
    }

    static void Task1()
    {
        List<Person> people = new List<Person>
        {
            new Person("John"),
            new Teacher("Alice", "Math", 25000),
            new Developer("Bob", DeveloperLevel.Senior, 90000),
            new Person("Kate"),
            new Teacher("Diana", "Physics", 27000),
            new Developer("Andrew", DeveloperLevel.Junior, 35000),
            new Developer("Charlie", DeveloperLevel.Middle, 60000)
        };

        // Polymorphism: every object calls its own Print()
        Console.WriteLine("All people:");
        foreach (var person in people)
        {
            person.Print();
        }

        // Search by name
        Console.Write("\nEnter name to search: ");
        string name = (Console.ReadLine() ?? string.Empty).Trim();

        var found = people.Where(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase)).ToList();

        if (found.Count > 0)
        {
            foreach (var person in found)
            {
                person.Print();
            }
        }
        else
        {
            Console.WriteLine($"Person with name \"{name}\" was not found.");
        }

        // Sort by name and save to file
        var sortedByName = people.OrderBy(p => p.Name).ToList();
        string fileName = "output.txt";

        File.WriteAllLines(fileName, sortedByName.Select(p => p.ToString()));
        Console.WriteLine($"\nSorted list saved to {Path.GetFullPath(fileName)}");

        // Advanced: only workers, sorted by salary
        List<Staff> employees = people.OfType<Staff>().ToList();
        var sortedBySalary = employees.OrderBy(s => s.Salary);

        Console.WriteLine("\nEmployees sorted by salary:");
        foreach (var employee in sortedBySalary)
        {
            employee.Print();
        }
    }

    static void Task2()
    {
        List<Shape> shapes = new List<Shape>
        {
            new Circle("Circle1", 3),
            new Square("Square1", 4),
            new Circle("Circle2", 5),
            new Square("Square2", 2)
        };

        Console.WriteLine("Info:");
        Operator.GetInfo(shapes);

        Console.WriteLine();
        Operator.GetLargestPerimeter(shapes);

        Console.WriteLine("\nSorted by area:");
        Operator.Sort(shapes);
    }
}
