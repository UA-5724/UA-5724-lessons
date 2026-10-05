// Shape, Circle, Square from homework 7

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

    public override string ToString()
    {
        return $"{GetType().Name} \"{name}\": Area = {Area():F2}, Perimeter = {Perimeter():F2}";
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
