using System;
using Program_9._1;
using Xunit;

namespace ProgramTest_9._1
{
    public class TriangleTests
    {
        [Fact]
        public void Distance_ShouldReturnCorrectDistance()
        {
            Triangle triangle = new Triangle(
                new Point(0, 0),
                new Point(3, 0),
                new Point(0, 4)
            );

            double result = triangle.Distance(
                new Point(0, 0),
                new Point(3, 4)
            );

            Assert.Equal(5, result);
        }

        [Fact]
        public void Perimeter_ShouldReturnCorrectValue()
        {
            Triangle triangle = new Triangle(
                new Point(0, 0),
                new Point(3, 0),
                new Point(0, 4)
            );

            double result = triangle.Perimeter();

            Assert.Equal(12, result);
        }

        [Fact]
        public void Area_ShouldReturnCorrectValue()
        {
            Triangle triangle = new Triangle(
                new Point(0, 0),
                new Point(3, 0),
                new Point(0, 4)
            );

            double result = triangle.Area();

            Assert.Equal(6, result);
        }

        [Fact]
        public void Constructor_ShouldThrowExceptionForCollinearPoints()
        {
            Assert.Throws<ArgumentException>(() =>
                new Triangle(
                    new Point(0, 0),
                    new Point(1, 1),
                    new Point(2, 2)
                )
            );
        }
    }
}
