namespace Task1;

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(string name, double radius)
        : base(name)
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}
