namespace Hw09.Tests;

public class TriangleTests
{
    private const int Precision = 9;

    // Right triangle with legs 3 and 4 and hypotenuse 5
    private static Triangle CreateRightTriangle()
    {
        return new Triangle(new Point(0, 0), new Point(3, 0), new Point(0, 4));
    }

    [Fact]
    public void Distance_ReturnsDistanceBetweenPoints()
    {
        Assert.Equal(5, Triangle.Distance(new Point(0, 0), new Point(3, 4)), Precision);
    }

    [Fact]
    public void Distance_SamePoint_ReturnsZero()
    {
        Point point = new Point(-2, 3);

        Assert.Equal(0, Triangle.Distance(point, point), Precision);
    }

    [Fact]
    public void Perimeter_RightTriangle_ReturnsSumOfSides()
    {
        Assert.Equal(12, CreateRightTriangle().Perimeter(), Precision);
    }

    [Fact]
    public void Area_RightTriangle_ReturnsHalfOfLegsProduct()
    {
        Assert.Equal(6, CreateRightTriangle().Area(), Precision);
    }

    [Fact]
    public void Area_TriangleWithNegativeCoordinates()
    {
        Triangle triangle = new Triangle(new Point(-1, -1), new Point(-5, -1), new Point(-1, -4));

        Assert.Equal(6, triangle.Area(), Precision);
        Assert.Equal(12, triangle.Perimeter(), Precision);
    }

    [Fact]
    public void DefaultConstructor_CreatesValidTriangle()
    {
        Triangle triangle = new Triangle();

        Assert.Equal(0.5, triangle.Area(), Precision);
        Assert.Equal(2 + Math.Sqrt(2), triangle.Perimeter(), Precision);
    }

    [Fact]
    public void Constructor_CollinearPoints_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            new Triangle(new Point(0, 0), new Point(1, 1), new Point(2, 2)));
    }

    [Fact]
    public void Constructor_SamePoints_ThrowsArgumentException()
    {
        Point point = new Point(1, 1);

        Assert.Throws<ArgumentException>(() => new Triangle(point, point, point));
    }

    [Fact]
    public void Vertices_ReturnPointsPassedToConstructor()
    {
        Triangle triangle = CreateRightTriangle();

        Assert.Equal(new Point(0, 0), triangle.Vertex1);
        Assert.Equal(new Point(3, 0), triangle.Vertex2);
        Assert.Equal(new Point(0, 4), triangle.Vertex3);
    }
}
