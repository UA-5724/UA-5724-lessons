using System.Globalization;

namespace Hw09;

// Value object: immutable, compared by value, not by reference
public readonly struct Point : IEquatable<Point>
{
    private readonly double x;
    private readonly double y;

    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public double X => x;

    public double Y => y;

    public static Point Origin => new Point(0, 0);

    public double DistanceTo(Point other)
    {
        double dx = x - other.x;
        double dy = y - other.y;

        return Math.Sqrt(dx * dx + dy * dy);
    }

    // Invariant culture keeps "." as decimal separator on any system locale
    public override string ToString()
    {
        return string.Format(CultureInfo.InvariantCulture, "({0},{1})", x, y);
    }

    public bool Equals(Point other)
    {
        return x.Equals(other.x) && y.Equals(other.y);
    }

    public override bool Equals(object? obj)
    {
        return obj is Point other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y);
    }

    public static bool operator ==(Point a, Point b) => a.Equals(b);

    public static bool operator !=(Point a, Point b) => !a.Equals(b);
}
