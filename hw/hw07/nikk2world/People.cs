// Task 1: Person, Staff, Teacher, Developer

class Person
{
    private string name;

    public Person(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get { return name; }
    }

    public virtual void Print()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"Person: {name}";
    }
}

class Staff : Person
{
    private decimal salary;

    public Staff(string name, decimal salary) : base(name)
    {
        this.salary = salary;
    }

    public decimal Salary
    {
        get { return salary; }
    }

    public override string ToString()
    {
        return $"Staff: {Name}, Salary: {salary}";
    }
}

class Teacher : Staff
{
    private string subject;

    public Teacher(string name, string subject, decimal salary) : base(name, salary)
    {
        this.subject = subject;
    }

    public string Subject
    {
        get { return subject; }
    }

    public override void Print()
    {
        Console.WriteLine($"Teacher {Name} teaches {subject}. Salary: {Salary}");
    }

    public override string ToString()
    {
        return $"Teacher: {Name}, Subject: {subject}, Salary: {Salary}";
    }
}

enum DeveloperLevel
{
    Junior,
    Middle,
    Senior
}

class Developer : Staff
{
    private DeveloperLevel level;

    public Developer(string name, DeveloperLevel level, decimal salary) : base(name, salary)
    {
        this.level = level;
    }

    public DeveloperLevel Level
    {
        get { return level; }
    }

    public override void Print()
    {
        Console.WriteLine($"Developer {Name} is a {level} developer. Salary: {Salary}");
    }

    public override string ToString()
    {
        return $"Developer: {Name}, Level: {level}, Salary: {Salary}";
    }
}
