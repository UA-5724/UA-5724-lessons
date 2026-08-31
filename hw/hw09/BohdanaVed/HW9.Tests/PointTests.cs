using System;
using HW9;
using Xunit;

namespace HW9.Tests
{
    public class PointTests
    {
        [Fact]
        public void Constructor_StoresCoordinates()
        {
            Point point = new Point(2.5, -7.25);

            Assert.Equal(2.5, point.X, 10);
            Assert.Equal(-7.25, point.Y, 10);
        }

        [Fact]
        public void ToString_ReturnsCoordinatesInBrackets()
        {
            Point point = new Point(3, 4);

            Assert.Equal("(3,4)", point.ToString());
        }

        [Theory]
        [InlineData(0, 0, "(0,0)")]
        [InlineData(3, 4, "(3,4)")]
        [InlineData(-5, 8, "(-5,8)")]
        [InlineData(-1, -2, "(-1,-2)")]
        [InlineData(1.5, 2.25, "(1.5,2.25)")]
        public void ToString_ReturnsExpectedText(double x, double y, string expected)
        {
            Point point = new Point(x, y);

            Assert.Equal(expected, point.ToString());
        }

        [Fact]
        public void ToString_UsedInConcatenation_ReturnsExpectedText()
        {
            Point point = new Point(1, 2);
            string text = "Point: " + point;

            Assert.Equal("Point: (1,2)", text);
        }

        [Fact]
        public void DistanceTo_ThreeFourFive_ReturnsFive()
        {
            Point first = new Point(0, 0);
            Point second = new Point(3, 4);

            Assert.Equal(5.0, first.DistanceTo(second), 10);
        }

        [Theory]
        [InlineData(0, 0, 3, 4, 5)]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(2, 3, 2, 3, 0)]
        [InlineData(-1, -1, -1, -1, 0)]
        [InlineData(1, 1, 4, 5, 5)]
        [InlineData(-3, -4, 0, 0, 5)]
        [InlineData(-1, -2, 2, 2, 5)]
        [InlineData(-5, 0, 5, 0, 10)]
        [InlineData(0, -6, 0, 6, 12)]
        public void DistanceTo_ReturnsExpectedDistance(double x1, double y1, double x2, double y2, double expected)
        {
            Point first = new Point(x1, y1);
            Point second = new Point(x2, y2);

            Assert.Equal(expected, first.DistanceTo(second), 10);
        }

        [Fact]
        public void DistanceTo_SamePoint_ReturnsZero()
        {
            Point point = new Point(7.5, -3.5);

            Assert.Equal(0.0, point.DistanceTo(point), 10);
        }

        [Fact]
        public void DistanceTo_EqualCoordinates_ReturnsZero()
        {
            Point first = new Point(-2.25, 9.75);
            Point second = new Point(-2.25, 9.75);

            Assert.Equal(0.0, first.DistanceTo(second), 10);
        }

        [Fact]
        public void DistanceTo_NegativeCoordinates_ReturnsPositiveDistance()
        {
            Point first = new Point(-3, -4);
            Point second = new Point(-6, -8);

            Assert.Equal(5.0, first.DistanceTo(second), 10);
        }

        [Fact]
        public void DistanceTo_IsSymmetric()
        {
            Point first = new Point(-2, 5);
            Point second = new Point(4, -3);

            Assert.Equal(first.DistanceTo(second), second.DistanceTo(first), 10);
        }

        [Fact]
        public void DistanceTo_DiagonalOfUnitSquare_ReturnsSquareRootOfTwo()
        {
            Point first = new Point(0, 0);
            Point second = new Point(1, 1);

            Assert.Equal(Math.Sqrt(2), first.DistanceTo(second), 10);
        }

        [Fact]
        public void DistanceTo_Null_ThrowsArgumentNullException()
        {
            Point point = new Point(1, 1);

            Assert.Throws<ArgumentNullException>(() => point.DistanceTo(null));
        }

        [Fact]
        public void Equals_SameCoordinates_ReturnsTrue()
        {
            Point first = new Point(1.5, -2.5);
            Point second = new Point(1.5, -2.5);

            Assert.True(first.Equals(second));
        }

        [Fact]
        public void Equals_SameInstance_ReturnsTrue()
        {
            Point point = new Point(-4, 8);

            Assert.True(point.Equals(point));
        }

        [Theory]
        [InlineData(1, 2, 1, 2, true)]
        [InlineData(0, 0, 0, 0, true)]
        [InlineData(-3.5, -7.5, -3.5, -7.5, true)]
        [InlineData(1, 2, 2, 1, false)]
        [InlineData(1, 2, 1, 3, false)]
        [InlineData(1, 2, -1, 2, false)]
        [InlineData(-1, -2, 1, 2, false)]
        public void Equals_ComparesCoordinates(double x1, double y1, double x2, double y2, bool expected)
        {
            Point first = new Point(x1, y1);
            Point second = new Point(x2, y2);

            Assert.Equal(expected, first.Equals(second));
        }

        [Fact]
        public void Equals_Null_ReturnsFalse()
        {
            Point point = new Point(1, 2);

            Assert.False(point.Equals(null));
        }

        [Fact]
        public void Equals_OtherType_ReturnsFalse()
        {
            Point point = new Point(1, 2);

            Assert.False(point.Equals("(1,2)"));
        }

        [Fact]
        public void Equals_IsSymmetric()
        {
            Point first = new Point(6, -6);
            Point second = new Point(6, -6);

            Assert.True(first.Equals(second));
            Assert.True(second.Equals(first));
        }

        [Fact]
        public void GetHashCode_EqualPoints_ReturnSameValue()
        {
            Point first = new Point(2.5, -4.5);
            Point second = new Point(2.5, -4.5);

            Assert.Equal(first.GetHashCode(), second.GetHashCode());
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(3, 4)]
        [InlineData(-1.5, -2.5)]
        public void GetHashCode_EqualPoints_ReturnSameValueForDifferentCoordinates(double x, double y)
        {
            Point first = new Point(x, y);
            Point second = new Point(x, y);

            Assert.Equal(first.GetHashCode(), second.GetHashCode());
        }

        [Fact]
        public void GetHashCode_SameInstance_IsStable()
        {
            Point point = new Point(9, -9);

            Assert.Equal(point.GetHashCode(), point.GetHashCode());
        }

        [Fact]
        public void GetHashCode_DifferentPoints_ReturnDifferentValues()
        {
            Point first = new Point(1, 2);
            Point second = new Point(2, 1);

            Assert.NotEqual(first.GetHashCode(), second.GetHashCode());
        }
    }
}
