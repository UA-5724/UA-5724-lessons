// Task 2: Shapes

abstract class Shape : IComparable<Shape>
{
    private string name;

    protected Shape(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get { return name; }
    }

    public abstract double Area();

    public abstract double Perimeter();

    // Shapes are compared by area
    public int CompareTo(Shape? other)
    {
        if (other is null)
            return 1;

        return Area().CompareTo(other.Area());
    }
}

class Circle : Shape
{
    private double radius;

    public Circle(string name, double radius) : base(name)
    {
        if (radius <= 0)
            throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be positive.");

        this.radius = radius;
    }

    public double Radius
    {
        get { return radius; }
    }

    public override double Area()
    {
        return Math.PI * radius * radius;
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * radius;
    }
}

class Square : Shape
{
    private double side;

    public Square(string name, double side) : base(name)
    {
        if (side <= 0)
            throw new ArgumentOutOfRangeException(nameof(side), "Side must be positive.");

        this.side = side;
    }

    public double Side
    {
        get { return side; }
    }

    public override double Area()
    {
        return side * side;
    }

    public override double Perimeter()
    {
        return 4 * side;
    }
}

static class Operator
{
    public static void GetInfo(List<Shape> shapes)
    {
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.Name}: Area = {shape.Area():F2}, Perimeter = {shape.Perimeter():F2}");
        }
    }

    public static void GetLargestPerimeter(List<Shape> shapes)
    {
        if (shapes.Count == 0)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        Shape largest = shapes[0];

        foreach (Shape shape in shapes)
        {
            if (shape.Perimeter() > largest.Perimeter())
                largest = shape;
        }

        Console.WriteLine($"Shape with the largest perimeter: {largest.Name}");
    }

    public static void Sort(List<Shape> shapes)
    {
        // List.Sort() uses IComparable<Shape>, i.e. compares by area
        shapes.Sort();

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.Name);
        }
    }
}
