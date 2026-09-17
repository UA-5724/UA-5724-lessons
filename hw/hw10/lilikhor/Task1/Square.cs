namespace Task1;

public class Square : Shape
{
    public double Side { get; set; }

    public Square(string name, double side)
        : base(name)
    {
        Side = side;
    }

    public override double GetArea()
    {
        return Side * Side;
    }

    public override double GetPerimeter()
    {
        return 4 * Side;
    }
}
