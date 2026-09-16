using System;
using System.Collections.Generic;

// Defines the signature of methods that can handle mark changes
public delegate void MyDel(int m);

class Student
{
    private string name;
    private List<int> marks;

    // Event that is triggered when a new mark is added
    public event MyDel? MarkChange;

    // Initialize student name and empty marks list
    public Student(string name)
    {
        this.name = name;
        marks = new List<int>();
    }

    // Add a new mark and notify all event subscribers
    public void AddMark(int mark)
    {
        marks.Add(mark);

        // Trigger the event and pass the new mark to subscribers
        MarkChange?.Invoke(mark);
    }
}

class Parent
{
    // Handle the event and display the new mark
    public void OnMarkChange(int mark)
    {
        Console.WriteLine(
            $"Parent received new mark: {mark}");
    }
}

class Accountancy
{
    // Check whether the student gets a scholarship
    public void PayingFellowship(int mark)
    {
        if (mark >= 10)
        {
            Console.WriteLine(
                "Student gets a scholarship.");
        }
        else
        {
            Console.WriteLine(
                "Student does not get a scholarship.");
        }
    }
}

class Program
{
    static void Main()
    {
        // Create objects
        Student student = new Student("Anna");
        Parent parent = new Parent();
        Accountancy accountancy = new Accountancy();

        // Subscribe Parent to the MarkChange event
        student.MarkChange += parent.OnMarkChange;

        // Subscribe Accountancy to the MarkChange event
        student.MarkChange += accountancy.PayingFellowship;

        // Add marks and trigger the event
        student.AddMark(12);

        Console.WriteLine();

        student.AddMark(8);

        Console.WriteLine();

        student.AddMark(10);
    }
}
