using System;
class Car
{
    private string name;
    private string color;
    private double price;

    public const string CompanyName = "Toyota";

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public Car()
    {
        name = "";
        color = "";
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

        Console.Write("Enter color: ");
        color = Console.ReadLine();

        Console.Write("Enter price: ");
        price = Convert.ToDouble(Console.ReadLine());
    }

    public void Print()
    {
        Console.WriteLine($"Company: {CompanyName}");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Color: {color}");
        Console.WriteLine($"Price: {price}");
        Console.WriteLine();
    }

    public void ChangePrice(double x)
    {
        price += price * x / 100;
    }

    public override string ToString()
    {
        return $"Name: {name}, Color: {color}, Price: {price}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Car other)
            return name == other.name && price == other.price;

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(name, price);
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

        if (DateTime.Now < birthYear.AddYears(age))
            age--;

        return age;
    }

    public void Input()
    {
        Console.Write("Enter name: ");
        name = Console.ReadLine();

        Console.Write("Enter birth date (yyyy-MM-dd): ");
        birthYear = DateTime.Parse(Console.ReadLine());
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

    public override bool Equals(object obj)
    {
        if (obj is Person other)
            return name == other.name;

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(name);
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
}

class Program
{
    static void Main()
    {
        Person[] people = new Person[6];

        for (int i = 0; i < people.Length; i++)
        {
            Console.WriteLine($"Person #{i + 1}");
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

        Console.WriteLine("\nUpdated information:");

        foreach (Person person in people)
        {
            person.Output();
        }

        Console.WriteLine("\nPersons with the same names:");

        for (int i = 0; i < people.Length - 1; i++)
        {
            for (int j = i + 1; j < people.Length; j++)
            {
                if (people[i] == people[j])
                {
                    Console.WriteLine($"{people[i].Name} == {people[j].Name}");
                }
            }
        }
    }
}