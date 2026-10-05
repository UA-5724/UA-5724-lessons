using System;
using System.Collections.Generic;

public delegate void MyDel(int m);

public class Student
{
    public string Name { get; set; }

    public List<int> Marks { get; set; }

    public event MyDel? MarkChange;

    public Student(string name)
    {
        Name = name;
        Marks = new List<int>();
    }

    public void AddMark(int mark)
    {
        Marks.Add(mark);

        Console.WriteLine(
            $"{Name} received a new mark: {mark}"
        );

        MarkChange?.Invoke(mark);
    }
}

public class Parent
{
    public void OnMarkChange(int mark)
    {
        Console.WriteLine(
            $"Parent: Student received mark {mark}."
        );
    }
}

public class Accountancy
{
    public void PayingFellowship(int mark)
    {
        if (mark >= 90)
        {
            Console.WriteLine(
                $"Accountancy: Mark {mark} -> Scholarship awarded."
            );
        }
        else
        {
            Console.WriteLine(
                $"Accountancy: Mark {mark} -> No scholarship."
            );
        }
    }
}

class Program
{
    static void Main()
    {
        Student student = new Student("John");
        Parent parent = new Parent();
        Accountancy accountancy = new Accountancy();

        // Subscribe to the event
        student.MarkChange += parent.OnMarkChange;
        student.MarkChange += accountancy.PayingFellowship;

        // Add marks
        student.AddMark(75);
        Console.WriteLine();

        student.AddMark(95);
        Console.WriteLine();

        student.AddMark(88);
        Console.WriteLine();

        student.AddMark(100);
    }
}
