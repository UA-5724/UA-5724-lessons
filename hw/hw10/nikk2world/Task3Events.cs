using System.Text.Json.Serialization;

// Task 3: Delegates & Events

public delegate void MyDel(int m);

public class Student
{
    public const int MinMark = 1;
    public const int MaxMark = 12;

    private readonly string name;
    private readonly List<int> marks;

    public event MyDel? MarkChange;

    public Student(string name)
    {
        this.name = name;
        marks = new List<int>();
    }

    // Used by System.Text.Json when reading a student from JSON (Task 4)
    [JsonConstructor]
    public Student(string name, IReadOnlyList<int> marks)
    {
        this.name = name;
        this.marks = new List<int>();

        foreach (int mark in marks)
        {
            ValidateMark(mark);
            this.marks.Add(mark);
        }
    }

    public string Name => name;

    public IReadOnlyList<int> Marks => marks.AsReadOnly();

    public void AddMark(int mark)
    {
        ValidateMark(mark);
        marks.Add(mark);

        // Notify all subscribers (null if nobody is subscribed)
        MarkChange?.Invoke(mark);
    }

    public override string ToString()
    {
        return $"Student {name}, marks: [{string.Join(", ", marks)}]";
    }

    private static void ValidateMark(int mark)
    {
        if (mark < MinMark || mark > MaxMark)
            throw new ArgumentOutOfRangeException(nameof(mark), $"Mark must be in range [{MinMark}...{MaxMark}].");
    }
}

public class Parent
{
    public void OnMarkChange(int mark)
    {
        Console.WriteLine($"Parent: my child got mark {mark}.");
    }
}

public class Accountancy
{
    public const int ScholarshipMark = 10;

    public void PayingFellowship(int mark)
    {
        if (mark >= ScholarshipMark)
            Console.WriteLine($"Accountancy: mark {mark} - student gets a scholarship.");
        else
            Console.WriteLine($"Accountancy: mark {mark} - no scholarship.");
    }
}

static class Task3Events
{
    public static void Run()
    {
        Student student = new Student("Mykyta");
        Parent parent = new Parent();
        Accountancy accountancy = new Accountancy();

        student.MarkChange += parent.OnMarkChange;
        student.MarkChange += accountancy.PayingFellowship;

        int[] newMarks = { 11, 7, 12, 9 };

        foreach (int mark in newMarks)
        {
            Console.WriteLine($"\nAddMark({mark})");
            student.AddMark(mark);
        }

        // Invalid mark: the event is not raised
        try
        {
            Console.WriteLine("\nAddMark(15)");
            student.AddMark(15);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // After unsubscribing only the accountancy is notified
        student.MarkChange -= parent.OnMarkChange;

        Console.WriteLine("\nParent unsubscribed. AddMark(10)");
        student.AddMark(10);

        Console.WriteLine($"\n{student}");
    }
}
