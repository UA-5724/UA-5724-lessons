namespace Hw09.Tests;

public class ShapeGroupTests
{
    private static Triangle CreateTriangleAt(double x, double y)
    {
        return new Triangle(new Point(x, y), new Point(x + 1, y), new Point(x, y + 1));
    }

    [Fact]
    public void AddTriangle_IncreasesCount()
    {
        ShapeGroup group = new ShapeGroup();
        Triangle triangle = CreateTriangleAt(1, 1);

        group.AddTriangle(triangle);

        Assert.Equal(1, group.Count);
        Assert.Contains(triangle, group.GetAll());
    }

    [Fact]
    public void AddTriangle_Null_ThrowsArgumentNullException()
    {
        ShapeGroup group = new ShapeGroup();

        Assert.Throws<ArgumentNullException>(() => group.AddTriangle(null!));
    }

    [Fact]
    public void RemoveTriangle_ExistingTriangle_RemovesItAndReturnsTrue()
    {
        ShapeGroup group = new ShapeGroup();
        Triangle triangle = CreateTriangleAt(1, 1);
        group.AddTriangle(triangle);

        bool removed = group.RemoveTriangle(triangle);

        Assert.True(removed);
        Assert.Empty(group.GetAll());
    }

    [Fact]
    public void RemoveTriangle_MissingTriangle_ReturnsFalse()
    {
        ShapeGroup group = new ShapeGroup();
        group.AddTriangle(CreateTriangleAt(1, 1));

        bool removed = group.RemoveTriangle(CreateTriangleAt(5, 5));

        Assert.False(removed);
        Assert.Equal(1, group.Count);
    }

    [Fact]
    public void RemoveTriangle_TriangleStillExistsAfterRemoval()
    {
        ShapeGroup group = new ShapeGroup();
        Triangle triangle = CreateTriangleAt(1, 1);
        group.AddTriangle(triangle);

        group.RemoveTriangle(triangle);

        // Aggregation: the triangle lives on without the group
        Assert.Equal(0.5, triangle.Area(), 9);
    }

    [Fact]
    public void GetAll_ReturnsTrianglesInAddOrder()
    {
        ShapeGroup group = new ShapeGroup();
        Triangle first = CreateTriangleAt(1, 1);
        Triangle second = CreateTriangleAt(2, 2);

        group.AddTriangle(first);
        group.AddTriangle(second);

        Assert.Equal(new[] { first, second }, group.GetAll());
    }

    [Fact]
    public void FindTriangleClosestToOrigin_ReturnsTriangleWithNearestVertex()
    {
        ShapeGroup group = new ShapeGroup();
        Triangle far = CreateTriangleAt(10, 10);
        Triangle closest = CreateTriangleAt(-1, 0.5);
        Triangle middle = CreateTriangleAt(3, -3);

        group.AddTriangle(far);
        group.AddTriangle(closest);
        group.AddTriangle(middle);

        Assert.Same(closest, group.FindTriangleClosestToOrigin());
    }

    [Fact]
    public void FindTriangleClosestToOrigin_UsesAnyVertexNotOnlyFirst()
    {
        ShapeGroup group = new ShapeGroup();
        Triangle a = new Triangle(new Point(5, 5), new Point(6, 5), new Point(5, 6));
        // First vertex is far, but the third one is almost at the origin
        Triangle b = new Triangle(new Point(20, 20), new Point(21, 0), new Point(0.1, 0.1));

        group.AddTriangle(a);
        group.AddTriangle(b);

        Assert.Same(b, group.FindTriangleClosestToOrigin());
    }

    [Fact]
    public void EmptyGroup_GetAllIsEmpty_AndClosestIsNull()
    {
        ShapeGroup group = new ShapeGroup();

        Assert.Empty(group.GetAll());
        Assert.Equal(0, group.Count);
        Assert.Null(group.FindTriangleClosestToOrigin());
    }
}
