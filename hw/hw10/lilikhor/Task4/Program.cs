using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Student
{
    public string Name { get; set; } = "";
    public List<int> Marks { get; set; } = new List<int>();
}

class Program
{
    static void Main()
    {
        Student student = new Student
        {
            Name = "John",
            Marks = new List<int> { 85, 92, 78, 100 }
        };

        // Serialization
        string json = JsonSerializer.Serialize(
            student,
            new JsonSerializerOptions
            {
                WriteIndented = true
            }
        );

        File.WriteAllText("student.json", json);

        Console.WriteLine("Student serialized:");
        Console.WriteLine(json);

        // Deserialization
        string jsonFromFile = File.ReadAllText("student.json");

        Student? restoredStudent =
            JsonSerializer.Deserialize<Student>(jsonFromFile);

        Console.WriteLine();
        Console.WriteLine("Deserialized student:");

        if (restoredStudent != null)
        {
            Console.WriteLine($"Name: {restoredStudent.Name}");

            Console.WriteLine(
                $"Marks: {string.Join(", ", restoredStudent.Marks)}"
            );
        }
    }
}
