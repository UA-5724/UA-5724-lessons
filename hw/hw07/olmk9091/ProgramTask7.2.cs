using System;
using System.Collections.Generic;
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

static class Operator 
{
    // Display information about all shapes
    public static void GetInfo(List<Shape> shapes) 
    { 
        Console.WriteLine("Information about shapes:"); 
        foreach (Shape shape in shapes) 
        { 
            Console.WriteLine($"Name: {shape.Name}"); 
            Console.WriteLine($"Area: {shape.Area():F2}");
            Console.WriteLine($"Perimeter: {shape.Perimeter():F2}"); 
            Console.WriteLine(); 
        } 
    }
    // Find the shape with the largest perimeter
    public static void GetLargestPerimeter(List<Shape> shapes) 
    { 
        if (shapes.Count == 0) 
        { 
            Console.WriteLine("The list is empty."); 
            return; 
        } 
        Shape largestShape = shapes[0]; 
        foreach (Shape shape in shapes) 
        { 
            if (shape.Perimeter() > largestShape.Perimeter()) 
            { 
                largestShape = shape; 
            } 
        } 
        Console.WriteLine($"Shape with the largest perimeter: {largestShape.Name}"); 
    }
    // Sort shapes by area
    public static void Sort(List<Shape> shapes) 
    { 
        shapes.Sort(); 
        Console.WriteLine("\nShapes sorted by area:"); 
        foreach (Shape shape in shapes) 
        { 
            Console.WriteLine($"{shape.Name}: {shape.Area():F2}"); 
        } 
    } 
}

class Program 
{ 
    static void Main() 
    {
        // Create a collection of shapes
        List<Shape> shapes = new List<Shape> 
        { 
            new Circle("Circle1", 3), 
            new Square("Square1", 4), 
            new Circle("Circle2", 5), 
            new Square("Square2", 2) 
        };
        // Display information about all shapes
        Operator.GetInfo(shapes);
        // Find and display the shape with the largest perimeter
        Operator.GetLargestPerimeter(shapes);
        // Sort shapes by area
        Operator.Sort(shapes); 
    } 
}
