using NUnit.Framework;

namespace TestProject1.Tests;

public class TriangleTests
{
    [Test]
    public void Distance_ReturnsCorrectDistance()
    {
        // Arrange
        Point p1 = new Point(0, 0);
        Point p2 = new Point(3, 4);

        Triangle triangle = new Triangle(
            new Point(0, 0),
            new Point(3, 0),
            new Point(0, 4));

        // Act
        double result = triangle.Distance(p1, p2);

        // Assert
        Assert.That(result, Is.EqualTo(5).Within(0.00001));
    }

    [Test]
    public void Perimeter_ReturnsCorrectValue()
    {
        // Arrange
        Triangle triangle = new Triangle(
            new Point(0, 0),
            new Point(3, 0),
            new Point(0, 4));

        // Act
        double result = triangle.Perimeter();

        // Assert
        Assert.That(result, Is.EqualTo(12).Within(0.00001));
    }

    [Test]
    public void Area_ReturnsCorrectValue()
    {
        // Arrange
        Triangle triangle = new Triangle(
            new Point(0, 0),
            new Point(3, 0),
            new Point(0, 4));

        // Act
        double result = triangle.Area();

        // Assert
        Assert.That(result, Is.EqualTo(6).Within(0.00001));
    }

    [Test]
    public void Constructor_CollinearPoints_ThrowsArgumentException()
    {
        // Arrange
        Point p1 = new Point(0, 0);
        Point p2 = new Point(1, 1);
        Point p3 = new Point(2, 2);

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new Triangle(p1, p2, p3));
    }
}