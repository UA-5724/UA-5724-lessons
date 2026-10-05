using Task1;

List<Shape> shapes = new List<Shape>
{
    new Circle("Circle A", 2),
    new Circle("Circle B", 4),
    new Circle("Circle C", 1),
    new Square("Square A", 3),
    new Square("Square B", 5),
    new Square("Square C", 1)
};

// 1. Shapes with area in range [10, 100]
var areaShapes = shapes
    .Where(shape => shape.GetArea() >= 10 && shape.GetArea() <= 100)
    .ToList();

File.WriteAllLines(
    "area_shapes.txt",
    areaShapes.Select(shape => shape.ToString())
);

// 2. Shapes whose name contains 'a'
var nameShapes = shapes
    .Where(shape => shape.Name.Contains('a', StringComparison.OrdinalIgnoreCase))
    .ToList();

File.WriteAllLines(
    "name_shapes.txt",
    nameShapes.Select(shape => shape.ToString())
);

// 3. Remove shapes with perimeter < 5
shapes.RemoveAll(shape => shape.GetPerimeter() < 5);

// 4. Output resulting list
Console.WriteLine("Resulting list:");

foreach (var shape in shapes)
{
    Console.WriteLine(shape);
}
