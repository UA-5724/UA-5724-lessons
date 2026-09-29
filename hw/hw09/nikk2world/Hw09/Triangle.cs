namespace Hw09;

// Composition: the triangle owns its vertices.
// Point is a struct, so the triangle stores its own copies:
// nobody outside can change the vertices of an existing triangle.
public class Triangle
{
    private const double Epsilon = 1e-9;

    private readonly Point vertex1;
    private readonly Point vertex2;
    private readonly Point vertex3;

    // Default triangle: right triangle with legs of length 1
    public Triangle() : this(new Point(0, 0), new Point(1, 0), new Point(0, 1))
    {
    }

    public Triangle(Point vertex1, Point vertex2, Point vertex3)
    {
        if (AreCollinear(vertex1, vertex2, vertex3))
            throw new ArgumentException("Points are collinear, a triangle cannot be built.");

        this.vertex1 = vertex1;
        this.vertex2 = vertex2;
        this.vertex3 = vertex3;
    }

    public Point Vertex1 => vertex1;

    public Point Vertex2 => vertex2;

    public Point Vertex3 => vertex3;

    public static double Distance(Point a, Point b)
    {
        return a.DistanceTo(b);
    }

    public static bool AreCollinear(Point a, Point b, Point c)
    {
        // Cross product equals twice the area of the triangle.
        // Zero area means all three points lie on one line.
        double cross = (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);

        return Math.Abs(cross) < Epsilon;
    }

    public double Perimeter()
    {
        return Distance(vertex1, vertex2) + Distance(vertex2, vertex3) + Distance(vertex3, vertex1);
    }

    // Heron's formula
    public double Area()
    {
        double a = Distance(vertex1, vertex2);
        double b = Distance(vertex2, vertex3);
        double c = Distance(vertex3, vertex1);
        double p = (a + b + c) / 2;

        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    // Distance from (0,0) to the nearest vertex
    public double MinDistanceToOrigin()
    {
        return Math.Min(
            vertex1.DistanceTo(Point.Origin),
            Math.Min(vertex2.DistanceTo(Point.Origin), vertex3.DistanceTo(Point.Origin)));
    }

    public override string ToString()
    {
        return $"Triangle {vertex1} {vertex2} {vertex3}";
    }

    public void Print()
    {
        Console.WriteLine($"{this}: Perimeter = {Perimeter():F2}, Area = {Area():F2}");
    }
}
