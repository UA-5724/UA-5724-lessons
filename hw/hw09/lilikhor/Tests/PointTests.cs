using System;
using Program_9._1;
using Xunit;

namespace ProgramTest_9._1
{
    public class PointTests
    {
        [Fact]
        public void ToString_ShouldReturnCoordinatesInCorrectFormat()
        {
            Point point = new Point(3, 5);

            string result = point.ToString();

            Assert.Equal("(3,5)", result);
        }

        [Fact]
        public void DistanceTo_ShouldReturnCorrectDistance()
        {
            Point point1 = new Point(0, 0);
            Point point2 = new Point(3, 4);

            double result = point1.DistanceTo(point2);

            Assert.Equal(5, result);
        }

        [Fact]
        public void DistanceTo_SamePoint_ShouldReturnZero()
        {
            Point point1 = new Point(5, 5);
            Point point2 = new Point(5, 5);

            double result = point1.DistanceTo(point2);

            Assert.Equal(0, result);
        }

        [Fact]
        public void DistanceTo_NegativeCoordinates_ShouldReturnCorrectDistance()
        {
            Point point1 = new Point(-3, -4);
            Point point2 = new Point(0, 0);

            double result = point1.DistanceTo(point2);

            Assert.Equal(5, result);
        }
    }
}
