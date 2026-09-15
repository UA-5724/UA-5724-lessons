using NUnit.Framework;

namespace TestProject1.Tests;

public class PointTests
{
    [Test]
    public void ToString_ReturnsPointInCorrectFormat()
    {
        // Arrange
        Point point = new Point(3, 4);

        // Act
        string result = point.ToString();

        // Assert
        Assert.That(result, Is.EqualTo("(3,4)"));
    }

    [Test]
    public void DistanceTo_ReturnsCorrectDistance()
    {
        // Arrange
        Point p1 = new Point(0, 0);
        Point p2 = new Point(3, 4);

        // Act
        double result = p1.DistanceTo(p2);

        // Assert
        Assert.That(result, Is.EqualTo(5).Within(0.00001));
    }

    [Test]
    public void DistanceTo_SamePoint_ReturnsZero()
    {
        // Arrange
        Point p1 = new Point(2, 3);
        Point p2 = new Point(2, 3);

        // Act
        double result = p1.DistanceTo(p2);

        // Assert
        Assert.That(result, Is.EqualTo(0).Within(0.00001));
    }

    [Test]
    public void DistanceTo_NegativeCoordinates_ReturnsCorrectDistance()
    {
        // Arrange
        Point p1 = new Point(-1, -1);
        Point p2 = new Point(2, 3);

        // Act
        double result = p1.DistanceTo(p2);

        // Assert
        Assert.That(result, Is.EqualTo(5).Within(0.00001));
    }
}