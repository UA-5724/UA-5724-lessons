namespace Hw09.Tests;

public class PointTests
{
    private const int Precision = 9;

    [Fact]
    public void ToString_ReturnsCoordinatesInBrackets()
    {
        Point point = new Point(3, 4);

        Assert.Equal("(3,4)", point.ToString());
    }

    [Fact]
    public void ToString_FractionalAndNegative_UsesDotSeparator()
    {
        Point point = new Point(-1.5, 2.25);

        Assert.Equal("(-1.5,2.25)", point.ToString());
    }

    [Fact]
    public void DistanceTo_ReturnsEuclideanDistance()
    {
        Point a = new Point(0, 0);
        Point b = new Point(3, 4);

        Assert.Equal(5, a.DistanceTo(b), Precision);
    }

    [Fact]
    public void DistanceTo_IsSymmetric()
    {
        Point a = new Point(1, 2);
        Point b = new Point(-4, 7);

        Assert.Equal(a.DistanceTo(b), b.DistanceTo(a), Precision);
    }

    [Fact]
    public void DistanceTo_SamePoint_ReturnsZero()
    {
        Point point = new Point(2.5, -7);

        Assert.Equal(0, point.DistanceTo(point), Precision);
    }

    [Fact]
    public void DistanceTo_NegativeCoordinates()
    {
        Point a = new Point(-1, -1);
        Point b = new Point(-4, -5);

        Assert.Equal(5, a.DistanceTo(b), Precision);
    }

    [Fact]
    public void Equals_SameCoordinates_ReturnsTrue()
    {
        Point a = new Point(1, 2);
        Point b = new Point(1, 2);

        Assert.True(a == b);
        Assert.True(a.Equals(b));
        Assert.Equal(a.GetHashCode(), b.GetHashCode());
    }

    [Fact]
    public void Equals_DifferentCoordinates_ReturnsFalse()
    {
        Point a = new Point(1, 2);
        Point b = new Point(2, 1);

        Assert.True(a != b);
        Assert.False(a.Equals(b));
    }
}
