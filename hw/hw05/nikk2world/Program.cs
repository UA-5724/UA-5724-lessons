using System;

class Car
{
    // Fields are private (encapsulation), access goes through properties
    private string name;
    private string color;
    private double price;
    public const string CompanyName = "Tesla";

    // Default constructor
    public Car()
    {
        name = "";
        color = "";
        price = 0;
    }

    // Constructor with parameters
    public Car(string name, string color, double price)
    {
        this.name = name;
        this.color = color;
        this.price = price;
    }

    // Properties
    public string Name
    {
        get { return name; }
    }

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public double Price
    {
        get { return price; }
    }

    public void Input()
    {
        Console.Write("Car name: ");
        name = Console.ReadLine() ?? string.Empty;

        Console.Write("Color: ");
        color = Console.ReadLine() ?? string.Empty;

        Console.Write("Price: ");
        while (!double.TryParse(Console.ReadLine(), out price))
        {
            Console.Write("Invalid price. Try again: ");
        }
    }

    public void Print()
    {
        Console.WriteLine(ToString());
    }

    public void ChangePrice(double x)
    {
        price += price * x / 100;
    }

    public override string ToString()
    {
        return $"Company: {CompanyName}, Name: {name}, Color: {color}, Price: {price}";
    }

    public static bool operator ==(Car? a, Car? b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;

        return a.name == b.name && a.price == b.price;
    }

    public static bool operator !=(Car? a, Car? b)
    {
        return !(a == b);
    }

    public override bool Equals(object? obj)
    {
        if (obj is Car other)
            return this == other;

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(name, price);
    }
}

class Person
{
    private string name;
    private DateTime birthYear;

    // Properties
    public string Name => name;
    public DateTime BirthYear => birthYear;

    // Constructors
    public Person()
    {
        name = "";
        birthYear = DateTime.Now;
    }

    public Person(string name, DateTime birthYear)
    {
        this.name = name;
        this.birthYear = birthYear;
    }

    public int Age()
    {
        int age = DateTime.Now.Year - birthYear.Year;

        if (DateTime.Now.DayOfYear < birthYear.DayOfYear)
            age--;

        return age;
    }

    public void Input()
    {
        Console.Write("Name: ");
        name = Console.ReadLine() ?? string.Empty;

        Console.Write("Birth year (yyyy): ");
        int year;

        // DateTime supports years 1..9999, a birth year cannot be in the future
        while (!int.TryParse(Console.ReadLine(), out year) || year < 1 || year > DateTime.Now.Year)
        {
            Console.Write("Invalid year. Try again: ");
        }

        birthYear = new DateTime(year, 1, 1);
    }

    public void ChangeName(string newName)
    {
        name = newName;
    }

    public override string ToString()
    {
        return $"Name: {name}, Age: {Age()}";
    }

    public void Output()
    {
        Console.WriteLine(ToString());
    }

    public static bool operator ==(Person? a, Person? b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;

        return a.name == b.name;
    }

    public static bool operator !=(Person? a, Person? b)
    {
        return !(a == b);
    }

    public override bool Equals(object? obj)
    {
        if (obj is Person other)
            return this == other;

        return false;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        // ---------- TASK 1 ----------
        Console.WriteLine("=== TASK 1: Cars ===");

        Car[] cars = new Car[3];

        for (int i = 0; i < cars.Length; i++)
        {
            Console.WriteLine($"\nEnter car {i + 1}");
            cars[i] = new Car();
            cars[i].Input();
        }

        Console.WriteLine("\nCars:");
        foreach (Car car in cars)
        {
            car.Print();
        }

        Console.WriteLine("\nDecrease price by 10%");
        foreach (Car car in cars)
        {
            car.ChangePrice(-10);
            car.Print();
        }

        Console.Write("\nEnter new color: ");
        string newColor = Console.ReadLine() ?? string.Empty;

        foreach (Car car in cars)
        {
            if (string.Equals(car.Color, "white", StringComparison.OrdinalIgnoreCase))
            {
                car.Color = newColor;
            }
        }

        Console.WriteLine("\nAfter repaint:");
        foreach (Car car in cars)
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\nCompare first two cars:");
        Console.WriteLine(cars[0] == cars[1] ? "Equal" : "Not equal");

        // ---------- TASK 2 ----------
        Console.WriteLine("\n=== TASK 2: Persons ===");

        Person[] people = new Person[6];

        for (int i = 0; i < people.Length; i++)
        {
            Console.WriteLine($"\nEnter person {i + 1}");
            people[i] = new Person();
            people[i].Input();
        }

        Console.WriteLine("\nPersons:");
        foreach (Person person in people)
        {
            person.Output();
        }

        foreach (Person person in people)
        {
            if (person.Age() < 16)
            {
                person.ChangeName("Very Young");
            }
        }

        Console.WriteLine("\nUpdated persons:");
        foreach (Person person in people)
        {
            person.Output();
        }

        Console.WriteLine("\nPersons with same names:");

        bool found = false;

        for (int i = 0; i < people.Length; i++)
        {
            for (int j = i + 1; j < people.Length; j++)
            {
                if (people[i] == people[j])
                {
                    Console.WriteLine($"{people[i].Name} = {people[j].Name}");
                    found = true;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("No persons with same names.");
        }
    }
}