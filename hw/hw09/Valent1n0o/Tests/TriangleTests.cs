using NUnit.Framework;

using hw09;

namespace hw09.Tests
{
    public class TriangleTests
    {
        [Test]
        public void Perimeter_ReturnsCorrectValue()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(3, 0);
            Point p3 = new Point(0, 4);

            Triangle triangle = new Triangle(p1, p2, p3);

            double result = triangle.Perimeter();

            Assert.That(result, Is.EqualTo(12).Within(0.001));
        }

        [Test]
        public void Area_ReturnsCorrectValue()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(3, 0);
            Point p3 = new Point(0, 4);

            Triangle triangle = new Triangle(p1, p2, p3);

            double result = triangle.Area();

            Assert.That(result, Is.EqualTo(6).Within(0.001));
        }

        [Test]
        public void Distance_ReturnsCorrectValue()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(3, 4);

            Triangle triangle = new Triangle();

            double result = triangle.Distance(p1, p2);

            Assert.That(result, Is.EqualTo(5).Within(0.001));
        }
    }
}