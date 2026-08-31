using System;
using System.Collections.Generic;
using HW9;
using Xunit;

namespace HW9.Tests
{
    public class EdgeCaseTests
    {
        [Theory]
        [InlineData(0.0, 0.0, 3.0, 4.0)]
        [InlineData(-3.0, -4.0, 3.0, 4.0)]
        [InlineData(-7.25, 0.0, 0.0, -7.25)]
        [InlineData(1234567.89, -987654.321, -0.5, 0.25)]
        [InlineData(1e-8, 5e-9, -3e-8, 2e-9)]
        [InlineData(1e150, -1e150, -1e150, 1e150)]
        public void DistanceBetweenTwoPointsIsSymmetric(double ax, double ay, double bx, double by)
        {
            Point a = new Point(ax, ay);
            Point b = new Point(bx, by);

            double forward = a.DistanceTo(b);
            double backward = b.DistanceTo(a);

            Assert.Equal(forward, backward);
        }

        [Theory]
        [InlineData(-1.0, 2.0, 3.0, -4.0, 5.0, 6.0)]
        [InlineData(-5.0, -5.0, -1.0, -8.0, -9.0, -9.0)]
        [InlineData(2.0, -3.0, -4.0, 5.0, 6.0, 7.0)]
        [InlineData(1e8, 1e8, 100000003.0, 1e8, 1e8, 100000004.0)]
        public void TriangleDistanceHelperIsSymmetricForEveryPair(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Point a = new Point(x1, y1);
            Point b = new Point(x2, y2);
            Point c = new Point(x3, y3);
            Triangle triangle = new Triangle(a, b, c);

            Assert.Equal(triangle.Distance(a, b), triangle.Distance(b, a));
            Assert.Equal(triangle.Distance(b, c), triangle.Distance(c, b));
            Assert.Equal(triangle.Distance(c, a), triangle.Distance(a, c));
        }

        [Fact]
        public void DistanceFromFarPointToItselfIsExactlyZero()
        {
            Point far = new Point(-1e12, 7.5e11);
            Point twin = new Point(-1e12, 7.5e11);

            Assert.Equal(0.0, far.DistanceTo(far));
            Assert.Equal(0.0, far.DistanceTo(twin));
        }

        [Fact]
        public void DistanceStaysFiniteForVeryLargeCoordinates()
        {
            Point origin = new Point(0.0, 0.0);
            Point huge = new Point(3e150, 4e150);

            double distance = origin.DistanceTo(huge);

            Assert.True(double.IsFinite(distance));
            AssertClose(5e150, distance, 1e-12);
        }

        [Fact]
        public void DistanceKeepsPrecisionForVerySmallCoordinates()
        {
            Point origin = new Point(0.0, 0.0);
            Point tiny = new Point(3e-10, 4e-10);

            double distance = origin.DistanceTo(tiny);

            AssertClose(5e-10, distance, 1e-12);
        }

        [Fact]
        public void CoordinatesCloserThanDoubleResolutionCollapseToTheSamePoint()
        {
            double big = 1e16;
            Point first = new Point(big, 0.0);
            Point second = new Point(big + 1.0, 0.0);

            Assert.Equal(first, second);
            Assert.Equal(first.GetHashCode(), second.GetHashCode());
            Assert.Equal(0.0, first.DistanceTo(second));
        }

        [Fact]
        public void NegativeZeroIsTreatedAsZero()
        {
            Point negativeZero = new Point(-0.0, -0.0);
            Point positiveZero = new Point(0.0, 0.0);

            Assert.Equal(positiveZero, negativeZero);
            Assert.Equal(positiveZero.GetHashCode(), negativeZero.GetHashCode());
            Assert.Equal(0.0, negativeZero.DistanceTo(positiveZero));
        }

        [Theory]
        [InlineData(0.0)]
        [InlineData(1e-11)]
        [InlineData(-1e-11)]
        [InlineData(9e-11)]
        [InlineData(-5e-15)]
        public void AlmostCollinearPointsAreRejectedBelowTheEpsilon(double offset)
        {
            Point a = new Point(0.0, 0.0);
            Point b = new Point(1.0, 0.0);
            Point c = new Point(0.5, offset);

            Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
        }

        [Theory]
        [InlineData(1e-10)]
        [InlineData(-1e-10)]
        [InlineData(1e-9)]
        [InlineData(-1e-9)]
        public void AlmostCollinearPointsAreAcceptedAtOrAboveTheEpsilon(double offset)
        {
            Point a = new Point(0.0, 0.0);
            Point b = new Point(1.0, 0.0);
            Point c = new Point(0.5, offset);

            Triangle triangle = new Triangle(a, b, c);

            Assert.Equal(offset, triangle.Vertex3.Y);
            Assert.True(double.IsFinite(triangle.Perimeter()));
        }

        [Fact]
        public void AlmostCollinearPointsFarFromOriginAreAcceptedBecauseTheEpsilonIsAbsolute()
        {
            Point a = new Point(0.0, 0.0);
            Point b = new Point(1e6, 0.0);
            Point c = new Point(5e5, 1e-4);

            Triangle sliver = new Triangle(a, b, c);

            AssertClose(2e6, sliver.Perimeter(), 1e-9);
        }

        [Fact]
        public void ThinTriangleStillReportsItsArea()
        {
            Triangle thin = new Triangle(new Point(0.0, 0.0), new Point(1000.0, 0.0), new Point(500.0, 0.001));

            AssertClose(0.5, thin.Area(), 1e-3);
        }

        [Theory]
        [InlineData(-1.0, 2.0, 3.0, -4.0, 5.0, 6.0, 26.0)]
        [InlineData(-5.0, -5.0, -1.0, -8.0, -9.0, -9.0, 14.0)]
        [InlineData(2.0, -3.0, -4.0, 5.0, 6.0, 7.0, 46.0)]
        [InlineData(0.0, 0.0, -7.0, 0.0, 0.0, -9.0, 31.5)]
        [InlineData(-1.0, -1.0, -4.0, -1.0, -1.0, -5.0, 6.0)]
        public void AreaIsCorrectWithNegativeCoordinatesInEveryPosition(double x1, double y1, double x2, double y2, double x3, double y3, double expectedArea)
        {
            Triangle triangle = new Triangle(new Point(x1, y1), new Point(x2, y2), new Point(x3, y3));

            AssertClose(expectedArea, triangle.Area(), 1e-9);
        }

        [Theory]
        [InlineData(1.0, 1.0, 4.0, 1.0, 1.0, 5.0)]
        [InlineData(0.0, 0.0, 3.0, 4.0, -2.0, 7.0)]
        [InlineData(2.5, -3.5, -4.25, 5.75, 6.5, 7.25)]
        public void MirroringAllCoordinatesKeepsPerimeterAndArea(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Triangle original = new Triangle(new Point(x1, y1), new Point(x2, y2), new Point(x3, y3));
            Triangle mirrored = new Triangle(new Point(-x1, -y1), new Point(-x2, -y2), new Point(-x3, -y3));

            Assert.Equal(original.Perimeter(), mirrored.Perimeter());
            Assert.Equal(original.Area(), mirrored.Area());
        }

        [Fact]
        public void TranslatingATriangleFarFromOriginKeepsPerimeterAndArea()
        {
            double shift = 1e8;
            Triangle atOrigin = new Triangle(new Point(0.0, 0.0), new Point(3.0, 0.0), new Point(0.0, 4.0));
            Triangle farAway = new Triangle(new Point(shift, shift), new Point(shift + 3.0, shift), new Point(shift, shift + 4.0));

            Assert.Equal(12.0, farAway.Perimeter());
            Assert.Equal(6.0, farAway.Area());
            Assert.Equal(atOrigin.Perimeter(), farAway.Perimeter());
            Assert.Equal(atOrigin.Area(), farAway.Area());
        }

        [Fact]
        public void TriangleFarFromOriginMeasuresItsNearestVertex()
        {
            Triangle farAway = new Triangle(new Point(1000.0, 1000.0), new Point(1003.0, 1000.0), new Point(1000.0, 1004.0));

            Assert.Equal(Math.Sqrt(2000000.0), farAway.DistanceToOrigin());
        }

        [Fact]
        public void TriangleInTheNegativeQuadrantMeasuresItsNearestVertex()
        {
            Triangle negative = new Triangle(new Point(-1.0, -1.0), new Point(-4.0, -1.0), new Point(-1.0, -5.0));

            Assert.Equal(Math.Sqrt(2.0), negative.DistanceToOrigin());
            Assert.Equal(12.0, negative.Perimeter());
            AssertClose(6.0, negative.Area(), 1e-12);
        }

        [Fact]
        public void TriangleWithAVertexOnTheOriginHasZeroDistanceToOrigin()
        {
            Triangle touching = new Triangle(new Point(-5.0, -5.0), new Point(0.0, 0.0), new Point(3.0, -9.0));

            Assert.Equal(0.0, touching.DistanceToOrigin());
        }

        [Fact]
        public void DistanceToOriginDoesNotDependOnVertexOrder()
        {
            Point a = new Point(-8.0, 3.0);
            Point b = new Point(2.0, -2.0);
            Point c = new Point(6.0, 9.0);

            Triangle first = new Triangle(a, b, c);
            Triangle second = new Triangle(b, c, a);
            Triangle third = new Triangle(c, a, b);

            Assert.Equal(first.DistanceToOrigin(), second.DistanceToOrigin());
            Assert.Equal(first.DistanceToOrigin(), third.DistanceToOrigin());
        }

        [Fact]
        public void VeryLargeTriangleKeepsItsPerimeterAndArea()
        {
            Triangle huge = new Triangle(new Point(0.0, 0.0), new Point(3e70, 0.0), new Point(0.0, 4e70));

            AssertClose(1.2e71, huge.Perimeter(), 1e-12);
            AssertClose(6e140, huge.Area(), 1e-9);
        }

        [Fact]
        public void VerySmallTriangleKeepsItsPerimeterAndArea()
        {
            Triangle small = new Triangle(new Point(0.0, 0.0), new Point(3e-4, 0.0), new Point(0.0, 4e-4));

            AssertClose(1.2e-3, small.Perimeter(), 1e-12);
            AssertClose(6e-8, small.Area(), 1e-9);
        }

        [Theory]
        [InlineData(0.0, 0.0, 3.0, 0.0, 0.0, 4.0)]
        [InlineData(-1.0, -1.0, -4.0, -1.0, -1.0, -5.0)]
        [InlineData(1e8, 1e8, 100000003.0, 1e8, 1e8, 100000004.0)]
        [InlineData(0.0, 0.0, 0.001, 0.0, 0.0, 0.001)]
        [InlineData(0.0, 0.0, 3e70, 0.0, 0.0, 4e70)]
        [InlineData(2.0, -3.0, -4.0, 5.0, 6.0, 7.0)]
        public void ComputedSidesSatisfyTheTriangleInequality(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Point a = new Point(x1, y1);
            Point b = new Point(x2, y2);
            Point c = new Point(x3, y3);
            Triangle triangle = new Triangle(a, b, c);

            double first = triangle.Distance(a, b);
            double second = triangle.Distance(b, c);
            double third = triangle.Distance(c, a);

            Assert.True(first + second > third);
            Assert.True(second + third > first);
            Assert.True(third + first > second);
        }

        [Fact]
        public void ConstructorCopiesTheGivenVertices()
        {
            Point a = new Point(-2.5, 7.5);
            Point b = new Point(4.0, -1.0);
            Point c = new Point(-9.0, -3.0);

            Triangle triangle = new Triangle(a, b, c);

            Assert.NotSame(a, triangle.Vertex1);
            Assert.NotSame(b, triangle.Vertex2);
            Assert.NotSame(c, triangle.Vertex3);
            Assert.Equal(a, triangle.Vertex1);
            Assert.Equal(b, triangle.Vertex2);
            Assert.Equal(c, triangle.Vertex3);
        }

        [Fact]
        public void TieForClosestToOriginKeepsTheFirstAddedTriangle()
        {
            Triangle first = new Triangle(new Point(3.0, 4.0), new Point(10.0, 0.0), new Point(0.0, 10.0));
            Triangle second = new Triangle(new Point(-3.0, -4.0), new Point(-10.0, 0.0), new Point(0.0, -10.0));
            ShapeGroup group = new ShapeGroup();
            group.AddTriangle(first);
            group.AddTriangle(second);

            Assert.Equal(first.DistanceToOrigin(), second.DistanceToOrigin());
            Assert.Same(first, group.FindTriangleClosestToOrigin());
        }

        [Fact]
        public void TieForClosestToOriginFollowsInsertionOrder()
        {
            Triangle first = new Triangle(new Point(3.0, 4.0), new Point(10.0, 0.0), new Point(0.0, 10.0));
            Triangle second = new Triangle(new Point(-3.0, -4.0), new Point(-10.0, 0.0), new Point(0.0, -10.0));
            ShapeGroup group = new ShapeGroup();
            group.AddTriangle(second);
            group.AddTriangle(first);

            Assert.Same(second, group.FindTriangleClosestToOrigin());
        }

        [Fact]
        public void ClosestToOriginLooksAtVerticesNotAtTriangleSize()
        {
            Triangle bigButTouchingOrigin = new Triangle(new Point(0.5, 0.0), new Point(100.0, 0.0), new Point(50.0, 100.0));
            Triangle smallButFurther = new Triangle(new Point(2.0, 2.0), new Point(3.0, 2.0), new Point(2.0, 3.0));
            ShapeGroup group = new ShapeGroup();
            group.AddTriangle(smallButFurther);
            group.AddTriangle(bigButTouchingOrigin);

            Assert.True(bigButTouchingOrigin.Area() > smallButFurther.Area());
            Assert.Same(bigButTouchingOrigin, group.FindTriangleClosestToOrigin());
        }

        [Fact]
        public void SameTriangleAddedTwiceIsStoredTwice()
        {
            Triangle triangle = new Triangle(new Point(-1.0, -1.0), new Point(-4.0, -1.0), new Point(-1.0, -5.0));
            ShapeGroup group = new ShapeGroup();
            group.AddTriangle(triangle);
            group.AddTriangle(triangle);

            IReadOnlyList<Triangle> all = group.GetAll();

            Assert.Equal(2, group.Count);
            Assert.Same(all[0], all[1]);
            Assert.Same(triangle, group.FindTriangleClosestToOrigin());
        }

        [Fact]
        public void RemovingATriangleAddedTwiceDropsOneOccurrenceAtATime()
        {
            Triangle triangle = new Triangle(new Point(1.0, 1.0), new Point(4.0, 1.0), new Point(1.0, 5.0));
            ShapeGroup group = new ShapeGroup();
            group.AddTriangle(triangle);
            group.AddTriangle(triangle);

            Assert.True(group.RemoveTriangle(triangle));
            Assert.Equal(1, group.Count);
            Assert.Same(triangle, group.GetAll()[0]);

            Assert.True(group.RemoveTriangle(triangle));
            Assert.Equal(0, group.Count);

            Assert.False(group.RemoveTriangle(triangle));
            Assert.Null(group.FindTriangleClosestToOrigin());
        }

        [Fact]
        public void TriangleWithTheSameCoordinatesIsADifferentEntryInTheGroup()
        {
            Triangle stored = new Triangle(new Point(0.0, 0.0), new Point(3.0, 0.0), new Point(0.0, 4.0));
            Triangle lookalike = new Triangle(new Point(0.0, 0.0), new Point(3.0, 0.0), new Point(0.0, 4.0));
            ShapeGroup group = new ShapeGroup();
            group.AddTriangle(stored);

            Assert.False(group.RemoveTriangle(lookalike));
            Assert.Equal(1, group.Count);
            Assert.Same(stored, group.GetAll()[0]);
        }

        [Fact]
        public void RemovingFromAnEmptyGroupIsHarmless()
        {
            Triangle triangle = new Triangle(new Point(0.0, 0.0), new Point(3.0, 0.0), new Point(0.0, 4.0));
            ShapeGroup group = new ShapeGroup();

            Assert.False(group.RemoveTriangle(triangle));
            Assert.False(group.RemoveTriangle(null));
            Assert.Equal(0, group.Count);
        }

        private static void AssertClose(double expected, double actual, double relativeTolerance)
        {
            double difference = Math.Abs(expected - actual);
            double scale = Math.Max(Math.Abs(expected), Math.Abs(actual));

            if (scale == 0.0)
            {
                Assert.Equal(0.0, difference);
                return;
            }

            Assert.True(difference / scale < relativeTolerance, "Expected " + expected + " but got " + actual);
        }
    }
}
