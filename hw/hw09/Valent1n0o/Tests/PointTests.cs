using NUnit.Framework;

using hw09;

namespace hw09.Tests
{
    public class PointTests
    {
        [Test]
        public void ToString_ReturnsCorrectCoordinates()
        {
            Point point = new Point(3, 4);

            string result = point.ToString();

            Assert.That(result, Is.EqualTo("(3,4)"));
        }

        [Test]
        public void DistanceTo_ReturnsCorrectDistance()
        {
            Point point1 = new Point(0, 0);
            Point point2 = new Point(3, 4);

            double result = point1.DistanceTo(point2);

            Assert.That(result, Is.EqualTo(5).Within(0.001));
        }
    }
}