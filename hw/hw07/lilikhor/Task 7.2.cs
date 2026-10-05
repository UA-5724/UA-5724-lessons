using System;
using System.Collections.Generic;

abstract class Shape : IComparable<Shape>
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Shape(string name)
    {
        Name = name;
    }

    public abstract double Area();

    public abstract double Perimeter();

    // Sort shapes by area
    public int CompareTo(Shape other)
    {
        if (other == null)
            return 1;

        return Area().CompareTo(other.Area());
    }
}

class Circle : Shape
{
    private double radius;

    public double Radius
    {
        get { return radius; }
        set { radius = value; }
    }

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
    private double side;

    public double Side
    {
        get { return side; }
        set { side = value; }
    }

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
        Console.WriteLine("=== Shape Information ===");

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(
                $"Name: {shape.Name}, " +
                $"Area: {shape.Area():F2}, " +
                $"Perimeter: {shape.Perimeter():F2}");
        }
    }

    public static void GetLargestPerimeter(List<Shape> shapes)
    {
        if (shapes == null || shapes.Count == 0)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        Shape largest = shapes[0];

        foreach (Shape shape in shapes)
        {
            if (shape.Perimeter() > largest.Perimeter())
            {
                largest = shape;
            }
        }

        Console.WriteLine(
            $"\nShape with largest perimeter: {largest.Name}");
    }

    public static void Sort(List<Shape> shapes)
    {
        // Uses IComparable<Shape>
        shapes.Sort();

        Console.WriteLine("\n=== Shapes Sorted by Area ===");

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(
                $"{shape.Name} - Area: {shape.Area():F2}");
        }
    }
}

class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>
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