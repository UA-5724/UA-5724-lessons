using NUnit.Framework;

namespace hw09.Tests
{
    [TestFixture]
    public class TriangleTests
    {
        // Test Distance
        [Test]
        public void Distance_ShouldReturnCorrectDistance()
        {
            Triangle triangle = new Triangle(
                new Point(0, 0),
                new Point(3, 0),
                new Point(0, 4));

            double result = triangle.Distance(
                new Point(0, 0),
                new Point(3, 4));

            Assert.That(result, Is.EqualTo(5));
        }


        // Test Perimeter
        [Test]
        public void Perimeter_ShouldReturnCorrectValue()
        {
            Triangle triangle = new Triangle(
                new Point(0, 0),
                new Point(3, 0),
                new Point(0, 4));

            double result = triangle.Perimeter();

            Assert.That(result, Is.EqualTo(12));
        }


        // Test Area
        [Test]
        public void Area_ShouldReturnCorrectValue()
        {
            Triangle triangle = new Triangle(
                new Point(0, 0),
                new Point(3, 0),
                new Point(0, 4));

            double result = triangle.Area();

            Assert.That(result, Is.EqualTo(6));
        }


        // Test invalid triangle
        [Test]
        public void Constructor_CollinearPoints_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Triangle(
                    new Point(0, 0),
                    new Point(1, 1),
                    new Point(2, 2));
            });
        }
    }
}