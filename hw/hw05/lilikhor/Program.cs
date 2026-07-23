using System;

class Car
{
    private string name;
    private string color;
    private double price;

    public const string CompanyName = "AutoCompany";

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public Car()
    {
        name = "Unknown";
        color = "Unknown";
        price = 0;
    }

    public Car(string name, string color, double price)
    {
        this.name = name;
        this.color = color;
        this.price = price;
    }

    public void Input()
    {
        Console.Write("Enter car name: ");
        name = Console.ReadLine();

        Console.Write("Enter car color: ");
        color = Console.ReadLine();

        while (true)
        {
            Console.Write("Enter car price: ");

            if (double.TryParse(Console.ReadLine(), out price) && price >= 0)
                break;

            Console.WriteLine("Invalid price. Try again.");
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
        return $"Name: {name}, Color: {color}, Price: {price}, Company: {CompanyName}";
    }

    public static bool operator ==(Car a, Car b)
    {
        if (ReferenceEquals(a, b))
            return true;

        if (a is null || b is null)
            return false;

        return a.name == b.name && a.price == b.price;
    }

    public static bool operator !=(Car a, Car b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        return obj is Car otherCar && this == otherCar;
    }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + (name == null ? 0 : name.GetHashCode());
        hash = hash * 23 + price.GetHashCode();
        return hash;
    }
}

class Person
{
    private string name;
    private DateTime birthYear;

    public string Name
    {
        get { return name; }
    }

    public DateTime BirthYear
    {
        get { return birthYear; }
    }

    public Person()
    {
        name = "Unknown";
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

        if (DateTime.Now < birthYear.AddYears(age))
            age--;

        return age;
    }

    public void Input()
    {
        Console.Write("Enter name: ");
        name = Console.ReadLine();

        while (true)
        {
            Console.Write("Enter birth date (yyyy-mm-dd): ");

            if (DateTime.TryParse(Console.ReadLine(), out birthYear))
                break;

            Console.WriteLine("Invalid date. Try again.");
        }
    }

    public void ChangeName(string newName)
    {
        name = newName;
    }

    public override string ToString()
    {
        return $"Name: {name}, Birth date: {birthYear.ToShortDateString()}, Age: {Age()}";
    }

    public void Output()
    {
        Console.WriteLine(ToString());
    }

    public static bool operator ==(Person a, Person b)
    {
        if (ReferenceEquals(a, b))
            return true;

        if (a is null || b is null)
            return false;

        return a.name == b.name;
    }

    public static bool operator !=(Person a, Person b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        return obj is Person otherPerson && this == otherPerson;
    }

    public override int GetHashCode()
    {
        return name == null ? 0 : name.GetHashCode();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Task 1: Car

        Car[] cars = new Car[3];

        for (int i = 0; i < cars.Length; i++)
        {
            Console.WriteLine($"\nEnter data for car {i + 1}:");
            cars[i] = new Car();
            cars[i].Input();
        }

        Console.WriteLine("\nCars after 10% price decrease:");

        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].ChangePrice(-10);
            cars[i].Print();
        }

        Console.Write("\nEnter new color for white cars: ");
        string newColor = Console.ReadLine();

        for (int i = 0; i < cars.Length; i++)
        {
            if (cars[i].Color.ToLower() == "white")
            {
                cars[i].Color = newColor;
            }
        }

        Console.WriteLine("\nCars after repainting:");
        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].Print();
        }

        Console.WriteLine("\nEqual cars:");
        for (int i = 0; i < cars.Length; i++)
        {
            for (int j = i + 1; j < cars.Length; j++)
            {
                if (cars[i] == cars[j])
                {
                    Console.WriteLine(cars[i]);
                    Console.WriteLine(cars[j]);
                }
            }
        }


        // Task 2: Person

        Person[] people = new Person[6];

        for (int i = 0; i < people.Length; i++)
        {
            Console.WriteLine($"\nEnter data for person {i + 1}:");
            people[i] = new Person();
            people[i].Input();
        }

        Console.WriteLine("\nNames and ages:");
        for (int i = 0; i < people.Length; i++)
        {
            Console.WriteLine($"Name: {people[i].Name}, Age: {people[i].Age()}");
        }

        for (int i = 0; i < people.Length; i++)
        {
            if (people[i].Age() < 16)
            {
                people[i].ChangeName("Very Young");
            }
        }

        Console.WriteLine("\nUpdated information:");
        for (int i = 0; i < people.Length; i++)
        {
            people[i].Output();
        }

        Console.WriteLine("\nPersons with same names:");
        bool foundSameNames = false;

        for (int i = 0; i < people.Length; i++)
        {
            for (int j = i + 1; j < people.Length; j++)
            {
                if (people[i] == people[j])
                {
                    people[i].Output();
                    people[j].Output();
                    foundSameNames = true;
                }
            }
        }

        if (!foundSameNames)
        {
            Console.WriteLine("No persons with same names found.");
        }
    }
}