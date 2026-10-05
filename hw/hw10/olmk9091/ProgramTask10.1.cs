using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
// Abstract base class for all shapes
// Contains common properties and methods
abstract class Shape : IComparable<Shape>
{
    private string name = string.Empty;
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }
    public Shape(string name)
    {
        Name = name;
    }
    public abstract double Area();
    public abstract double Perimeter();
    // Compare shapes by area for sorting
    public int CompareTo(Shape? other)
    {
        if (other == null)
        {
            return 1;
        }
        // Area() is used in CompareTo(), so shapes are sorted by area
        return Area().CompareTo(other.Area());
    }
}

// Represents a circle
class Circle : Shape
{
    private double radius;
    public double Radius
    {
        get
        {
            return radius;
        }
        set
        {
            if (value > 0)
            {
                radius = value;
            }
            else
            {
                throw new ArgumentException("Radius must be greater than zero.");
            }
        }
    }
    // base(name) calls the constructor of the parent class Shape
    public Circle(string name, double radius)
        : base(name)
    {
        Radius = radius;
    }
    // Calculate the area of the circle
    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }
    // Calculate the perimeter of the circle
    public override double Perimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

// Represents a square
class Square : Shape
{
    private double side;
    public double Side
    {
        get
        {
            return side;
        }
        set
        {
            if (value > 0)
            {
                side = value;
            }
            else
            {
                throw new ArgumentException("Side must be greater than zero.");
            }
        }
    }
    // base(name) calls the constructor of the parent class Shape
    public Square(string name, double side)
        : base(name)
    {
        Side = side;
    }
    // Calculate the area of the square
    public override double Area()
    {
        return Side * Side;
    }
    // Calculate the perimeter of the square
    public override double Perimeter()
    {
        return 4 * Side;
    }
}
class Program
{
    static void Main()
    {
        // Create a collection of six different shapes
        List<Shape> shapes = new List<Shape>
        {
            new Circle("Circle1", 3),
            new Square("Square1", 4),
            new Circle("LargeCircle", 5),
            new Square("SmallSquare", 2),
            new Circle("Circle3", 1),
            new Square("LargeSquare", 8)
        };

        // Find shapes with area in range [10, 100]
        List<Shape> shapesByArea = shapes
            .Where(shape => shape.Area() >= 10 &&
                            shape.Area() <= 100)
            .ToList();

        // Write selected shapes into a file
        File.WriteAllLines(
            "ShapesByArea.txt",
            shapesByArea.Select(
                shape => $"{shape.Name}, " +
                         $"Area: {shape.Area():F2}, " +
                         $"Perimeter: {shape.Perimeter():F2}"));

        // Find shapes whose names contain the letter 'a'
        List<Shape> shapesWithA = shapes
            .Where(shape => shape.Name.Contains(
                "a",
                StringComparison.OrdinalIgnoreCase))
            .ToList();

        // Write selected shapes into a file
        File.WriteAllLines(
            "ShapesWithA.txt",
            shapesWithA.Select(
                shape => $"{shape.Name}, " +
                         $"Area: {shape.Area():F2}, " +
                         $"Perimeter: {shape.Perimeter():F2}"));

        // Remove shapes with perimeter less than 5
        shapes.RemoveAll(
            shape => shape.Perimeter() < 5);

        Console.WriteLine("Shapes after removing:");

        // Display the resulting collection
        foreach (Shape shape in shapes)
        {
            Console.WriteLine(
                $"{shape.Name}, " +
                $"Area: {shape.Area():F2}, " +
                $"Perimeter: {shape.Perimeter():F2}");
        }
    }
}