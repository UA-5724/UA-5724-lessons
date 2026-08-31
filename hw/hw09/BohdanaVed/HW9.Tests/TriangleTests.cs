using HW9;

namespace HW9.Tests
{
    public class TriangleTests
    {
        [Fact]
        public void DefaultConstructor_CreatesValidTriangle()
        {
            Triangle triangle = new Triangle();

            Assert.Equal(new Point(0, 0), triangle.Vertex1);
            Assert.Equal(new Point(1, 0), triangle.Vertex2);
            Assert.Equal(new Point(0, 1), triangle.Vertex3);
            Assert.Equal(2 + Math.Sqrt(2), triangle.Perimeter(), 10);
            Assert.Equal(0.5, triangle.Area(), 10);
        }

        [Fact]
        public void Constructor_KeepsGivenVertices()
        {
            Point a = new Point(1, 2);
            Point b = new Point(4, 2);
            Point c = new Point(1, 6);

            Triangle triangle = new Triangle(a, b, c);

            Assert.Equal(1, triangle.Vertex1.X, 10);
            Assert.Equal(2, triangle.Vertex1.Y, 10);
            Assert.Equal(4, triangle.Vertex2.X, 10);
            Assert.Equal(2, triangle.Vertex2.Y, 10);
            Assert.Equal(1, triangle.Vertex3.X, 10);
            Assert.Equal(6, triangle.Vertex3.Y, 10);
        }

        [Theory]
        [InlineData(0, 0, 3, 4, 5)]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(2, 3, 2, 3, 0)]
        [InlineData(-1, -1, 2, 3, 5)]
        [InlineData(-3, -4, 0, 0, 5)]
        [InlineData(0, 0, 1, 1, 1.4142135624)]
        public void Distance_ReturnsExpectedLength(double x1, double y1, double x2, double y2, double expected)
        {
            Triangle triangle = new Triangle();
            Point a = new Point(x1, y1);
            Point b = new Point(x2, y2);

            double actual = triangle.Distance(a, b);

            Assert.Equal(expected, actual, 9);
        }

        [Fact]
        public void Distance_IsSymmetric()
        {
            Triangle triangle = new Triangle();
            Point a = new Point(-2, 5);
            Point b = new Point(7, -1);

            Assert.Equal(triangle.Distance(a, b), triangle.Distance(b, a), 10);
        }

        [Fact]
        public void Distance_WithNullFirstPoint_ThrowsArgumentNullException()
        {
            Triangle triangle = new Triangle();
            Point b = new Point(1, 1);

            Assert.Throws<ArgumentNullException>(() => triangle.Distance(null, b));
        }

        [Fact]
        public void Distance_WithNullSecondPoint_ThrowsArgumentNullException()
        {
            Triangle triangle = new Triangle();
            Point a = new Point(1, 1);

            Assert.Throws<ArgumentNullException>(() => triangle.Distance(a, null));
        }

        [Fact]
        public void Perimeter_ForRightTriangle_Returns12()
        {
            Triangle triangle = new Triangle(new Point(0, 0), new Point(3, 0), new Point(0, 4));

            Assert.Equal(12, triangle.Perimeter(), 10);
        }

        [Fact]
        public void Area_ForRightTriangle_Returns6()
        {
            Triangle triangle = new Triangle(new Point(0, 0), new Point(3, 0), new Point(0, 4));

            Assert.Equal(6, triangle.Area(), 10);
        }

        [Theory]
        [InlineData(0, 0, 3, 0, 0, 4, 12)]
        [InlineData(0, 0, 1, 0, 0, 1, 3.4142135624)]
        [InlineData(-1, -1, 2, -1, -1, 3, 12)]
        [InlineData(0, 0, 6, 0, 3, 4, 16)]
        public void Perimeter_ReturnsSumOfSides(double x1, double y1, double x2, double y2, double x3, double y3, double expected)
        {
            Triangle triangle = new Triangle(new Point(x1, y1), new Point(x2, y2), new Point(x3, y3));

            Assert.Equal(expected, triangle.Perimeter(), 9);
        }

        [Theory]
        [InlineData(0, 0, 3, 0, 0, 4, 6)]
        [InlineData(0, 0, 1, 0, 0, 1, 0.5)]
        [InlineData(0, 0, 4, 0, 1, 3, 6)]
        [InlineData(-2, -2, 2, -2, -2, 2, 8)]
        [InlineData(0, 0, 6, 0, 3, 4, 12)]
        public void Area_ByHeronFormula_ReturnsExpectedValue(double x1, double y1, double x2, double y2, double x3, double y3, double expected)
        {
            Triangle triangle = new Triangle(new Point(x1, y1), new Point(x2, y2), new Point(x3, y3));

            Assert.Equal(expected, triangle.Area(), 9);
        }

        [Fact]
        public void Area_DoesNotDependOnVertexOrder()
        {
            Point a = new Point(0, 0);
            Point b = new Point(4, 0);
            Point c = new Point(1, 3);

            Triangle first = new Triangle(a, b, c);
            Triangle second = new Triangle(c, a, b);

            Assert.Equal(first.Area(), second.Area(), 10);
            Assert.Equal(first.Perimeter(), second.Perimeter(), 10);
        }

        [Theory]
        [InlineData(0, 0, 1, 1, 2, 2)]
        [InlineData(0, 0, 0, 1, 0, 5)]
        [InlineData(0, 0, 5, 0, 2, 0)]
        [InlineData(-1, -1, 0, 0, 1, 1)]
        [InlineData(1, 1, 3, 5, 5, 9)]
        public void Constructor_WithCollinearPoints_ThrowsArgumentException(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Point a = new Point(x1, y1);
            Point b = new Point(x2, y2);
            Point c = new Point(x3, y3);

            Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
        }

        [Fact]
        public void Constructor_WithRepeatedPoint_ThrowsArgumentException()
        {
            Point a = new Point(2, 2);
            Point b = new Point(5, 7);

            Assert.Throws<ArgumentException>(() => new Triangle(a, a, b));
        }

        [Fact]
        public void Constructor_WithNullFirstPoint_ThrowsArgumentNullException()
        {
            Point b = new Point(3, 0);
            Point c = new Point(0, 4);

            Assert.Throws<ArgumentNullException>(() => new Triangle(null, b, c));
        }

        [Fact]
        public void Constructor_WithNullSecondPoint_ThrowsArgumentNullException()
        {
            Point a = new Point(0, 0);
            Point c = new Point(0, 4);

            Assert.Throws<ArgumentNullException>(() => new Triangle(a, null, c));
        }

        [Fact]
        public void Constructor_WithNullThirdPoint_ThrowsArgumentNullException()
        {
            Point a = new Point(0, 0);
            Point b = new Point(3, 0);

            Assert.Throws<ArgumentNullException>(() => new Triangle(a, b, null));
        }

        [Fact]
        public void Constructor_CopiesPoints_VerticesAreNotTheCallerObjects()
        {
            Point a = new Point(0, 0);
            Point b = new Point(3, 0);
            Point c = new Point(0, 4);

            Triangle triangle = new Triangle(a, b, c);

            Assert.NotSame(a, triangle.Vertex1);
            Assert.NotSame(b, triangle.Vertex2);
            Assert.NotSame(c, triangle.Vertex3);
            Assert.Equal(a, triangle.Vertex1);
            Assert.Equal(b, triangle.Vertex2);
            Assert.Equal(c, triangle.Vertex3);
        }

        [Fact]
        public void Triangles_BuiltFromTheSamePoint_DoNotShareThatPoint()
        {
            Point shared = new Point(0, 0);

            Triangle first = new Triangle(shared, new Point(3, 0), new Point(0, 4));
            Triangle second = new Triangle(shared, new Point(6, 0), new Point(0, 8));

            Assert.NotSame(shared, first.Vertex1);
            Assert.NotSame(shared, second.Vertex1);
            Assert.NotSame(first.Vertex1, second.Vertex1);
            Assert.Equal(shared, first.Vertex1);
            Assert.Equal(shared, second.Vertex1);
            Assert.Equal(12, first.Perimeter(), 10);
            Assert.Equal(24, second.Perimeter(), 10);
        }

        [Fact]
        public void Vertices_AreNotChangedWhenCallerReusesItsVariables()
        {
            Point a = new Point(0, 0);
            Point b = new Point(3, 0);
            Point c = new Point(0, 4);

            Triangle triangle = new Triangle(a, b, c);
            double perimeterBefore = triangle.Perimeter();
            double areaBefore = triangle.Area();

            a = new Point(100, 100);
            b = new Point(200, 200);
            c = new Point(300, 400);

            Assert.Equal(perimeterBefore, triangle.Perimeter(), 10);
            Assert.Equal(areaBefore, triangle.Area(), 10);
            Assert.Equal(new Point(0, 0), triangle.Vertex1);
            Assert.Equal(new Point(3, 0), triangle.Vertex2);
            Assert.Equal(new Point(0, 4), triangle.Vertex3);
        }

        [Fact]
        public void Vertex_HasNoSetterToReplaceOwnedPoint()
        {
            Type triangleType = typeof(Triangle);

            Assert.Null(triangleType.GetProperty("Vertex1").SetMethod);
            Assert.Null(triangleType.GetProperty("Vertex2").SetMethod);
            Assert.Null(triangleType.GetProperty("Vertex3").SetMethod);
        }

        [Fact]
        public void ToString_ContainsVerticesPerimeterAndArea()
        {
            Triangle triangle = new Triangle(new Point(0, 0), new Point(3, 0), new Point(0, 4));

            string text = triangle.ToString();

            Assert.Contains("(0,0)", text);
            Assert.Contains("(3,0)", text);
            Assert.Contains("(0,4)", text);
            Assert.Contains("perimeter = 12", text);
            Assert.Contains("area = 6", text);
        }

        [Fact]
        public void Print_WritesTheSameTextAsToString()
        {
            Triangle triangle = new Triangle(new Point(0, 0), new Point(3, 0), new Point(0, 4));

            TextWriter original = Console.Out;
            StringWriter captured = new StringWriter();

            try
            {
                Console.SetOut(captured);
                triangle.Print();
            }
            finally
            {
                Console.SetOut(original);
            }

            Assert.Equal(triangle.ToString() + Environment.NewLine, captured.ToString());
        }
    }
}
