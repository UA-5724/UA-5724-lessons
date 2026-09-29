// Task 1: Working with Shapes, LINQ & File Operations

static class Task1ShapesLinq
{
    public static void Run(string outputDir)
    {
        List<Shape> shapes = new List<Shape>
        {
            new Circle("Sun", 2),
            new Circle("Coin", 0.5),
            new Circle("Plate", 5),
            new Square("Tile", 1),
            new Square("Window", 3),
            new Square("Table", 8)
        };

        Console.WriteLine("All shapes:");
        Print(shapes);

        // 1. Shapes with area in range [10, 100]
        var areaInRange = shapes
            .Where(s => s.Area() >= 10 && s.Area() <= 100)
            .ToList();

        string areaFile = Path.Combine(outputDir, "shapes_area_10_100.txt");
        File.WriteAllLines(areaFile, areaInRange.Select(s => s.ToString()));
        Console.WriteLine($"\n{areaInRange.Count} shapes with area in [10, 100] saved to {areaFile}");

        // 2. Shapes whose name contains letter 'a' (upper or lower case)
        var withLetterA = shapes
            .Where(s => s.Name.Contains('a', StringComparison.OrdinalIgnoreCase))
            .ToList();

        string letterFile = Path.Combine(outputDir, "shapes_with_a.txt");
        File.WriteAllLines(letterFile, withLetterA.Select(s => s.ToString()));
        Console.WriteLine($"{withLetterA.Count} shapes with letter 'a' in name saved to {letterFile}");

        // 3. Remove shapes with perimeter < 5
        int removed = shapes.RemoveAll(s => s.Perimeter() < 5);

        Console.WriteLine($"\nRemoved {removed} shapes with perimeter < 5. Remaining shapes:");
        Print(shapes);
    }

    private static void Print(IEnumerable<Shape> shapes)
    {
        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape);
        }
    }
}
