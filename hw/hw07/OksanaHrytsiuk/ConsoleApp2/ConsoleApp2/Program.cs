using System;
using System.Collections.Generic;

abstract class Shape : IComparable<Shape>
{
    public string Name { get; set; }

    public Shape(string name)
    {
        Name = name;
    }

    public abstract double Area();

    public abstract double Perimeter();

    public int CompareTo(Shape other)
    {
        return Area().CompareTo(other.Area());
    }
}

class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(string name, double radius)
        : base(name)
    {
        Radius = radius;
    }

    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

class Square : Shape
{
    public double Side { get; set; }

    public Square(string name, double side)
        : base(name)
    {
        Side = side;
    }

    public override double Area()
    {
        return Side * Side;
    }

    public override double Perimeter()
    {
        return 4 * Side;
    }
}

class Operator
{
    public static void GetInfo(List<Shape> shapes)
    {
        Console.WriteLine("=== Shapes ===");

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Name: {shape.Name}");
            Console.WriteLine($"Area: {shape.Area():F2}");
            Console.WriteLine($"Perimeter: {shape.Perimeter():F2}");
            Console.WriteLine();
        }
    }

    public static void GetLargestPerimeter(List<Shape> shapes)
    {
        Shape largest = shapes[0];

        foreach (Shape shape in shapes)
        {
            if (shape.Perimeter() > largest.Perimeter())
            {
                largest = shape;
            }
        }

        Console.WriteLine("Shape with the largest perimeter:");
        Console.WriteLine($"{largest.Name} ({largest.Perimeter():F2})");
        Console.WriteLine();
    }

    public static void Sort(List<Shape> shapes)
    {
        shapes.Sort();

        Console.WriteLine("=== Sorted by Area ===");

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.Name} - Area: {shape.Area():F2}");
        }
    }
}

class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>()
        {
            new Circle("Circle1", 3),
            new Square("Square1", 4),
            new Circle("Circle2", 5),
            new Square("Square2", 2)
        };

        Operator.GetInfo(shapes);

        Operator.GetLargestPerimeter(shapes);

        Operator.Sort(shapes);
    }
}