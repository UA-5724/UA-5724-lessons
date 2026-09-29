class Program
{
    const string DataDir = "Data";
    const string OutputDir = "Output";

    static void Main()
    {
        Directory.CreateDirectory(OutputDir);

        Console.WriteLine("===== Task 1. Shapes, LINQ & Files =====");
        Task1ShapesLinq.Run(OutputDir);

        Console.WriteLine("\n===== Task 2. Text Processing & LINQ =====");
        Task2TextLinq.Run(Path.Combine(DataDir, "input.txt"));

        Console.WriteLine("\n===== Task 3. Delegates & Events =====");
        Task3Events.Run();

        Console.WriteLine("\n===== Task 4. JSON Serialization =====");
        Task4Json.Run(OutputDir);
    }
}
