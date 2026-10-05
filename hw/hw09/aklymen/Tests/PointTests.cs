using NUnit.Framework;

namespace hw09.Tests
{
    [TestFixture]
    public class PointTests
    {
        // Test ToString
        [Test]
        public void ToString_ShouldReturnCorrectFormat()
        {
            Point point = new Point(2, 3);

            Assert.That(point.ToString(), Is.EqualTo("(2,3)"));
        }


        // Test DistanceTo
        [Test]
        public void DistanceTo_ShouldReturnCorrectDistance()
        {
            Point point1 = new Point(0, 0);
            Point point2 = new Point(3, 4);

            double result = point1.DistanceTo(point2);

            Assert.That(result, Is.EqualTo(5));
        }


        // Test same point
        [Test]
        public void DistanceTo_SamePoint_ShouldReturnZero()
        {
            Point point1 = new Point(2, 3);
            Point point2 = new Point(2, 3);

            double result = point1.DistanceTo(point2);

            Assert.That(result, Is.EqualTo(0));
        }


        // Test negative coordinates
        [Test]
        public void DistanceTo_NegativeCoordinates_ShouldReturnCorrectDistance()
        {
            Point point1 = new Point(-2, -3);
            Point point2 = new Point(1, 1);

            double result = point1.DistanceTo(point2);

            Assert.That(result, Is.EqualTo(5));
        }
    }
}