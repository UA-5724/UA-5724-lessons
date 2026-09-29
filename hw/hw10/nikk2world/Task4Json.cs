using System.Text.Json;

// Task 4: JSON Serialization of the Student class from Task 3.
// Only public properties (Name, Marks) are written; the event is not serialized.

static class Task4Json
{
    private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    public static void Run(string outputDir)
    {
        Student student = new Student("Mykyta");
        student.AddMark(11);
        student.AddMark(8);
        student.AddMark(12);

        string jsonFile = Path.Combine(outputDir, "student.json");

        try
        {
            // Serialize object -> JSON file
            string json = JsonSerializer.Serialize(student, Options);
            File.WriteAllText(jsonFile, json);

            Console.WriteLine($"Serialized to {jsonFile}:");
            Console.WriteLine(json);

            // Deserialize JSON file -> object
            string jsonFromFile = File.ReadAllText(jsonFile);
            Student? restored = JsonSerializer.Deserialize<Student>(jsonFromFile, Options);

            Console.WriteLine("\nDeserialized from file:");
            Console.WriteLine(restored?.ToString() ?? "null");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON error: {ex.Message}");
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
    }
}
